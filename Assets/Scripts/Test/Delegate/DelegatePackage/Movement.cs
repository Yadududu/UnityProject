using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SetHand();

public class Movement : MonoBehaviour {

    public static SetHand SetHandGrid;
    public static SetHand SetHandUnGrid;

	void Awake () {
        SetHandGrid = OnGrid;
        SetHandUnGrid = UnGrid;
	}

    void OnGrid() {
        Debug.Log("捡起:");
    }
    void UnGrid() {
        Debug.Log("放下:");
    }
}
