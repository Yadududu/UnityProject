using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 实现从带有碰撞器的物体到鼠标移动点之间划线
/// </summary>
public class m_touch : MonoBehaviour {
    public Material mat;                        //材质球
    private GameObject go;                     //鼠标检测到的物体         
    private Vector3 pos1;                      //顶点一
    private Vector3 pos2;                      //顶点二
    private bool isReady = false;               //鼠标点是否有新输入
    private bool isFindGo = false;              //是否找到物体

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                go = hit.collider.gameObject;
                if (go.name == "Cube") {
                    //将点击到的物体世界坐标转为屏幕坐标
                    Vector2 screenPos1 = Camera.main.WorldToScreenPoint(go.transform.position);
                    pos1 = new Vector3(screenPos1.x, screenPos1.y, 0);
                    isFindGo = true;
                    Debug.Log("aa");
                } else if (go.name == "Sphere") {
                    Vector2 screenPos1 = Camera.main.WorldToScreenPoint(go.transform.position);
                    pos1 = new Vector3(screenPos1.x, screenPos1.y, 0);
                    isFindGo = true;
                }
            }

        }
        //输入第二个点
        if (Input.GetMouseButton(0) && isFindGo) {
            pos2 = Input.mousePosition;
            isReady = true;
        }
    }
    /// <summary>
    /// 划线
    /// </summary>
    void OnPostRender() {
        if (isFindGo && isReady) {
            GL.PushMatrix();
            mat.SetPass(0);
            GL.LoadOrtho();
            GL.Begin(GL.LINES);
            GL.Color(Color.black);
            Debug.Log(pos1);
            GL.Vertex3(pos1.x / Screen.width, pos1.y / Screen.height, pos1.z);
            GL.Vertex3(pos2.x / Screen.width, pos2.y / Screen.height, pos2.z);
            Debug.Log(pos2);
            GL.End();
            GL.PopMatrix();
        }
    }

}