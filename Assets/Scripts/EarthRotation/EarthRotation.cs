using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotation : MonoBehaviour {
    
    void Update() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            float mouseX = Input.GetAxis("Mouse X");///对应X方向上鼠标的移动
            float mouseY = Input.GetAxis("Mouse Y");//对应Y方向上鼠标的移动
            transform.Rotate(Vector3.up, -mouseX * 10f, Space.World);
            transform.Rotate(Vector3.right, mouseY * 10f, Space.World);
        }
    }


}
