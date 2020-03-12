using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay : MonoBehaviour {

    public Transform obj;
    public LayerMask layerMask;

    void Start() {

    }
    
    void Update() {
        //鼠标射线检测
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
        //Debug.DrawRay(ray.origin, ray.direction, Color.red);//画线
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit)) {//检测碰撞
        //    obj.transform.position = hit.point;//获取射线在物体上的坐标
        //}

        //在物体身上发送射线
        Ray ray = new Ray(obj.position, Vector3.forward);//在物体身上发出射线
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,Mathf.Infinity,layerMask)) {//检测碰撞
            Debug.DrawLine(ray.origin, hit.point,Color.red);//画线
            Debug.Log(hit.transform.name);
        }
        //在物体身上发送射线
        //RaycastHit hit;
        //if (Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 1000)) {
        //    Debug.Log(hit.transform.name);
        //    Debug.DrawLine(obj.transform.position, hit.point, Color.red);
        //}

        //可以穿透
        //RaycastHit[] hits = Physics.RaycastAll(obj.position, obj.forward);
        //Debug.DrawRay(obj.position, obj.forward, Color.red);
        //foreach (RaycastHit h in hits) {
        //    Debug.Log(h.transform.name);
        //}
    }
}
