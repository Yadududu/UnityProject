﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject_2 : MonoBehaviour {

	public GameObject GObject;

	//相机距离人物高度
	float m_Height = 2f;
	//相机距离人物距离
	float m_Distance = 8f;
	//相机跟随速度
	float m_Speed = 4f;
	//目标位置
	Vector3 m_TargetPosition;
	//要跟随的人物
	Transform follow;

	// Use this for initialization
	void Start () {
		follow = GObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//得到这个目标位置
		m_TargetPosition = follow.position + Vector3.up * m_Height - follow.forward * m_Distance;
		//相机位置
		transform.position = Vector3.Lerp (transform.position, m_TargetPosition, m_Speed * Time.deltaTime);
		//相机时刻看着人物
		transform.LookAt (follow);
	}
}
