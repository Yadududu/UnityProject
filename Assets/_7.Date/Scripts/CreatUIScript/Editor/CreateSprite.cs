using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateSprite {
    //当前操作的对象
    private static GameObject CurGo;
    //后缀对应的组件类型
    public static Dictionary<string, string> typeMap = new Dictionary<string, string>(){
        { "sp", typeof(Sprite).Name },
        { "go", typeof(GameObject).Name},
        { "txt", typeof(Text).Name },
        { "ptxt", typeof(TMP_Text).Name },
        { "image", typeof(Image).Name },
        { "btn", typeof(Button).Name },
        { "tog", typeof(Toggle).Name },
        { "sli", typeof(Slider).Name },
        { "scb", typeof(Scrollbar).Name },
        { "dro", typeof(Dropdown).Name },
        { "pdro", typeof(TMP_Dropdown).Name },
        { "input", typeof(InputField).Name },
        { "pinput", typeof(TMP_InputField).Name },
        { "scr", typeof(ScrollRect).Name },
    };
    //脚本模版
    private static CreateSpriteUnit info;
    //保存已经创建的list名,避免重复创建
    private static List<string> _VarName = new List<string>();
    //当前选择得GameObject
    private static GameObject[] gameObjects;

    //在Project窗口下，选中要导出的界面，然后点击GameObject/导出脚本
    [MenuItem("GameObject/CreateUIScript", false, 11)]
    public static void CreateSpriteAction() {

        gameObjects = Selection.gameObjects;
        //保证只有一个对象
        if (gameObjects.Length == 1) {
            CreateUIScript.ShowMyWindow();
        } else {
            EditorUtility.DisplayDialog("警告", "你只能选择一个GameObject", "确定");
        }
    }

    public static void CreateScript(string className, string path, bool creatComponentSign, bool addComponentSign) {
        info = new CreateSpriteUnit();
        CurGo = gameObjects[0];
        ReadChild(CurGo.transform);
        info.classname = className + "UIPanel";

        //判断路径是否包含类名
        string[] str = path.Split('/');
        if (str[str.Length - 1] == "") {
            path = path + className + "UIPanel.cs";
        } else if (str[str.Length - 1] == className) {
            path = path + "UIPanel.cs";
        } else if (str[str.Length - 1] != className) {
            path = path + "/" + className + "UIPanel.cs";
        }
        Debug.Log(path);

        info.WtiteClass(path);
        info = null;
        CurGo = null;
        typeMap.Clear();
        _VarName.Clear();
    }

    //遍历所有子对象，GetChild方法只能获取第一层子对象。
    public static void ReadChild(Transform tf) {
        foreach (Transform child in tf) {

            string[] typeArr = child.name.Split('_');
            //判断是否符合"name_type"格式
            if (typeArr.Length > 1) {
                string typeKey = typeArr[typeArr.Length - 1];
                string typeName = typeArr[typeArr.Length - 2];
                if (typeMap.ContainsKey(typeKey)) {
                    info.evenlist.Add(new UIInfo(child.name, typeKey, buildGameObjectPath(child).Replace(CurGo.name + "/", "")));
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
                        info.evenlist.Add(new UIInfo(child.name, typeKey, buildGameObjectPath(child).Replace(CurGo.name + "/", ""), typeName, sign));
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
