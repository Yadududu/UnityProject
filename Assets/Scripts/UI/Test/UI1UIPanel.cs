using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI1UIPanel : BaseUIPanel {

    public KeyCode hotKey = KeyCode.F1;
    //--AutoCreateStart
    public Canvas UI11_can;
    public CanvasGroup UI1_cang;
    public GameObject Win_go;
    public Button UI11_btn;
    public Button UI12_btn;
    public List<GameObject> Win2_gos = new List<GameObject>();
    //--AutoCreateEnd
    private KeyCode _HotKey = KeyCode.None;

    public void Awake() {
        //注册入UIPanelManager
        UIPanelManager.Instance.RegisterPanel(this.name, this);
        UIPanelManager.Instance.OnChangeTier.AddListener(() => UI11_can.sortingOrder = UIPanelManager.Instance.GetPanelTier(this));
        UI11_btn.onClick.AddListener(Close);
        UI12_btn.onClick.AddListener(() => UIPanelManager.Instance.GetPanel<UI4UIPanel>("UI4").Open());
        UIPanelManager.Instance.lockHotKeyAction += LockHotKey;
    }

    public void Start() {

    }
    public void Update() {
        if (Input.GetKeyDown(_HotKey)) {
            if (UI11_can.gameObject.activeSelf == true) {
                Close();
            } else {
                Open();
            }
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
        UI11_can.gameObject.SetActive(true);
        UI1_cang.blocksRaycasts = true;
    }
    //UI退出时执行
    public override void OnExit() {
        UI11_can.gameObject.SetActive(false);
    }
    //UI暂停时执行
    public override void OnPause() {
        UI1_cang.blocksRaycasts = false;
    }
    //UI恢复时执行
    public override void OnResume() {
        UI1_cang.blocksRaycasts = true;
    }
}