using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDropObj : MonoBehaviour {

    private string objName;
    private bool sign;

    void Start() {
        objName = gameObject.name;
    }
    
    void Update() {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.GetPoint(100), Color.red);

        //射线是否接触碰撞体
        if (Physics.Raycast(ray, out hit)) {
            //判断碰撞体单一性,不会同时拾取多个物体
            if (hit.transform.gameObject.name == objName) {
                //判断是否点击鼠标左键
                if (Input.GetMouseButtonDown(0)) {
                    sign = true;
                }
            }
        }
        //判断是否鼠标左键抬起
        if (Input.GetMouseButtonUp(0)) {
            sign = false;
        }
        if (sign) {
            Vector3 v3 = transform.position - Camera.main.transform.position;
            float distance = Vector3.Dot(v3, Camera.main.transform.forward);
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        }
    }
}
