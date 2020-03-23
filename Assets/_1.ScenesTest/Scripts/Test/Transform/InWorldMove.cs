using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWorldMove : MonoBehaviour {

    public Transform child;
    private float f;

    void Start() {
        //一开始tr的z与世界坐标重合,否则都要使用tr.TransformDirection(Vector3.forward).z先转换为世界坐标再运算
        f = child.position.z;
    }

    void Update() {

        if (transform.eulerAngles.y < 90) {
            transform.Rotate(transform.up * Time.deltaTime * 50);
        } else if (transform.position.z > -10) {
            transform.Translate(transform.forward * Time.deltaTime * 10);
        } else {
            //position算出的是自身坐标(忽略父对象)的位移
            Debug.Log(child.position.z - f);
            //是以世界坐标(永远不动的坐标)为参考作位移
            Debug.Log(child.TransformDirection(Vector3.forward).z - f);
        }
    }
}
