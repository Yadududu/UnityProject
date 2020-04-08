using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System;
using UnityEditor;
using UnityEngine;
using System.Reflection;

namespace CreateUIScript {
    //导出脚本的模版
    public class CreateSpriteUnit {

        public static string generateClassName = "generateClassName";
        public static string generateObjName = "generateObjName";
        public static string generateVarPath = "generateVarPath";

        //缓存所有子对象信息
        public List<UIInfo> evenlist = new List<UIInfo>();

        public StringBuilder varPath = new StringBuilder();
        //脚本后缀名
        private string _UIPanelSuffix = "UIPanel";
        private string _ComponentSuffix = "Program";
        /// <summary>
        /// 把拼接好的UI元素脚本写到本地。
        /// </summary>
        public void WriteUIPanelClass(string path, string className, GameObject seleGO) {
            bool flag = true;//省略 BOM
            bool throwOnInvalidBytes = false;
            UTF8Encoding encoding = new UTF8Encoding(flag, throwOnInvalidBytes);
            bool append = false;

            string panelClassName = className + _UIPanelSuffix;
            if (path.Substring(path.Length - 1) == "/") {
                path = path + panelClassName + ".cs";
            } else {
                path = path + "/" + panelClassName + ".cs";
            }
            string p = path.Replace("Assets", "");
            if (File.Exists(Application.dataPath + p)) {
                var falg = EditorUtility.DisplayDialog("提示", panelClassName + "脚本已经存在，是否要替换脚本？", "是", "否");
                if (falg) {
                    StreamReader textAsset = new StreamReader(Application.dataPath + p);
                    string textStr = textAsset.ReadToEnd();
                    textAsset.Close();

                    StreamWriter writer = new StreamWriter(path, append, encoding);
                    writer.Write(GetReplaceNewVarName(textStr));
                    writer.Close();
                    AssetDatabase.Refresh();
                    Debug.Log(panelClassName + "脚本替换成功");
                    //把类名和gameobject名暂存起来
                    EditorPrefs.SetString(generateClassName, panelClassName);
                    EditorPrefs.SetString(generateObjName, seleGO.name);
                    EditorPrefs.SetString(generateVarPath, varPath.ToString());
                }
            } else {
                //StreamWriter writer = new StreamWriter(Application.dataPath + "/" + classname + ".cs", append, encoding);
                StreamWriter writer = new StreamWriter(path, append, encoding);
                writer.Write(GetUIPanelClass(className));
                writer.Close();
                AssetDatabase.Refresh();
                Debug.Log(panelClassName + "脚本已生成");
                //把类名和gameobject名暂存起来
                EditorPrefs.SetString(generateClassName, panelClassName);
                EditorPrefs.SetString(generateObjName, seleGO.name);
                EditorPrefs.SetString(generateVarPath, varPath.ToString());
            }
        }
        //脚本拼接
        private string GetUIPanelClass(string className) {
            string template = @"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class @ClassName : BaseUIPanel{   
    //--AutoCreateStart
@fields
    //--AutoCreateEnd

    public void Awake(){
        UIPanelManager.Instance.RegisterPanel(this.name, this);
    }

    public void Start(){

    }
    public void Open() {
        UIPanelManager.Instance.PushPanel(this.name);
    }
    public void Close() {
        UIPanelManager.Instance.PopPanel(this.name);
    }
    public override void OnEnter() {
        
    }
    public override void OnExit() {
        
    }
    public override void OnPause() {
        
    }
    public override void OnResume() {
        
    }
}
";
            var fields = new StringBuilder();
            string panelClassName = className + _UIPanelSuffix;

            for (int i = 0; i < evenlist.Count; i++) {
                //拼接 属性名:属性实例化地址
                if (evenlist[i].varName != null & evenlist[i].pathName != null) {
                    if (i == 0) varPath.Append(evenlist[i].varName + ":");
                    else varPath.Append("." + evenlist[i].varName + ":");
                    varPath.Append(evenlist[i].pathName);
                }
                if (evenlist[i].field != null) fields.AppendLine("\t" + evenlist[i].field);
                //Debug.Log(evenlist[i].field);
            }
            template = template.Replace("@ClassName", panelClassName).Trim();
            template = template.Replace("@fields", fields.ToString()).Trim();
            return template;
        }

