using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//物体平滑自转90度
public class RotateSelf : MonoBehaviour {
 
    bool isRotateSelf = false;
    Vector3 targetEuler = Vector3.zero;
 
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRotateSelf = true;
            targetEuler = transform.eulerAngles + new Vector3(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.T))
            isRotateSelf = false;
 
        //平滑转90度
        if(isRotateSelf)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetEuler), Time.deltaTime);
	}
}
