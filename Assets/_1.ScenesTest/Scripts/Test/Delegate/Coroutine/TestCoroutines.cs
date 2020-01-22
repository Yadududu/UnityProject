using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutines : MonoBehaviour {

	public Vector3[] path;  
    float moveSpeed=10;  
	// Use this for initialization
	void Start () {
		// StartCoroutine("SayHello5Times");
		 StartCoroutine("CountSeconds");
		// // StartCoroutine(CountSeconds());
		
		// // StopCoroutine("CountSeconds");
		// StopAllCoroutines();

		// StartCoroutine("SayHello5Times");
		// StartCoroutine(SaySomeThings());

		// StartCoroutine(MoveOnPath(true));
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("this is first update");
	}

	IEnumerator TestFrame(){
		// yield return new WaitForEndOfFrame();
		yield return null;
		//yield return new WaitForFixedUpdate();
		Debug.LogError("this is update over");
	}

	
	IEnumerator SayHello5Times(){
		for(int i = 0; i < 5; i++){
			Debug.LogError("Hello");
			yield return 0;
		}
	}


	IEnumerator CountSeconds(){
		int seconds = 0;
		while(true){
			for(float timer = 0; timer < 1; timer += Time.deltaTime){
				seconds++;
				Debug.Log(seconds +" seconds have passed since the Coroutine started.");
				yield return 0;
			}
		}
	}

	IEnumerator SaySomeThings(){
		Debug.Log("The routine has started");  
        yield return StartCoroutine(Wait(1.0f));  
        Debug.Log("1 second has passed since the last message");  
        yield return StartCoroutine(Wait(2.5f));  
        Debug.Log("2.5 seconds have passed since the last message");  
	}
	IEnumerator Wait(float duration){
		for(float i=0 ; i<duration ; i+=Time.deltaTime){
			yield return 0;
		}
	}
	IEnumerator MoveOnPath(bool loop)  
    {  
        do  
        {  
            foreach(var point in path)  
                yield return StartCoroutine(MoveToPosition(point));  
        }  
        while(loop);  
    }  

	IEnumerator MoveToPosition(Vector3 target)  
    {  
        while(transform.position != target)  
        {  
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);  
            yield return 0;  
        }  
    }  
}
