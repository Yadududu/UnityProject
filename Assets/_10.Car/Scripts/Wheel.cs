using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Car {
    public class Wheel : MonoBehaviour {
        public enum Direction {
            right,
            left
        }

        public Direction direction;
        [HideInInspector]
        public State state = State.General;
        [HideInInspector]
        public bool initSign;
        public UnityAction<Wheel> onSuccess;

        private string _ObjName;
        public bool _MouseSign;
        private Vector3 _OriginPosition;
        private Vector3 _ExcursionPosition;
        private void Start() {
            _ObjName = gameObject.name;
            _OriginPosition = transform.localPosition;
            if (direction == Direction.right) {
                _ExcursionPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 1);
            } else {
                _ExcursionPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1);
            }

        }
        private void Update() {

            switch (state) {
                case State.General:

                    break;
                case State.Install:
                    if (initSign) {
                        initSign = false;
                        _MouseSign = false;
                        transform.localPosition = _ExcursionPosition;
                    }
                    Install();
                    break;
                case State.UnInstall:
                    if (initSign) {
                        initSign = false;
                        _MouseSign = false;
                        transform.localPosition = _OriginPosition;
                    }
                    UnInstall();
                    break;
            }
        }
        private void Install() {
            Drop();
        }
        private void UnInstall() {
            if (_MouseSign) {
                if (Input.GetMouseButtonUp(0)) {
                    onSuccess.Invoke(this);
                }
            }
            Drop();
        }
        private void Drop() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawLine(ray.origin, ray.GetPoint(100), Color.red);

            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.gameObject.name == _ObjName) {
                    if (Input.GetMouseButtonDown(0)) {
                        _MouseSign = true;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0)) {
                _MouseSign = false;
            }
            if (_MouseSign) {
                Vector3 v3 = transform.position - Camera.main.transform.position;
                float distance = Vector3.Dot(v3, Camera.main.transform.forward);
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
            }
        }

    }

}
