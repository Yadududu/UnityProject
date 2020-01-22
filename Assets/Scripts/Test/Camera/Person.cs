using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zeus.Tool{
	public class Person : MonoBehaviour {

		public GameObject Camera;
		public float moveSpeed = 1f;
		public float turnSpeed = 1f;
		private float rotationX = 0f;
		private float rotationY = 0f;
		private bool m_sign;

		void Start () {
			SetHeight();
		}
		
		void Update () {
			walk();
			if(Input.mousePosition.x < Screen.width & Input.mousePosition.y < Screen.height){
				if(Input.GetMouseButton(0)){
					m_sign = true;
				}
				if(m_sign){
					turn();
				}
			}else{
				m_sign = false;
			}
			if(Input.GetKeyDown(KeyCode.Escape)){
				m_sign = false;
			}
			// print(Input.mousePosition.x);
			// print(Screen.height);
			// print(Screen.width);
			// print("X:" + Input.GetAxis("Mouse X"));
			// print("Y:" + Input.GetAxis("Mouse Y"));
		}
		private void walk(){
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
			transform.Translate(movement * Time.deltaTime * moveSpeed);
		}
		private void turn(){
			rotationX += Input.GetAxis("Mouse X") * turnSpeed; 
			rotationY += Input.GetAxis("Mouse Y") * turnSpeed; 
        	rotationY = Mathf.Clamp (rotationY, -89, 89); 
			transform.localEulerAngles = new Vector3(0, rotationX, 0);  
        	Camera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);  

		}
		private void SetHeight(){
			float height = gameObject.GetComponent<CapsuleCollider>().height;
			Vector3 vct = Camera.transform.position;
			vct.y = height/2;
			Camera.transform.position = vct;
		}
	}
}

