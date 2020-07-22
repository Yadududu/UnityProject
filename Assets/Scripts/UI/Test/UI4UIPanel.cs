using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI4UIPanel : BaseUIPanel{

    //--AutoCreateStart
	public Canvas UI4_can;
	public CanvasGroup Win_cang;
	public TextMeshProUGUI UI4_ptxt;
	public Button UI4_btn;
	//--AutoCreateEnd

    public void Awake(){
        //注册入UIPanelManager
        UIPanelManager.Instance.RegisterPanel(this.name, this);
        //添加层级管理
        UIPanelManager.Instance.OnChangeTier.AddListener(()=>UI4_can.sortingOrder = UIPanelManager.Instance.GetPanelTier(this));
        UI4_btn.onClick.AddListener(() => this.Close());
    }

    public void Start(){
        //绑定UI1
        UIPanelManager.Instance.BindParentUI(UIPanelManager.Instance.GetPanel<UI1UIPanel>("UI1"), this);
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
        UI4_can.gameObject.SetActive(true);
        Win_cang.blocksRaycasts = true;
    }
    //UI退出时执行
    public override void OnExit() {
        UI4_can.gameObject.SetActive(false);
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
