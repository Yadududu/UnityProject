using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorWinodwsTest : EditorWindow {

    [MenuItem("Window/show mywindow")]
    public static void ShowMyWindow() {
        EditorWinodwsTest window = EditorWindow.GetWindow<EditorWinodwsTest>();
        window.Show();
    }

    private string _name = "default";
    private void OnGUI() {
        GUILayout.Label("输入GameObject名字");
        _name = GUILayout.TextField(_name);
        if (GUILayout.Button("创建")) {
            GameObject go = new GameObject(_name);
            Undo.RegisterCreatedObjectUndo(go, "create gameobject");
        }
    }
#region 窗体事件调用
    private void OnProjectChange() {
        Debug.Log("当场景改变时调用");
    }

    private void OnHierarchyChange() {
        Debug.Log("当选择对象属性改变时调用");
    }

    void OnGetFocus() {
        Debug.Log("当窗口得到焦点时调用");
    }

    private void OnLostFocus() {
        Debug.Log("当窗口失去焦点时调用");
    }

    private void OnSelectionChange() {
        Debug.Log("当改变选择不同对象时调用");
    }

    private void OnInspectorUpdate() {
        Debug.Log("监视面板调用");
    }

    private void OnDestroy() {
        Debug.Log("当窗口关闭时调用");
    }

    private void OnFocus() {
        Debug.Log("当窗口获取键盘焦点时调用");
    }
#endregion
}
