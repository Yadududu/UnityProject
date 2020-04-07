using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanelManager{

    private static UIPanelManager _instance;
    public static UIPanelManager Instance {
        get {
            if (_instance == null) {
                _instance = new UIPanelManager();
            }
            return _instance;
        }
    }
    
    public UnityEvent OnChangeTier = new UnityEvent();
    public Dictionary<string, BaseUIPanel> panelDict = new Dictionary<string, BaseUIPanel>();
    private List<BaseUIPanel> panelList = new List<BaseUIPanel>();

    public void PushPanel(string panelType) {

        //停止上一个界面
        if (panelList.Count > 0) {
            BaseUIPanel topPanel = panelList[panelList.Count-1];
            topPanel.OnPause();
        }

        BaseUIPanel panel = GetPanel(panelType);
        panelList.Add(panel);
        panel.OnEnter();
        OnChangeTier.Invoke();
    }
    
    public void PopPanel(string panelType) {
        if (panelList.Count <= 0) {
            return;
        }
        BaseUIPanel panel = GetPanel(panelType);

        //从列表中删除面板
        if (panelList.Contains(panel)) {
            panelList.Remove(panel);
            panel.OnExit();
        } else {
            return;
        }
        //恢复上一个面板
        if (panelList.Count > 0) {
            panel = panelList[panelList.Count - 1];
            panel.OnResume();
        }
        OnChangeTier.Invoke();
    }
    public int GetPanelTier(string panelType) {
        BaseUIPanel panel = GetPanel(panelType);
        if (panelList.Contains(panel)) {
            return panelList.IndexOf(panel);
        } else {
            return 0;
        }
    }

    public BaseUIPanel GetPanel(string panelType) {

        BaseUIPanel panel = null;

        if (panelDict.ContainsKey(panelType)) {
            panel = panelDict[panelType];
        }

        return panel;
    }

    public void RegisterPanel(string panelType,BaseUIPanel UIPanel) {
        if (panelDict.ContainsKey(panelType)) {
            panelDict[panelType] = UIPanel;
        } else {
            panelDict.Add(panelType, UIPanel);
        }
    }
}
