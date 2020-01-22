using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickEventImpl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("OnPointerClick:" + eventData.clickTime);
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown:" + eventData.clickTime);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("OnPointerExit");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("OnPointerUp");
    }
    
}
