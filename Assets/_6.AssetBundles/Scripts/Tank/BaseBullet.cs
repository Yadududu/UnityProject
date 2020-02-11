using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete {
    public class BaseBullet : MonoBehaviour {
        
        protected int _BulletSpeed = 30;

        protected virtual void Start() {

        }

        protected void Update() {
            transform.Translate(Vector3.forward * _BulletSpeed * Time.deltaTime);
        }
        protected virtual void OnCollisionEnter(Collision collision) {
            
        }
    }
}

