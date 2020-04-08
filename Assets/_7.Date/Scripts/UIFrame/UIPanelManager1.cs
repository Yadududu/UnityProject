using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanelManager1 {

    private static UIPanelManager1 _instance;
    public static UIPanelManager1 Instance {
        get {
            if (_instance == null) {
                _instance = new UIPanelManager1();
            }
            return _instance;
        }
    }
    public bool LockUI { get; set; }
    public UnityEvent OnChangeTier = new UnityEvent();
    private Dictionary<string, BaseUIPanel> panelDict = new Dictionary<string, BaseUIPanel>();
    private List<BaseUIPanel> panelList = new List<BaseUIPanel>();
    

    public void PushPanel(string panelType) {
        if (LockUI) return;
        //停止上一个界面
        if (panelList.Count > 0) {
            BaseUIPanel topPanel = panelList[panelList.Count - 1];
            topPanel.OnPause();
        }

        BaseUIPanel panel = GetPanel<BaseUIPanel>(panelType);
        panelList.Add(panel);
        panel.OnEnter();
        OnChangeTier.Invoke();
    }

    public void PopPanel(string panelType) {
        if (panelList.Count <= 0) {
            return;
        }
        BaseUIPanel panel = GetPanel<BaseUIPanel>(panelType);

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
        BaseUIPanel panel = GetPanel<BaseUIPanel>(panelType);
        if (panelList.Contains(panel)) {
            return panelList.IndexOf(panel) + 1;
        } else {
            return 0;
        }
    }

    public T GetPanel<T>(string panelType) {
        return PanelStore<T>.GetPanel(panelType);
    }

    public void RegisterPanel<T>(string panelType, T UIPanel) {
        PanelStore<T>.RegisterPanel(panelType, UIPanel);
        //panelDict[panelType] = UIPanel;
    }
}
