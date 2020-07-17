using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PanelStore<T> {

    private static Dictionary<string, T> panelDict = new Dictionary<string, T>();

    public static T GetPanel(string panelType) {

        T panel = default(T);

        if (panelDict.ContainsKey(panelType)) {
            panel = panelDict[panelType];
        } else {
            throw new System.Exception("找不到名为(" + panelType + ")的UI");
        }

        return panel;
    }

    public static void RegisterPanel(string panelType, T UIPanel) {

        if (!panelDict.ContainsKey(panelType)) {
            panelDict[panelType] = UIPanel;
        } else {
            throw new System.Exception("该(" + panelType + ")UI已经注册");
        }
    }
}
