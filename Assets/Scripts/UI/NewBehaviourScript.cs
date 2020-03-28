using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NewBehaviourScript : MonoBehaviour {
    // Start is called before the first frame update
    void OnEnable() {
        //defaultProgram d = new defaultProgram();
        //defaultProgram.Get().print();

        if (GetComponent("DefaultProgram") == null) {
            //Debug.Log(!GetComponent("DefaultProgram"));
            System.Type t = System.Type.GetType("DefaultProgram");
            gameObject.AddComponent(t);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
