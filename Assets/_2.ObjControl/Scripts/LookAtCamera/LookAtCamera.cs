using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {


    void Start() {

    }


    void Update() {
        Debug.DrawRay(transform.position, new Vector3(1,0,0),Color.red);


        //transform.RotateAround(transform.position, new Vector3(0, 0, 0), 1);

        transform.LookAt(Camera.main.transform);
        Vector3 v3 = transform.eulerAngles;
        v3.y = 90;
        transform.eulerAngles = v3;

        //if (Vector3.Cross(transform.forward, Camera.main.transform.position).y >= 0) {
        //    Debug.Log("右");
        //} else {
        //    Debug.Log("左");
        //}

        Vector3 dir = transform.position- Camera.main.transform.position; //位置差，方向  
        if (Vector3.Dot(transform.forward, dir) >= 0) {
            //Debug.Log("左");
            v3.x = -v3.x;
            transform.eulerAngles = v3;
        } else {
            //Debug.Log("右");
            
        }
    }
}
