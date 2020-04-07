using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour {
    public bool boo;

    void Start() {
        //UIPanelManager.Instance.GetPanel("UI1").Win_go
        //UI1UIPanel ui1 = UIPanelManager.Instance.GetPanel("UI1") as UI1UIPanel;
    }
    
    void Update() {
        if (boo) {
            UIPanelManager.Instance.LockUI = boo;
        }
        if (Input.GetKeyDown(KeyCode.F1)) {
            UI1UIPanel ui1 = UIPanelManager.Instance.GetPanel("UI1") as UI1UIPanel;
            if (ui1.Win_go.activeInHierarchy) {
                ui1.Close();
            } else {
                ui1.Open();
            }
        }
        if (Input.GetKeyDown(KeyCode.F2)) {
            UI2UIPanel ui2 = UIPanelManager.Instance.GetPanel("UI2") as UI2UIPanel;
            if (ui2.Win_go.activeInHierarchy) {
                ui2.Close();
            } else {
                ui2.Open();
            }
        }
        if (Input.GetKeyDown(KeyCode.F3)) {
            UI3UIPanel ui3 = UIPanelManager.Instance.GetPanel("UI3") as UI3UIPanel;
            if (ui3.Win_go.activeInHierarchy) {
                ui3.Close();
            } else {
                ui3.Open();
            }
        }
    }

    void OnEnable() {
        //Debug.Log(UIPanelManager.Instance.panelDict.Count);

        //foreach (string b in UIPanelManager.Instance.panelDict.Keys) {
        //    Debug.Log(b);
        //}
        //foreach (BaseUIPanel b in UIPanelManager.Instance.panelDict.Values) {
        //    Debug.Log(b);
        //}
    }
}
