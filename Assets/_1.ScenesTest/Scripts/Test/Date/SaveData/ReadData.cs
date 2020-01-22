using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadData : MonoBehaviour {

	public Item item;

	int i;

	// Use this for initialization
	void Start () {
		i=item.count;
		Debug.Log(i);
		item.count=12;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
