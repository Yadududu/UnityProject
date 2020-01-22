using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformCoroutineInOrder : MonoBehaviour {

	// Use this for initialization
	void Start () {
   		Debug.Log("start1");
        StartCoroutine(Test());
        Debug.Log("start2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Test(){
        Debug.Log("test1");
        yield return StartCoroutine(DoSomething());
        Debug.Log("test2");
    }
    IEnumerator DoSomething(){
        Debug.Log("load 1");
        yield return null; //yield return null表示暂缓一帧
        Debug.Log("load 2");
    }
}
