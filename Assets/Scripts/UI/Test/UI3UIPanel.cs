using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI3UIPanel : BaseUIPanel{   
    //--AutoCreateStart
	public Canvas UI3_can;
	public CanvasGroup Win_cang;
	public TextMeshProUGUI UI3_ptxt;
	public Button UI3_btn;

    //--AutoCreateEnd

    public void Awake(){
        //注册入UIPanelManager
        UIPanelManager.Instance.RegisterPanel(this.name, this);
        UIPanelManager.Instance.OnChangeTier.AddListener(()=>UI3_can.sortingOrder = UIPanelManager.Instance.GetPanelTier(this));
        UI3_btn.onClick.AddListener(Close);
    }

    public void Start(){

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
        UI3_can.gameObject.SetActive(true);
        Win_cang.blocksRaycasts = true;
    }
    //UI退出时执行
    public override void OnExit() {
        UI3_can.gameObject.SetActive(false);
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