using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour {
    
    void Update() {
        
        Vector3 dir = transform.position - Camera.main.transform.position; //位置差，方向  
        if (Vector3.Dot(transform.forward, dir) >= 0) {
            Debug.Log("左边");
        } else {
            Debug.Log("右边");
        } 

        if (Vector3.Cross(transform.forward, Camera.main.transform.position).z >= 0) {
            Debug.Log("上");
        } else {
            Debug.Log("下");
        }

        if (Vector3.Cross(transform.forward, Camera.main.transform.position).y >= 0) {
            Debug.Log("后");
        } else {
            Debug.Log("前");
        }

        //计算向量夹角
        Vector3 dirA = transform.forward;
        Vector3 dirB = Camera.main.transform.position;
        //1.使向量处于同一个平面，这里平面为XZ
        dirA = dirA - Vector3.Project(dirA, Vector3.up);
        dirB = dirB - Vector3.Project(dirB, Vector3.up);
        //注: Vector3.Project计算向量在指定轴上的投影，向量本身减去此投影向量就为在平面上的向量
        //2.计算角度
        float angle = Vector3.Angle(dirA, dirB);
        //4.计算方向
        float dir1 = (Vector3.Dot(Vector3.up, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
        angle *= dir1;
        Debug.Log(angle);


    }
}
