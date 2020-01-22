using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler {
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");

        //var rect = GetComponent<RectTransform>();
        //Vector3 pos = Vector3.zero;
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.enterEventCamera, out pos);
        //rect.position = pos;

        var rect = transform.GetComponent<RectTransform>();
        rect.anchoredPosition += eventData.delta;
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
    }

    public void OnInitializePotentialDrag(PointerEventData eventData) {
        Debug.Log("OnInitializePotentialDrag");
    }
}
