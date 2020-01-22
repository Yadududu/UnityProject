using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotation : MonoBehaviour {
    
    void Update() {
        //物体旋转
        if (Input.GetKey(KeyCode.Mouse1)) {
            float mouseX = Input.GetAxis("Mouse X");//对应X方向上鼠标的移动
            float mouseY = Input.GetAxis("Mouse Y");//对应Y方向上鼠标的移动
            transform.Rotate(Vector3.up, -mouseX * 10f, Space.World);
            transform.Rotate(Vector3.right, mouseY * 10f, Space.World);
        }
        //摄像机缩放
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * 30;
            fov = Mathf.Clamp(fov, 10, 90);
            Camera.main.fieldOfView = fov;
        }
    }


}
