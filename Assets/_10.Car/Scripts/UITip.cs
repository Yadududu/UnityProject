using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Car {
    public class UITip : MonoBehaviour {

        public static UITip Get { get; private set; }

        public GameObject win;
        public Text tip;
        public Button btnComfirm;

        private UITip() {

        }
        private void Awake() {
            Get = this;
            btnComfirm.onClick.AddListener(Close);
        }
        public void Open(string tipContent) {
            tip.text = tipContent;
            win.SetActive(true);
        }
        public void Close() {
            win.SetActive(false);
        }
    }
}

