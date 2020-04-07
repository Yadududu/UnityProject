using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour {


    void Start() {
        //UIPanelManager.Instance.GetPanel("UI1").Win_go
        //UI1UIPanel ui1 = UIPanelManager.Instance.GetPanel("UI1") as UI1UIPanel;
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            if ((UIPanelManager.Instance.GetPanel("UI1") as UI1UIPanel).Win_go.activeInHierarchy) {
                (UIPanelManager.Instance.GetPanel("UI1") as UI1UIPanel).Close();
            } else {
                (UIPanelManager.Instance.GetPanel("UI1") as UI1UIPanel).Open();
            }
        }
        if (Input.GetKeyDown(KeyCode.F2)) {
            if ((UIPanelManager.Instance.GetPanel("UI2") as UI2UIPanel).Win_go.activeInHierarchy) {
                (UIPanelManager.Instance.GetPanel("UI2") as UI2UIPanel).Close();
            } else {
                (UIPanelManager.Instance.GetPanel("UI2") as UI2UIPanel).Open();
            }
        }
        if (Input.GetKeyDown(KeyCode.F3)) {
            if ((UIPanelManager.Instance.GetPanel("UI3") as UI3UIPanel).Win_go.activeInHierarchy) {
                (UIPanelManager.Instance.GetPanel("UI3") as UI3UIPanel).Close();
            } else {
                (UIPanelManager.Instance.GetPanel("UI3") as UI3UIPanel).Open();
            }
        }
    }

    void OnEnable() {
        Debug.Log(UIPanelManager.Instance.panelDict.Count);

        foreach (string b in UIPanelManager.Instance.panelDict.Keys) {
            Debug.Log(b);
        }
        foreach (BaseUIPanel b in UIPanelManager.Instance.panelDict.Values) {
            Debug.Log(b);
        }
    }
}
