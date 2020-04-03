using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EeditorModeRun : MonoBehaviour {
    // Start is called before the first frame update
    void OnEnable() {
        //defaultProgram d = new defaultProgram();
        //defaultProgram.Get().print();

        //if (GetComponent("DeProgram") == null) {
        //Debug.Log(!GetComponent("DefaultProgram"));

        //System.Type t = System.Type.GetType("DeProgram");
        //Debug.Log(t);
        //gameObject.AddComponent(t);

        //}
        //DefProgram.Get.setText("123");
    }

    // Update is called once per frame
    void Update() {
        TemProgram.Get.SetText("123");
    }
}