        //替换属性
        private string GetReplaceNewVarName(string originText) {
            string template = @"
    //--AutoCreateStart
@fields
";
            string frontPart = "";
            string latePart = "";
            string str = originText;
            var fields = new StringBuilder();
            var newText = new StringBuilder();

            //获取前缀标记//--AutoCreateStart,如果丢失,则获取全文
            frontPart = str.Substring(0, str.IndexOf("//--AutoCreateStart") == -1 ? str.Length : str.IndexOf("//--AutoCreateStart"));
            //获取后缀标记//--AutoCreateEnd,如果丢失,则获取全文
            if (frontPart.Length == str.Length) {
                latePart = str.Substring(str.Length);
            } else {
                latePart = str.Substring(str.IndexOf("//--AutoCreateEnd") == -1 ? 0 : str.IndexOf("//--AutoCreateEnd"));
            }
            //后缀如果获取全文则删除前缀
            if (latePart.Length == str.Length) frontPart = "";

            for (int i = 0; i < evenlist.Count; i++) {
                //拼接 属性名:属性实例化地址
                if (evenlist[i].varName != null & evenlist[i].pathName != null) {
                    if (i == 0) varPath.Append(evenlist[i].varName + ":");
                    else varPath.Append("." + evenlist[i].varName + ":");
                    varPath.Append(evenlist[i].pathName);
                }
                if (evenlist[i].field != null) fields.AppendLine("\t" + evenlist[i].field);
                //Debug.Log(evenlist[i].field);
            }
            template = template.Replace("@fields", fields.ToString()).Trim();
            newText.Append(frontPart);
            newText.AppendLine(template);
            newText.AppendLine("\t" + latePart);
            return newText.ToString();
        }

        //编辑完后自动回调
        [UnityEditor.Callbacks.DidReloadScripts]
        static void AddComponentToGameObject() {
            string className = EditorPrefs.GetString(generateClassName);
            string objName = EditorPrefs.GetString(generateObjName);
            string varPath = EditorPrefs.GetString(generateVarPath);
            //Debug.Log(className);
            //Debug.Log(objName);
            //Debug.Log(varPath);
            if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(objName) || string.IsNullOrEmpty(varPath)) {
                return;
            }

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var defaultAssembly = assemblies.First(assembly => assembly.GetName().Name == "Assembly-CSharp");
            var type = defaultAssembly.GetType(className);
            if (type == null) {
                Debug.Log("编译失败");
                return;
            }
            var gameObject = GameObject.Find(objName);
            var scriptComponent = gameObject.GetComponent(type);
            if (!scriptComponent) {
                scriptComponent = gameObject.AddComponent(type);
            }

            //把varPath拆分属性名和地址,并用字典保存,key是属性名,value是地址
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string[] strs = varPath.Split('.');
            foreach (var str in strs) {
                string[] s = str.Split(':');
                //list属性的属性名相同,所以地址用","分隔,保存到同一个Key里
                if (dic.ContainsKey(s[0])) dic[s[0]] = dic[s[0]] + "," + s[1];
                else dic.Add(s[0], s[1]);
            }

            foreach (var item in scriptComponent.GetType().GetFields()) {
                if (dic.ContainsKey(item.Name)) {
                    if (item.FieldType.Name.Equals("List`1")) {
                        Type fieldType = item.FieldType;
                        object entityList = Activator.CreateInstance(fieldType);
                        MethodInfo methodInfo = fieldType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
                        //获取该列表元素的所有地址
                        string[] paths = dic[item.Name].Split(',');
                        if (fieldType.GetGenericArguments()[0].Name.Equals("GameObject")) {
                            for (int i = 0; i < paths.Length; i++) {
                                //Debug.Log(paths[i]);
                                methodInfo.Invoke(entityList, new object[] {
                            gameObject.transform.Find(paths[i]).gameObject
                        });
                            }
                        } else {
                            for (int i = 0; i < paths.Length; i++) {
                                //Debug.Log(paths[i]);
                                methodInfo.Invoke(entityList, new object[] {
                            gameObject.transform.Find(paths[i]).GetComponent(fieldType.GetGenericArguments()[0].Name)
                        });
                            }
                        }
                        item.SetValue(scriptComponent, entityList);
                    } else if (item.FieldType.Name.Equals("GameObject")) {
                        //Debug.Log(item.Name);
                        item.SetValue(scriptComponent, gameObject.transform.Find(dic[item.Name]).gameObject);
                    } else {
                        //Debug.Log(item.Name);
                        item.SetValue(scriptComponent, gameObject.transform.Find(dic[item.Name]).GetComponent(item.FieldType.Name));
                    }
                }
            }
            EditorPrefs.DeleteKey(generateClassName);
            EditorPrefs.DeleteKey(generateObjName);
            EditorPrefs.DeleteKey(generateVarPath);
        }
    }

}
