using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class btnEvent : MonoBehaviour, IScrollHandler, ISubmitHandler, ICancelHandler, IMoveHandler {
    public void OnCancel(BaseEventData eventData) {
        Debug.Log("OnCancel");
    }

    public void OnMove(AxisEventData eventData) {
        Debug.Log("OnMove");
    }

    public void OnScroll(PointerEventData eventData) {
        Debug.Log("OnScroll");
    }

    public void OnSubmit(BaseEventData eventData) {
        Debug.Log("OnSubmit");
    }
}
