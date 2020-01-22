using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zeus.Tool{
	public class Pickup : MonoBehaviour {
		public Store store;
		public Plug plug;
		public GameObject place;
		public bool MouseDownSign;
		
		private void Update() {
			if(Input.GetMouseButton(1)){
				MouseDownSign = false;
				if(store.obj != null){
					store.obj = null;
				}
				
			}
			if(MouseDownSign){
				if(place != null){
					place.SetActive(true);
					place = null;
				}
				store.obj = gameObject;
				gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,-20f,1f));
			}

		}
		private void OnMouseDown() {
			MouseDownSign = true;
			print("Down" + gameObject);
		}
		// private void OnMouseUp() {
		// 	print("Up" + gameObject);
		// }
		// private void OnMouseDrag() {
		// 	gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,1f));

		// 	print("Drag" + gameObject);
		// }
		// private void OnMouseOver() {
		// 	print("Over");
		// }
		// private void OnMouseExit() {
		// 	print("Exit");
		// }
		// private void OnMouseEnter() {
		// 	print("Enter");
		// }

		
	}
	public enum Plug{
		left,
		right
	}
}

