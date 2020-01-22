using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction {
    Center,
    Left,
    Right,
    Top,
    Down
}

public class FixPosition : MonoBehaviour {

    public Direction direction;
    public RectTransform Parent;

    private RectTransform self;
    private Vector2 v2;
    private Vector3 v3;
    private float x;
    private float y;

    void Start() {
        self = GetComponent<RectTransform>();
    }


    void Update() {

        switch (direction) {
            case Direction.Left:
                x = -(Parent.sizeDelta.x/2 - Parent.localPosition.x - 5);
                y = Parent.localPosition.y;
                v3 = new Vector3(x, y, 0);
                self.localPosition = v3;

                v2 = new Vector2(self.sizeDelta.x, Parent.sizeDelta.y);
                self.sizeDelta = v2;
                break;
            case Direction.Right:
                x = Parent.sizeDelta.x / 2 + Parent.localPosition.x - 5;
                y = Parent.localPosition.y;
                v3 = new Vector3(x, y, 0);
                self.localPosition = v3;

                v2 = new Vector2(self.sizeDelta.x, Parent.sizeDelta.y);
                self.sizeDelta = v2;
                break;
            case Direction.Top:
                x = Parent.localPosition.x;
                y = Parent.sizeDelta.y / 2 + Parent.localPosition.y - 5;
                v3 = new Vector3(x, y, 0);
                self.localPosition = v3;

                v2 = new Vector2(Parent.sizeDelta.x, self.sizeDelta.y);
                self.sizeDelta = v2;
                break;
            case Direction.Down:
                x = Parent.localPosition.x;
                y = -(Parent.sizeDelta.y / 2 - Parent.localPosition.y - 5);
                v3 = new Vector3(x, y, 0);
                self.localPosition = v3;

                v2 = new Vector2(Parent.sizeDelta.x, self.sizeDelta.y);
                self.sizeDelta = v2;
                break;
        }
    }
}
