using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDate : MonoBehaviour {

	public int num;

	private System.DateTime[] date;
	// Use this for initialization
	void Start () {
		date = new System.DateTime[num];
		for(int i=0 ;i<date.Length ;i++){
			date[i] = System.DateTime.Now.AddMinutes(-30*(i+1));
		}
		for(int i=0 ;i<date.Length ;i++){
			print(date[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
