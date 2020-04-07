using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI1UIPanel : BaseUIPanel {

    public Canvas Canvas;
    public CanvasGroup CanvasGroup;
    //--AutoCreateStart
    public GameObject Win_go;
	public Button UI11_btn;
	public Button UI12_btn;
	//--AutoCreateEnd

    public void Awake() {
        UIPanelManager.Instance.RegisterPanel(this.name, GetComponent<UI1UIPanel>());
        UIPanelManager.Instance.OnChangeTier.AddListener(ChangeTier);
        UI11_btn.onClick.AddListener(Close);
    }

    public void Start() {

    }

    public void Open() {
        UIPanelManager.Instance.PushPanel(this.name);
    }
    public void Close() {
        UIPanelManager.Instance.PopPanel(this.name);
    }
    private void ChangeTier() {
        Canvas.sortingOrder = UIPanelManager.Instance.GetPanelTier(this.name);
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


