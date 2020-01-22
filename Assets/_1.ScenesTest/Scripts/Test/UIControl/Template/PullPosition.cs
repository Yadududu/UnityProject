using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPosition : MonoBehaviour {

    public RectTransform Right;
    public RectTransform Left;
    public RectTransform Top;
    public RectTransform Down;

    [HideInInspector]
    public bool Rb = false;
    [HideInInspector]
    public bool Lb = false;
    [HideInInspector]
    public bool Tb = false;
    [HideInInspector]
    public bool Db = false;
    
    private float Rx;
    private float Lx;
    private float Ty;
    private float Dy;
    private RectTransform source;

    void Start() {
        source = GetComponent<RectTransform>();
        init();
    }
    public void init() {
        Rx = Right.localPosition.x;
        Lx = Left.localPosition.x;
        Ty = Top.localPosition.y;
        Dy = Down.localPosition.y;
        Rb = false;
        Lb = false;
        Tb = false;
        Db = false;
    }

    void Update() {

        if (Rb) {
            Vector3 v3 = source.localPosition;
            float x = Right.localPosition.x - Rx;
            v3.x = source.localPosition.x + (x / 2);
            source.localPosition = v3;

            source.sizeDelta = new Vector2(source.sizeDelta.x + x, source.sizeDelta.y);

            Rx = Right.localPosition.x;
        }
        if (Lb) {
            Vector3 v3 = source.localPosition;
            float x = Left.localPosition.x - Lx;
            v3.x = source.localPosition.x + (x / 2);
            source.localPosition = v3;

            source.sizeDelta = new Vector2(source.sizeDelta.x - x, source.sizeDelta.y);

            Lx = Left.localPosition.x;
        }
        if (Tb) {
            Vector3 v3 = source.localPosition;
            float y = Top.localPosition.y - Ty;
            v3.y = source.localPosition.y + (y / 2);
            source.localPosition = v3;

            source.sizeDelta = new Vector2(source.sizeDelta.x, source.sizeDelta.y + y);

            Ty = Top.localPosition.y;
        }
        if (Db) {
            Vector3 v3 = source.localPosition;
            float y = Down.localPosition.y - Dy;
            v3.y = source.localPosition.y + (y / 2);
            source.localPosition = v3;

            source.sizeDelta = new Vector2(source.sizeDelta.x, source.sizeDelta.y - y);

            Dy = Down.localPosition.y;
        }
    }
}
