using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject_1 : MonoBehaviour {


	public GameObject GObject;
	Vector3 TargetPotint;

	// Use this for initialization
	void Start () {
		TargetPotint=new Vector3(0f,2f,-8f);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = TargetPotint + GObject.transform.position;
		
	}
}
