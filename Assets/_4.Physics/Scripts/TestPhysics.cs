using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhysics : MonoBehaviour {

    void Start() {
        //获取半径内物体
        //Collider[] cs = Physics.OverlapSphere(transform.position, 4);
        //foreach (Collider c in cs) {
        //    Debug.Log(c.name);
        //}

        //施加爆炸力
        //GetComponent<Rigidbody>().AddExplosionForce(1000, transform.position, 20);

        //施加力
        //GetComponent<Rigidbody>().AddForce(new Vector3(1000,0,0));

        //施加力
        GetComponent<Rigidbody>().AddTorque(new Vector3(10000, 0, 0));
    }

    void Update() {

    }
}
