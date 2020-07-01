using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public float upSpeed;

    private float _x;
    private float _z;
    private Vector3 position;
    private Vector3 rotation;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");

        position = new Vector3(_x, 0f, _z);
        transform.Translate(position * Time.deltaTime * moveSpeed);

        if (Input.GetKey(KeyCode.Q)) {
            rotation = transform.localEulerAngles;
            rotation.y -= Time.deltaTime * rotateSpeed;
            transform.localEulerAngles = rotation;
        }
        if (Input.GetKey(KeyCode.E)) {
            rotation = transform.localEulerAngles;
            rotation.y += Time.deltaTime * rotateSpeed;
            transform.localEulerAngles = rotation;
        }

        if (Input.GetKey(KeyCode.Z)) {
            position = transform.localPosition;
            position.y += Time.deltaTime * upSpeed;
            transform.localPosition = position;
        }
        if (Input.GetKey(KeyCode.C)) {
            position = transform.localPosition;
            position.y -= Time.deltaTime * upSpeed;
            transform.localPosition = position;
        }
    }
}
