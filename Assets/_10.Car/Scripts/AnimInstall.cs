using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Car {
    public class AnimInstall : MonoBehaviour {

        public Animator animator;

        private void Start() {

            UIControl.Get.btnAutoUnInstall.onClick.AddListener(UnInstallAnim);
            UIControl.Get.btnAutoUnInstall.interactable = true;
            UIControl.Get.btnAutoInstall.onClick.AddListener(InstallAnim);
            UIControl.Get.btnAutoInstall.interactable = false;
        }

        private void InstallAnim() {
            animator.enabled = true;
            animator.SetBool("State", false);
            StartCoroutine(CloseAnim(UIControl.Get.btnAutoInstall));
            UIControl.Get.AllBtnState(false);
        }

        private void UnInstallAnim() {
            animator.enabled = true;
            animator.SetBool("State", true);
            StartCoroutine(CloseAnim(UIControl.Get.btnAutoUnInstall));
            UIControl.Get.AllBtnState(false);
        }

        private IEnumerator CloseAnim(Button btn) {
            yield return new WaitForSeconds(1);
            animator.enabled = false;
            UIControl.Get.AllBtnState(true, btn);
        }
    }
}

