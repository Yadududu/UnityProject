using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car {
    public class WheelTrigger : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if (other.tag == "Wheel") {
                other.transform.localPosition = transform.localPosition;
                GetComponent<SphereCollider>().enabled = false;
                Wheel wheel = other.GetComponent<Wheel>();
                wheel.state = State.General;
                wheel.onSuccess.Invoke(wheel);
            }
        }
    }

}
