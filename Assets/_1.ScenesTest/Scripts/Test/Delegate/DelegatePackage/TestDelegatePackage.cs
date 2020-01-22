using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDelegatePackage : MonoBehaviour {

    public string obj1;

	void Start () {
        Movement.SetHandGrid += obj;
        Movement.SetHandGrid += obj;
        Movement.SetHandGrid += obj;
        Movement.SetHandUnGrid += obj;
        Movement.SetHandUnGrid += obj;
        Movement.SetHandGrid();
        Movement.SetHandUnGrid();
	}
	
	void Update () {
		
	}

    void obj() {
        Debug.Log(obj1);
    }
}
