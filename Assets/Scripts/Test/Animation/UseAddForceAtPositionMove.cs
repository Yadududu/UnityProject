using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAddForceAtPositionMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// gameObject.GetComponent<Rigidbody>().AddForce(0.0f, 10.0f, 0.0f);
		 gameObject.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward*10.0f, new Vector3(0, 0,10));
	}
}
