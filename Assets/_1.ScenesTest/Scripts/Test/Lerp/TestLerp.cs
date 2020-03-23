using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLerp : MonoBehaviour {

    void Start() {

    }
    
    void Update() {
        if (transform.position.z<10) {
            //插值先加速后减速
            transform.Translate(transform.forward * Time.deltaTime * (transform.position.z<5? Mathf.Lerp(1,10,transform.position.z/5): Mathf.Lerp(10, 1, (transform.position.z-5) / 5)));
            Debug.Log(transform.position.z < 5 ? Mathf.Lerp(1, 10, transform.position.z / 5) : Mathf.Lerp(10, 1, (transform.position.z - 5) / 5));
        }
        
    }
}
