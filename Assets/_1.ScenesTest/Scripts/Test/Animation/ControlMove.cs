using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//归一化函数 normalized（）
		// Vector3 v3 = new Vector3(3, 1, 0);
        // //normalized没有改变原来向量的值
		// Vector3 res = v3.normalized;
        // Debug.Log("res = " + res);
        // Debug.Log("v3 = " + v3);
		// //normalize把v3原来的向量直接改变成标准化向量
        // v3.Normalize();
        // Debug.Log("v3 = " + v3);
	}
	
	// Update is called once per frame
	void Update () {
		//第一种移动方法
		// float input_H = Input.GetAxisRaw("Horizontal");   //获取X方向的移动方向，如果输入A，输出-1；如果输入D,输出1。
		// float input_V = Input.GetAxisRaw("Vertical");     //获取Z方向的移动方向，如果输入W，输出1；如果输入S，输出-1。
						
		// Vector3 v = new Vector3 (input_H, 0, input_V); //新建移动向量
		// v = v.normalized;                              //如果是斜线方向，需要对其进行标准化，统一长度为1
		// v = v * 10 * Time.deltaTime;                //乘以速度调整移动速度，乘以deltaTime防止卡顿现象
		// transform.Translate (v);                       //移动

		//第二种抵用方法
		float input_H = Input.GetAxisRaw("Horizontal");  //
		float input_V = Input.GetAxisRaw ("Vertical");   //
		
		transform.Rotate (new Vector3 (0, input_H, 0));   //绕y轴旋转，A键顺时针；D键逆时针
		float curSpeed = 10 * input_V * Time.deltaTime; 
		// transform.Translate (transform.forward * curSpeed,Space.World);//沿着物体前后方向移动， 由于使用了forward，因此要指定移动的坐标系为全局坐标
		transform.Translate (new Vector3(0,0,curSpeed));//默认沿着物体的z轴移动，即为前后方向

	
	}

	
}
