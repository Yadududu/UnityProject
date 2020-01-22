using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableWizardTest : ScriptableWizard {

    [MenuItem("Tools/TestWizard")]
    static void CreateWizard() {
        ScriptableWizard.DisplayWizard<ScriptableWizardTest>("统一修改", "Change And Close", "Change");
    }

    public int changeI_Value = 10;
    const string changeI_ValueValueKey = "ContextMenuItemText.i";

    //当窗口被创建出来的时候调用的
    void OnEnable() {
        changeI_Value = EditorPrefs.GetInt(changeI_ValueValueKey, changeI_Value);
    }
    //检测create按钮的点击
    void OnWizardCreate() {
        GameObject[] prefabs = Selection.gameObjects;
        EditorUtility.DisplayProgressBar("进度", "0/" + prefabs.Length + " 完成修改值", 0);
        int count = 0;
        foreach (GameObject go in prefabs) {
            ContextMenuItemText CMIT = go.GetComponent<ContextMenuItemText>();
            Undo.RecordObject(CMIT, "change health and speed");
            CMIT.i += changeI_Value;
            count++;
            EditorUtility.DisplayProgressBar("进度", count + "/" + prefabs.Length + " 完成修改值", (float)count / prefabs.Length);
        }
        EditorUtility.ClearProgressBar();
        ShowNotification(new GUIContent(Selection.gameObjects.Length + "个游戏物体的值被修改了"));
    }

    //当前字段值修改的时候会被调用
    void OnWizardUpdate() {
        errorString = null;
        helpString = null;
        if (Selection.gameObjects.Length > 0) {
            helpString = "您当前选择了" + Selection.gameObjects.Length + "个Prefabs";
        } else {
            errorString = "请选择至少一个Prefabs";
        }
        //保存上一次输入的数值
        EditorPrefs.SetInt(changeI_ValueValueKey, changeI_Value);
    }
    void OnSelectionChange() {
        OnWizardUpdate();
    }
    void OnWizardOtherButton() {
        OnWizardCreate();
    }
}
