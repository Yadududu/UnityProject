using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zeus.Tool{

	public class Store : MonoBehaviour {

		public GameObject obj;
		public GameObject light;
		public Pickup[] leftPlug;
		public Pickup[] rightPlug;
		public bool SwitchSign;

		private int m_num;
		private bool[] connect;

		// Use this for initialization
		void Start () {
			connect = new bool[leftPlug.Length];
		}
		
		// Update is called once per frame
		void Update () {
			m_num = 0;
			if(SwitchSign){
				for(int i=0; i<leftPlug.Length; i++){
					if(leftPlug[i].place != null & rightPlug[i].place != null){
						if(leftPlug[i].place.GetComponent<Place>().num == rightPlug[i].place.GetComponent<Place>().num){
							m_num += 1;
						}
					}
				}
			}else{
				m_num = 0;
			}

			if(m_num == leftPlug.Length){
				light.SetActive(true);
			}else{
				light.SetActive(false);
			}
		}
	}

}
