using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System;
using UnityEditor;
using UnityEngine;

namespace CreateUIScriptOld {
    //导出脚本的模版
    public class CreateSpriteUnit {

        public static string generateClassName = "generateClassName";
        public static string generateObjName = "generateObjName";

        //缓存的所有子对象信息
        public List<UIInfo> evenlist = new List<UIInfo>();
        //脚本后缀名
        private string _UIPanelSuffix = "UIPanel";
        private string _ComponentSuffix = "Program";
        /// <summary>
        /// 把拼接好的UI元素脚本写到本地。
        /// </summary>
        public void WriteUIPanelClass(string path, string className) {
            bool flag = true;//省略 BOM
            bool throwOnInvalidBytes = false;
            UTF8Encoding encoding = new UTF8Encoding(flag, throwOnInvalidBytes);
            bool append = false;

            if (path.Substring(path.Length - 1) == "/") {
                path = path + className + _UIPanelSuffix + ".cs";
            } else {
                path = path + "/" + className + _UIPanelSuffix + ".cs";
            }
            string p = path.Replace("Assets", "");
            if (File.Exists(Application.dataPath + p)) {
                var falg = EditorUtility.DisplayDialog("提示", className + _ComponentSuffix + "脚本已经存在，是否要替换脚本？", "是", "否");
                if (falg) {
                    StreamWriter writer = new StreamWriter(path, append, encoding);
                    writer.Write(GetUIPanelClass(className));
                    writer.Close();
                    AssetDatabase.Refresh();
                    Debug.Log(className + _UIPanelSuffix + "脚本替换成功");
                }
            } else {
                //StreamWriter writer = new StreamWriter(Application.dataPath + "/" + classname + ".cs", append, encoding);
                StreamWriter writer = new StreamWriter(path, append, encoding);
                writer.Write(GetUIPanelClass(className));
                writer.Close();
                AssetDatabase.Refresh();
                Debug.Log(className + _UIPanelSuffix + "脚本已生成");
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

public class @ClassName {   
@fields

    public void OnAwake(GameObject viewGO){
@body1
    }

    public void OnDestroy(){
@body2
    }
}
";
            var fields = new StringBuilder();
            var body1 = new StringBuilder();
            var body2 = new StringBuilder();
            string panelClassName = className + _UIPanelSuffix;

            for (int i = 0; i < evenlist.Count; i++) {
                if (evenlist[i].field != null) fields.AppendLine("\t" + evenlist[i].field);
                body1.AppendLine("\t\t" + evenlist[i].body1);
                if (evenlist[i].body2 != null) body2.AppendLine("\t\t" + evenlist[i].body2);
            }
            template = template.Replace("@ClassName", panelClassName).Trim();
            template = template.Replace("@body1", body1.ToString()).Trim();
            template = template.Replace("@body2", body2.ToString()).Trim();
            template = template.Replace("@fields", fields.ToString()).Trim();
            return template;
        }

        /// <summary>
        /// 把拼接好的UI组件脚本写到本地。
        /// </summary>
        public void WriteComponentClass(string path, string className, bool addComponentSign, GameObject seleGO) {

            string componentClassName = className + _ComponentSuffix;
            bool flag = true;//带 BOM
            bool throwOnInvalidBytes = false;
            UTF8Encoding encoding = new UTF8Encoding(flag, throwOnInvalidBytes);
            bool append = false;

            if (path.Substring(path.Length - 1) == "/") {
                path = path + className + _ComponentSuffix + ".cs";
            } else {
                path = path + "/" + className + _ComponentSuffix + ".cs";
            }
            string p = path.Replace("Assets", "");
            if (File.Exists(Application.dataPath + p)) {
                EditorUtility.DisplayDialog("警告", className + "Program.cs文件已存在!此文件不能被替换，如想重新生成请手动删除源文件", "确定");
            } else {
                //StreamWriter writer = new StreamWriter(Application.dataPath + "/" + classname + ".cs", append, encoding);
                StreamWriter writer = new StreamWriter(path, append, encoding);
                writer.Write(GetComponentClass(className, addComponentSign));
                writer.Close();
                AssetDatabase.Refresh();
                Debug.Log(componentClassName + "脚本已生成");
                //判断是否挂载脚本
                if (addComponentSign) {
                    if (!seleGO.GetComponent(componentClassName)) {
                        //把类名和gameobject名暂存起来
                        EditorPrefs.SetString(generateClassName, componentClassName);
                        EditorPrefs.SetString(generateObjName, seleGO.name);
                    }
                }

            }
        }
        //如果需要使用,请启用这里
        //编辑完后自动回调
        //[UnityEditor.Callbacks.DidReloadScripts]
        //static void AddComponent2GameObject() {
        //    string className = EditorPrefs.GetString(generateClassName);
        //    string objName = EditorPrefs.GetString(generateObjName);
        //    //Debug.Log(className);
        //    //Debug.Log(objName);
        //    if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(objName)) {
        //        return;
        //    }
        //    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        //    var defaultAssembly = assemblies.First(assembly => assembly.GetName().Name == "Assembly-CSharp");
        //    var type = defaultAssembly.GetType(className);
        //    if (type == null) {
        //        Debug.Log("编译失败");
        //        return;
        //    }

        //    var gameObject = GameObject.Find(objName);
        //    var scriptComponent = gameObject.GetComponent(type);
        //    if (!scriptComponent) {
        //        scriptComponent = gameObject.AddComponent(type);
        //    }
        //    EditorPrefs.DeleteKey(generateClassName);
        //    EditorPrefs.DeleteKey(generateObjName);

        //}
        //脚本拼接
        private string GetComponentClass(string className, bool addComponentSign) {
            string template = @"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class @ClassName : MonoBehaviour { 
@fields

    private @ClassName() {
@body1
    }

    private void Awake() {
@body2
    }

    public void Action() {

    }
}
";
            var fields = new StringBuilder();
            var body1 = new StringBuilder();
            var body2 = new StringBuilder();
            string panelClassName = className + _UIPanelSuffix;
            string componentClassName = className + _ComponentSuffix;

            if (!addComponentSign) fields.AppendLine("\t" + "public GameObject UICanvas;");
            fields.AppendLine("\t" + "public static " + componentClassName + " Get { get; private set; }");
            fields.AppendLine("\t" + "private " + panelClassName + " _UIPanel = new " + panelClassName + "();");

            body1.AppendLine("\t\t" + "Get = this;");
            if (addComponentSign) {
                body2.AppendLine("\t\t_UIPanel.OnAwake(gameObject);");
            } else {
                body2.AppendLine("\t\t_UIPanel.OnAwake(UICanvas);");
            }

            template = template.Replace("@ClassName", componentClassName).Trim();
            template = template.Replace("@body1", body1.ToString()).Trim();
            template = template.Replace("@body2", body2.ToString()).Trim();
            template = template.Replace("@fields", fields.ToString()).Trim();
            return template;
        }
    }
}
  
