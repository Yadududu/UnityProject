using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIPanelManager {

    private static UIPanelManager _instance;
    public static UIPanelManager Instance {
        get {
            if (_instance == null) {
                _instance = new UIPanelManager();
            }
            return _instance;
        }
    }

    public UnityAction<bool> lockHotKeyAction;
    public UnityEvent OnChangeTier = new UnityEvent();
    private List<BaseUIPanel> panelList = new List<BaseUIPanel>();
    private Dictionary<BaseUIPanel, List<BaseUIPanel>> bindDic = new Dictionary<BaseUIPanel, List<BaseUIPanel>>();

    /*
     * 开关快捷键
     * **/
    public void LockHotKey(bool b) {
        if (lockHotKeyAction != null) lockHotKeyAction.Invoke(b);
    }

    /*
     * 层级管理，加入UI排序
     * **/
    public void PushPanel(BaseUIPanel panel) {
        
        //如果队列中没有该UI则加入队列
        if (!panelList.Contains(panel)) {
            //停止上一个界面
            if (panelList.Count > 0) {
                BaseUIPanel topPanel = panelList[panelList.Count - 1];
                topPanel.OnPause();
            }
            panelList.Add(panel);
            panel.OnEnter();
            OnChangeTier.Invoke();
        }
    }

    /*
     * 层级管理，弹出UI
     * **/
    public void PopPanel(BaseUIPanel panel) {
        if (panelList.Count <= 0) {
            return;
        }

        //从列表中删除面板
        if (panelList.Contains(panel)) {
            //判断是否有绑定子UI
            if (bindDic.ContainsKey(panel)) {
                foreach(BaseUIPanel bp in bindDic[panel]){
                    if (panelList.Contains(bp)) {
                        panelList.Remove(bp);
                        bp.OnExit();
                    }
                }
            }

            panelList.Remove(panel);
            panel.OnExit();
        } else {
            return;
        }
        //恢复上一个面板
        if (panelList.Count > 0) {
            panel = panelList[panelList.Count - 1];
            panel.OnResume();
            //Debug.Log(panel.name);
        }
        OnChangeTier.Invoke();
    }

    /*
     * 注册进这里的UI可以做层级管理
     * **/
    public int GetPanelTier(BaseUIPanel panel) {

        if (panelList.Contains(panel)) {
            return panelList.IndexOf(panel) + 1;
        } else {
            return 0;
        }
    }

    /*
     * 绑定一个父对象UI，父UI关闭时，子UI跟着关闭
     * **/
    public void BindParentUI(BaseUIPanel parentPanel, BaseUIPanel panel) {
        if (bindDic.ContainsKey(parentPanel)) {
            bindDic[parentPanel].Add(panel);
        } else {
            bindDic.Add(parentPanel, new List<BaseUIPanel>());
            bindDic[parentPanel].Add(panel);
        }
    }

    /*
     * 获取UI
     * **/
    public T GetPanel<T>(string panelType) {
        return PanelStore<T>.GetPanel(panelType);
    }

    /*
     * 注册UI
     * **/
    public void RegisterPanel<T>(string panelType, T UIPanel) {
        PanelStore<T>.RegisterPanel(panelType, UIPanel);
    }
}
