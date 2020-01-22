using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {
    
    void Update() {
        transform.position += Vector3.up * Time.deltaTime * 2;
    }
}
