using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zeus.Tool{
	public class Place : MonoBehaviour {

		public Store store;
		public int num = 0;

		private void OnMouseDown() {
			print("Down" + gameObject);
			if(store.obj != null){
                Pickup MouseScript = store.obj.GetComponent<Pickup>();
				if(MouseScript.plug == Plug.left){
					store.obj.GetComponent<Pickup>().MouseDownSign = false;
					store.obj.GetComponent<Pickup>().place = gameObject;
					store.obj.transform.position = transform.position;
					store.obj.transform.rotation = transform.rotation;
					gameObject.SetActive(false);
				}else if(MouseScript.plug == Plug.right){
					store.obj.GetComponent<Pickup>().MouseDownSign = false;
					store.obj.GetComponent<Pickup>().place = gameObject;
					store.obj.transform.position = transform.position;
					Vector3 vct = transform.eulerAngles;
					vct.z = vct.z - 180;
					store.obj.transform.eulerAngles = vct;
					gameObject.SetActive(false);
				}
			}


		}
	}
}


