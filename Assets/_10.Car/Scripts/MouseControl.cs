using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car {
    public class MouseControl : MonoBehaviour {

        private void Update() {

            if (Input.GetAxis("Mouse ScrollWheel") != 0) {
                float fov = Camera.main.fieldOfView;
                fov += Input.GetAxis("Mouse ScrollWheel") * 30;
                fov = Mathf.Clamp(fov, 20, 90);
                Camera.main.fieldOfView = fov;
            }

            if (Input.GetKey(KeyCode.Mouse1)) {
                float mouseX = Input.GetAxis("Mouse X");
                transform.Rotate(Vector3.up, -mouseX * 10f, Space.World);
            }
        }
    }
}

