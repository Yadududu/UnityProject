//// Calculate the world origin relative to this transform.
//using UnityEngine;
//using System.Collections;

//public class TestTransform : MonoBehaviour {
//    void Start() {
//        Vector3 relativePoint = transform.InverseTransformPoint(0, 0, 0);

//        if (relativePoint.z > 0)
//            print("The world origin is in front of this object");
//        else
//            print("The world origin is behind of this object");
//    }
//}

//using UnityEngine;

//public class TestTransform : MonoBehaviour {
//    void Start() {
//        // transform the world forward into local space:
//        Vector3 relative;
//        relative = transform.InverseTransformDirection(Vector3.forward);
//        Debug.Log(relative);
//    }
//}


using UnityEngine;
using System.Collections;

public class TestTransform : MonoBehaviour {
    public Transform Obj;
    public Vector3 cameraRelative;

    void Update() {
        Vector3 cameraRelative = Obj.InverseTransformPoint(transform.position);

        if (cameraRelative.z > 0)
            print("在物体前面");
        else
            print("在物体后面");

        if (cameraRelative.x > 0)
            print("在物体右面");
        else
            print("在物体左面");
    }
}
