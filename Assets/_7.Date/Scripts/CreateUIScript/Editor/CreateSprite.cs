using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Zeus.UITemplate {
    public class CreateSprite {

        //后缀对应的组件类型
        public static Dictionary<string, string> typeMap = new Dictionary<string, string>(){
        { "sp", typeof(Sprite).Name },
        { "go", typeof(GameObject).Name},
        { "can", typeof(Canvas).Name},
        { "cang", typeof(CanvasGroup).Name},
        { "txt", typeof(Text).Name },
        { "image", typeof(Image).Name },
        { "rimage", typeof(RawImage).Name },
        { "btn", typeof(Button).Name },
        { "tog", typeof(Toggle).Name },
        { "sli", typeof(Slider).Name },
        { "scb", typeof(Scrollbar).Name },
        { "dro", typeof(Dropdown).Name },
        { "input", typeof(InputField).Name },
        { "scr", typeof(ScrollRect).Name },
        { "3Dptxt", typeof(TextMeshPro).Name },
        { "ptxt", typeof(TextMeshProUGUI).Name },
        { "pdro", typeof(TMP_Dropdown).Name },
        { "pinput", typeof(TMP_InputField).Name },
    };
        //当前操作的对象
        private static GameObject _CurGo;
        //脚本模版
        private static CreateSpriteUnit _Info;
        //保存已经创建的list名,避免重复创建
        private static List<string> _VarName = new List<string>();

        public static void CreateScript(GameObject obj, string className, string path) {
            _Info = new CreateSpriteUnit();
            _CurGo = obj;
            ReadChild(_CurGo.transform);

            //判断路径
            string[] str = path.Split('/');
            if (str[0].Equals("Assets")) {
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
            } else {
                EditorUtility.DisplayDialog("警告", "请把脚本保存到项目的Assets文件下!", "确定");
                return;
            }
            Debug.Log("脚本生成路径：" + path);

            _Info.WriteUIPanelClass(path, className, _CurGo);
            _Info = null;
            _CurGo = null;
            typeMap.Clear();
            _VarName.Clear();
        }

        //遍历所有子对象
        public static void ReadChild(Transform tf) {
            foreach (Transform child in tf) {

                string[] typeArr = child.name.Split('_');
                //判断是否符合"name_type"格式
                if (typeArr.Length > 1) {
                    string typeKey = typeArr[typeArr.Length - 1];
                    string typeName = typeArr[typeArr.Length - 2];
                    if (typeMap.ContainsKey(typeKey)) {
                        _Info.evenlist.Add(new UIInfo(child.name, typeKey, buildGameObjectPath(child).Replace(buildGameObjectPath(_CurGo.transform) + "/", "")));
                        //Debug.Log(buildGameObjectPath(child));
                    }

                    //再次判断是否符合"name_type (1)"格式
                    string[] typeKeyArr = typeKey.Split(' ');
                    if (typeKeyArr.Length > 1) {
                        typeKey = typeKeyArr[typeKeyArr.Length - 2];

                        if (typeMap.ContainsKey(typeKey)) {
                            //判断是否已经创建过该类型的列表
                            bool sign;
                            typeName = typeName + "_" + typeKey + "s";
                            if (_VarName.Contains(typeName)) {
                                sign = true;
                            } else {
                                _VarName.Add(typeName);
                                sign = false;
                            }
                            _Info.evenlist.Add(new UIInfo(child.name, typeKey, buildGameObjectPath(child).Replace(buildGameObjectPath(_CurGo.transform) + "/", ""), typeName, sign));
                        }
                    }
                }
                if (child.childCount > 0) {
                    ReadChild(child);
                }
            }
        }
        //获取路径，这个路径是带当前对象名的，需要用Replace替换掉头部
        private static string buildGameObjectPath(Transform obj) {
            var buffer = new StringBuilder();

            //遍历该对象所有父对象
            while (obj != null) {
                if (buffer.Length > 0)
                    buffer.Insert(0, "/");
                buffer.Insert(0, obj.name);
                obj = obj.parent;
            }
            return buffer.ToString();
        }
    }

}
