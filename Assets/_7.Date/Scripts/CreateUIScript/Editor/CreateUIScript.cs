using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateUIScript : EditorWindow {

    private string _ClassName = "Default";
    private string _Path= "Assets/Scripts/UI/";
    private Rect _Rect;
    private bool _CreatComponentSign = false;
    private bool _AddComponentSign = false;
    private static CreateUIScript window;

    [MenuItem("Window/CreateUIScript")]
    public static void ShowMyWindow() {
        window = EditorWindow.GetWindow<CreateUIScript>();
        window.Show();
    }

    private void OnGUI() {
        _ClassName = EditorGUILayout.TextField("输入脚本名:", _ClassName);

        ////获得一个长300的框
        _Rect = EditorGUILayout.GetControlRect(GUILayout.Width(Screen.width - 7));
        //将上面的框作为文本输入框
        _Path = EditorGUI.TextField(_Rect, "文件夹保存路径:", _Path);

        //如果鼠标正在拖拽中或拖拽结束时，并且鼠标所在位置在文本输入框内
        if ((Event.current.type == UnityEngine.EventType.DragUpdated
          || Event.current.type == UnityEngine.EventType.DragExited)
          && _Rect.Contains(Event.current.mousePosition)) {
            //改变鼠标的外表
            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
            if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0) {
                _Path = DragAndDrop.paths[0];
            }
        }

        if (GUILayout.Button("选择路径", GUILayout.Width(100))) {
            _Path = EditorUtility.SaveFilePanelInProject("选择路径", _ClassName, "", "");
        }

        _CreatComponentSign = EditorGUILayout.Toggle("是否生成实现类:", _CreatComponentSign);
        if (_CreatComponentSign) {
            _AddComponentSign = EditorGUILayout.Toggle("是否挂载该GameObject上:", _AddComponentSign);
        } else {
            _AddComponentSign = false;
        }

        if (GUILayout.Button("创建脚本")) {
            CreateSprite.CreateScript(_ClassName, _Path, _CreatComponentSign, _AddComponentSign);
            window.Close();
            //GameObject go = new GameObject(_ClassName);
            //Undo.RegisterCreatedObjectUndo(go, "create gameobject");
        }

    }
    //[MenuItem("Example/Overwrite Texture")]
    //static void Apply() {
    //    Texture2D texture = Selection.activeObject as Texture2D;
    //    if (texture == null) {
    //        EditorUtility.DisplayDialog("Select Texture", "You must select a texture first!", "OK");
    //        return;
    //    }

    //    string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
    //    if (path.Length != 0) {
    //        var fileContent = File.ReadAllBytes(path);
    //        texture.LoadImage(fileContent);
    //    }
    //}
}
