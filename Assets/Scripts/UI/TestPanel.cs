using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPanel : BaseUIPanel {

    private void Awake() {
        UIPanelManager.Instance.RegisterPanel("TestPanel", this);
    }
    void Start() {

    }
    void Update() {

    }

    public override void Open() {
        UIPanelManager.Instance.PushPanel(this.name);
    }
    public override void Close() {
        //UIPanelManager.Instance.PopPanel();
    }

    public override void OnExit() {
        throw new System.NotImplementedException();
    }

    public override void OnEnter() {
        throw new System.NotImplementedException();
    }

    public override void OnPause() {
        throw new System.NotImplementedException();
    }

    public override void OnResume() {
        throw new System.NotImplementedException();
    }
    
}
