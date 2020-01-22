using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationWindow : MonoBehaviour {

    public GameObject parfab;

    void Start() {

    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(parfab, transform);
        }
    }
}
