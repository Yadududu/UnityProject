using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Car{
    public enum State {
        General,
        UnInstall,
        Install
    }
    public class HandInstall : MonoBehaviour {

        public List<Wheel> wheels;
        public List<SphereCollider> triggers;

        private State _State = State.General;
        private bool _BtnAutoInstallState = false;
        private List<Wheel> _WheelState = new List<Wheel>();

        private void Start() {
            UIControl.Get.btnUnInstall.onClick.AddListener(UnInstall);
            UIControl.Get.btnInstall.onClick.AddListener(Install);
            foreach (Wheel wheel in wheels) {
                wheel.onSuccess += Check;
            }
        }

        private void UnInstall() {
            UIControl.Get.textTitle.text = "拆卸模式";
            UIControl.Get.textTitle.enabled = true;
            foreach (Wheel wheel in wheels) {
                wheel.state = State.UnInstall;
                wheel.initSign = true;
                _State = State.UnInstall;
            }
            _BtnAutoInstallState = UIControl.Get.btnAutoInstall.interactable;
            UIControl.Get.AllBtnState(false);
            _WheelState.Clear();
        }
        private void Install() {
            UIControl.Get.textTitle.text = "组装模式";
            UIControl.Get.textTitle.enabled = true;
            foreach (Wheel wheel in wheels) {
                wheel.state = State.Install;
                wheel.initSign = true;
                _State = State.Install;
            }
            foreach (SphereCollider trigger in triggers) {
                trigger.enabled = true;
            }
            _BtnAutoInstallState = UIControl.Get.btnAutoInstall.interactable;
            UIControl.Get.AllBtnState(false);
            _WheelState.Clear();
        }

        private void Check(Wheel wheel) {
            if (!_WheelState.Contains(wheel)) {
                _WheelState.Add(wheel);
            }
            if (_WheelState.Count == wheels.Count) {
                if (_State == State.UnInstall) {
                    Success("拆卸完成");
                } else if (_State == State.Install) {
                    Success("组装完成");
                }
            }
        }
        private void Success(string tipContent) {
            UITip.Get.Open(tipContent);
            UIControl.Get.textTitle.enabled = false;
            foreach (Wheel wheel in wheels) {
                wheel.state = State.General;
            }
            if (_BtnAutoInstallState) {
                UIControl.Get.AllBtnState(true, UIControl.Get.btnAutoUnInstall);
            } else {
                UIControl.Get.AllBtnState(true, UIControl.Get.btnAutoInstall);
            }
        }
    }
}
