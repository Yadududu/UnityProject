using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour{
 
	// Update is called once per frame
	void Update () 
    {
        //编辑器上，Transform组件上的Rotation即为eulerAngles
        //假如Rotation为20.5  40.7  80.9，则eulerAngles也为20.5  40.7  80.9
        if (Input.GetKeyDown(KeyCode.Q)) print("eulerAngles" + transform.eulerAngles);
        if (Input.GetKeyDown(KeyCode.W)) print("rotation" + transform.rotation);
 
 
        //沿某个轴，旋转到某个角度(每次调用AngleAxis函数，eulerAngles先会被重置为(0,0,0),再绕某轴旋转)
        //特点：非旋转轴的其余两个轴，值均为0
        //假如Rotation为20.5  40.7  80.9
        if (Input.GetKeyDown(KeyCode.A)) transform.rotation = Quaternion.AngleAxis(30, Vector3.right);////绕x轴旋转30度，编辑器上的Rotation变为30 0 0
        if (Input.GetKeyDown(KeyCode.S)) transform.rotation = Quaternion.AngleAxis(60, Vector3.up);//绕y轴旋转60度，编辑器上的Rotation变为0 60 0
        if (Input.GetKeyDown(KeyCode.D)) transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);//绕z轴旋转90度，编辑器上的Rotation变为0 0 90
 
        
        //直接修改eulerAngles
        if (Input.GetKeyDown(KeyCode.E)) transform.rotation = Quaternion.Euler(new Vector3(45, 180, 135));//编辑器上的Rotation变为45 180 135
        //等同于 if (Input.GetKeyDown(KeyCode.R)) transform.eulerAngles = new Vector3(45, 180, 135);//编辑器上的Rotation变为45 180 135
 
 
        //沿某个轴，旋转到某个角度
        //假如Rotation为20.5  40.7  80.9
        if (Input.GetKeyDown(KeyCode.Z)) transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(50, 0, 0));//绕x轴旋转50度，编辑器上的Rotation变为70.5  40.7  80.9
        if (Input.GetKeyDown(KeyCode.X)) transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 100, 0));//绕y轴旋转100度，编辑器上的Rotation变为70.5  140.7  80.9
        if (Input.GetKeyDown(KeyCode.C)) transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 150));//绕z轴旋转150度，编辑器上的Rotation变为70.5  140.7  230.9
 
 
        //if (Input.GetKeyDown(KeyCode.V)) transform.eulerAngles += new Vector3(50, 0, 0);//绕x轴旋转50度，编辑器上的Rotation变为70.5  40.7  80.9
        //if (Input.GetKeyDown(KeyCode.B)) transform.eulerAngles += new Vector3(0, 100, 0);//绕y轴旋转100度，编辑器上的Rotation变为70.5  140.7  80.9
        //if (Input.GetKeyDown(KeyCode.N)) transform.eulerAngles += new Vector3(0, 0, 150);//绕z轴旋转150度，编辑器上的Rotation变为70.5  140.7  230.9
 
	}
}