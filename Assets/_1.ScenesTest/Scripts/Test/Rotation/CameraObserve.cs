using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObserve : MonoBehaviour {
    
	// Update is called once per frame
	void Update () 
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
 
        //要么上下观察，要么左右观察
        if (Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
            transform.eulerAngles += new Vector3(0, mouseX, 0);
        else
            transform.eulerAngles += new Vector3(-mouseY, 0, 0);//摄像机绕x轴旋转的方向跟鼠标y移动方向相反
	}
}