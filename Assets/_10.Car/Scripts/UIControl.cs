using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Car {
    public class UIControl : MonoBehaviour {

        public static UIControl Get { get; private set; }

        public Text textTitle;
        public Button btnAutoUnInstall;
        public Button btnAutoInstall;
        public Button btnUnInstall;
        public Button btnInstall;

        private UIControl() {

        }
        private void Awake() {
            Get = this;
        }

        public void AllBtnState(bool interactable) {
            btnAutoUnInstall.interactable = interactable;
            btnAutoInstall.interactable = interactable;
            btnUnInstall.interactable = interactable;
            btnInstall.interactable = interactable;
        }
        public void AllBtnState(bool interactable, Button exceptBtn) {
            if (exceptBtn != btnAutoUnInstall) btnAutoUnInstall.interactable = interactable;
            if (exceptBtn != btnAutoInstall) btnAutoInstall.interactable = interactable;
            if (exceptBtn != btnUnInstall) btnUnInstall.interactable = interactable;
            if (exceptBtn != btnInstall) btnInstall.interactable = interactable;
        }
    }
}

