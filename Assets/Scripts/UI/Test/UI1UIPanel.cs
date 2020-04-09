using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI1UIPanel : BaseUIPanel {

    public Canvas Canvas;
    public CanvasGroup CanvasGroup;
    //--AutoCreateStart
	public Canvas UI1_can;
	public GameObject Win_go;
	public Button UI11_btn;
	public Button UI12_btn;
	public List<GameObject> Win2_gos = new List<GameObject>();
	//--AutoCreateEnd

    public void Awake() {
        //UIPanelManager.Instance.RegisterPanel(this.name, GetComponent<UI1UIPanel>());
        PanelStore<UI1UIPanel>.RegisterPanel(this.name, GetComponent<UI1UIPanel>());
        UIPanelManager.Instance.OnChangeTier.AddListener(ChangeTier);
        UI11_btn.onClick.AddListener(Close);
        
    }

    public void Start() {

    }
    public void print() {
        Debug.Log("我是方法1");
    }

    public void Open(string str) {
        Debug.Log(str);
        UIPanelManager.Instance.PushPanel(this);
    }
    public override void Close() {
        UIPanelManager.Instance.PopPanel(this);
    }
    private void ChangeTier() {
        Canvas.sortingOrder = UIPanelManager.Instance.GetPanelTier(this);
    }
    public override void OnEnter() {
        Win_go.SetActive(true);
        CanvasGroup.blocksRaycasts = true;
    }

    public override void OnExit() {
        Win_go.SetActive(false);
    }

    public override void OnPause() {
        CanvasGroup.blocksRaycasts = false;
    }

    public override void OnResume() {
        CanvasGroup.blocksRaycasts = true;
    }
    
}

















