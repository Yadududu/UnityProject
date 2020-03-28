using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateUIScript : EditorWindow {

    string path;
    Rect rect;
    
    [MenuItem("Window/CreateUIScript" )]
    public static void ShowMyWindow() {
        CreateUIScript window = EditorWindow.GetWindow<CreateUIScript>();
        window.Show();
    }

    private string _name = "default";
    private bool b = false;
    private void OnGUI() {
        _name = EditorGUILayout.TextField("输入脚本名字:", _name);
        
        ////获得一个长300的框
        //rect = EditorGUILayout.GetControlRect(GUILayout.Width(300));
        //将上面的框作为文本输入框
        path = EditorGUILayout.TextField("文件夹保存路径:", path);

        //如果鼠标正在拖拽中或拖拽结束时，并且鼠标所在位置在文本输入框内
        if ((Event.current.type == UnityEngine.EventType.DragUpdated
          || Event.current.type == UnityEngine.EventType.DragExited)
          && rect.Contains(Event.current.mousePosition)) {
            //改变鼠标的外表
            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
            if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0) {
                path = DragAndDrop.paths[0];
            }
        }

        if (GUILayout.Button("选择路径", GUILayout.Width(100))) {
            string path = EditorUtility.SaveFilePanelInProject("选择路径", " ", "", "");
            Debug.Log(path);
        }

        b = EditorGUILayout.Toggle("toggle", b);

        if (GUILayout.Button("创建脚本")) {
            GameObject go = new GameObject(_name);
            Undo.RegisterCreatedObjectUndo(go, "create gameobject");
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
