using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI2UIPanel : BaseUIPanel{

    public KeyCode hotKey = KeyCode.F2;
    //--AutoCreateStart
    public Canvas UI2_can;
	public CanvasGroup Win_cang;
	public Button UI2_btn;
    //--AutoCreateEnd
    private KeyCode _HotKey = KeyCode.None;

    public void Awake(){
        //注册入UIPanelManager
        UIPanelManager.Instance.RegisterPanel(this.name, this);
        //添加层级管理
        UIPanelManager.Instance.OnChangeTier.AddListener(()=>UI2_can.sortingOrder = UIPanelManager.Instance.GetPanelTier(this));
        UI2_btn.onClick.AddListener(Close);
        //添加快捷键管理
        UIPanelManager.Instance.lockHotKeyAction += LockHotKey;
    }

    public void Start(){

    }
    public void Update() {
        if (Input.GetKeyDown(_HotKey)) {
            Open();
        }
    }
    public void LockHotKey(bool b) {
        if (b) {
            _HotKey = KeyCode.None;
        } else {
            _HotKey = hotKey;
        }
    }
    public void Open() {
        //加入队列
        UIPanelManager.Instance.PushPanel(this);
    }
    public override void Close() {
        //跳出队列
        UIPanelManager.Instance.PopPanel(this);
    }
    //UI启动时执行
    public override void OnEnter() {
        UI2_can.gameObject.SetActive(true);
        Win_cang.blocksRaycasts = true;
    }
    //UI退出时执行
    public override void OnExit() {
        UI2_can.gameObject.SetActive(false);
    }
    //UI暂停时执行
    public override void OnPause() {
        Win_cang.blocksRaycasts = false;
    }
    //UI恢复时执行
    public override void OnResume() {
        Win_cang.blocksRaycasts = true;
    }
}