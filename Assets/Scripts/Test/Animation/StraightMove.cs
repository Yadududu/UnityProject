using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMove : MonoBehaviour {

	public float Speed;
	public GameObject StartPoint;
	public GameObject EndPoint;
	float dur = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// PreSecond(transform.position ,EndPoint.transform.position ,Speed);
		// MoveObject_Lerp(transform.position ,EndPoint.transform.position ,Speed);
		transform.position = Vector3.Lerp(transform.position, EndPoint.transform.position, Time.time);
		MoveObject_Slerp(transform.rotation, EndPoint.transform.rotation, Speed);
	}

	void PreSecond(Vector3 startPos, Vector3 endPos, float moveMax){
		// MoveTowards (current : Vector3, target : Vector3, maxDistanceDelta : float)
		// 1. maxDistanceDelta有效取值范围：maxDistanceDelta <= (target - current).magnitude(向量的长度)，
		// 		当 maxDistanceDelta > (target - current).magnitude 
		// 		与 maxDistanceDelta = (target - current).magnitude效果一样。
		// 2. maxDistanceDelta > 0 && maxDistanceDelta <= (target - current).magnitude, 
		// 		则当前点移向目标target。
		// 3. maxDistanceDelta  < 0 , 则当前点远离目标target。
		// 4. 相当于按照一定的速度匀速完成运动。

		//表示以每秒moveMax的速度从Current移动到Target。
		//因为Current和Target距离是4，所以当moveMax 等于0.5f，用时8秒，moveMax等于2时，用时2秒。
		// Vector3 Current  = new Vector3(0, 0, 0);
		// Vector3 Target = new Vector3(0, 0, 4);
		Vector3 Target = endPos;
		transform.position = Vector3.MoveTowards(startPos, Target, moveMax * Time.deltaTime);
	}

	//在time时间内移动物体
	void MoveObject_Lerp(Vector3 startPos, Vector3 endPos, float time){        
			// 1. 当 t <= 0f, = from 。
			// 2. 当 t >= 1f, = to 。
			// 3. 当 0f < t < 1f, = from + (to - from ) * t。
			// 4. 相当于在规定的时间内完成运动。

			if (dur <= time){
				dur += Time.deltaTime;
				transform.position = Vector3.Lerp(startPos, endPos, dur / time);
			}
	}

	//以指定速度speed移动物体
	void MoveObject_Speed(Vector3 startPos, Vector3 endPos, float speed){
			// float startTime = Time.time;
			// float length = Vector3.Distance(startPos, endPos);
			// float frac = 0;
	
			// while (frac < 1.0f){
			// 	float dist = (Time.time - startTime) * speed;
			// 	frac = dist / length;
			// 	transform.position = Vector3.Lerp(startPos, endPos, frac);
			// }
			transform.position = Vector3.Lerp(startPos, endPos, speed*Time.deltaTime);

	}

	void MoveObject_Slerp(Quaternion startPos, Quaternion endPos, float time){     
			if (dur <= time){
				dur += Time.deltaTime;
				transform.rotation = Quaternion.Slerp(startPos, endPos, dur / time);
				Debug.Log("aa");
			}
	}
}
