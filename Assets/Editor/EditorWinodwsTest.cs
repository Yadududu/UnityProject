using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorWinodwsTest : EditorWindow {

    [MenuItem("Window/show mywindow")]
    static void ShowMyWindow() {
        EditorWinodwsTest window = EditorWindow.GetWindow<EditorWinodwsTest>();
        window.Show();
    }

    private string _name = "default";
    void OnGUI() {
        GUILayout.Label("输入GameObject名字");
        _name = GUILayout.TextField(_name);
        if (GUILayout.Button("创建")) {
            GameObject go = new GameObject(_name);
            Undo.RegisterCreatedObjectUndo(go, "create gameobject");
        }
    }

}
