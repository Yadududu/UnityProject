using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RLD;

public class Test : MonoBehaviour {
    
    //// Use this for initialization
    //void Start () {
    //    //得到MeshFilter对象，目前是空的。
    //    MeshFilter meshFilter = (MeshFilter)GameObject.Find("face").GetComponent(typeof(MeshFilter));
    //    //得到对应的网格对象
    //    Mesh mesh = meshFilter.mesh;
 
    //    //三角形顶点的坐标数组
    //    Vector3[] vertices = new Vector3[3];
    //    //三角形顶点ID数组
    //    int[] triangles   = new int[3];
 
    //    //三角形三个定点坐标，为了显示清楚忽略Z轴
    //    vertices[0] = new Vector3(0,0,0);
    //    vertices[1] = new Vector3(0,1,0);
    //    vertices[2] = new Vector3(1,0,0);
 
    //    //三角形绘制顶点的数组
    //    triangles[0] =0;
    //    triangles[1] =1;
    //    triangles[2] =2;
 
    //    //注释1
    //    mesh.vertices = vertices;
 
    //    mesh.triangles = triangles;
    //}

    //网格模型顶点数量
    private int VERTICES_COUNT = 6;

    void Start() {
        //得到MeshFilter对象，目前是空的。
        MeshFilter meshFilter = (MeshFilter)GameObject.Find("face").GetComponent(typeof(MeshFilter));
        //得到对应的网格对象
        Mesh mesh = meshFilter.mesh;

        //三角形顶点的坐标数组
        Vector3[] vertices = new Vector3[VERTICES_COUNT];

        //得到三角形的数量
        int triangles_count = VERTICES_COUNT - 2;

        //三角形顶点ID数组
        int[] triangles = new int[triangles_count * 3];

        //三角形三个定点坐标，为了显示清楚忽略Z轴
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, 1, 0);
        vertices[2] = new Vector3(1, 0, 0);
        vertices[3] = new Vector3(1, 1, 0);
        vertices[4] = new Vector3(2, 0, 0);
        vertices[5] = new Vector3(2, 1, 0);

        //绘制三角形
        mesh.vertices = vertices;

        //起始三角形顶点
        int start = 0;

        //结束三角形的顶点
        int end = 4;

        for (int i = start; i < end; i++) {
            for (int j = 0; j < 3; j++) {
                if (i % 2 == 0) {
                    triangles[3 * i + j] = i + j;
                } else {
                    triangles[3 * i + j] = i + 2 - j;
                }

            }
        }

        mesh.triangles = triangles;
    }


	// Update is called once per frame
	void Update () {
        
	}
}
