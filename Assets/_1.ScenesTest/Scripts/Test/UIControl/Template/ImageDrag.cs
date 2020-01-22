using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageDrag : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler {

    public Direction direction;
    public PullPosition pullStript;

    private FixPosition fp;
    private RectTransform rect;
    private Vector2 v2;

    private void Start() {
        fp = GetComponent<FixPosition>();
        rect = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData) {
        
    }

    public void OnDrag(PointerEventData eventData) {
        if (fp != null) fp.enabled = false;
        switch (direction) {
            case Direction.Center:
                rect.anchoredPosition += eventData.delta;
                break;
            case Direction.Down:
                v2 = eventData.delta;
                v2.x = 0;
                rect.anchoredPosition += v2;
                pullStript.Db = true;
                break;
            case Direction.Left:
                v2 = eventData.delta;
                v2.y = 0;
                rect.anchoredPosition += v2;
                pullStript.Lb = true;
                break;
            case Direction.Right:
                v2 = eventData.delta;
                v2.y = 0;
                rect.anchoredPosition += v2;
                pullStript.Rb = true;
                break;
            case Direction.Top:
                v2 = eventData.delta;
                v2.x = 0;
                rect.anchoredPosition += v2;
                pullStript.Tb = true;
                break;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (fp != null) fp.enabled = true;
        pullStript.init();
    }

    public void OnInitializePotentialDrag(PointerEventData eventData) {
       
    }
}
