using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectDel : MonoBehaviour, ISelectHandler, IDeselectHandler, IUpdateSelectedHandler {

    public void OnDeselect(BaseEventData eventData) {
        //Debug.Log("OnDeselect");
    }

    public void OnSelect(BaseEventData eventData) {
        //Debug.Log("OnSelect");
    }

    public void OnUpdateSelected(BaseEventData eventData) {
        //Debug.Log("OnUpdateSelected");
        if (Input.GetKeyDown(KeyCode.Delete)) {
            Destroy(gameObject);
        }
    }
}
