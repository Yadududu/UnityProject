﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackgroundUIPanel : BaseUIPanel {

    public Canvas Canvas;
    public CanvasGroup CanvasGroup;
    //--AutoCreateStart
    public GameObject Win_go;
	public TextMeshProUGUI Background_ptxt;
	public Button Background_btn;
	//--AutoCreateEnd

    public void Awake(){
        UIPanelManager.Instance.RegisterPanel(this.name, this);
        UIPanelManager.Instance.OnChangeTier.AddListener(ChangeTier);
        Open();
    }
    public void Start() {

    }
    public override void Open() {
        UIPanelManager.Instance.PushPanel(this.name);
    }
    public override void Close() {
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


