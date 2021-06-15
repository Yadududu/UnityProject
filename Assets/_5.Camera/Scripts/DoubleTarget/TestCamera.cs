using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour {

    void Start() {
       
    }
    
    void Update() {
        Debug.Log(Camera.main.aspect);
    }
}
