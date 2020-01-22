using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadTextContent : MonoBehaviour {

    private string[] TextName;

	// Use this for initialization
	void Start () {
        TextAsset textAsset = Resources.Load<TextAsset>("Name");
        TextName = textAsset.text.Split('\n');
        for (int i = 0; i < TextName.Length; i++) {
            Debug.Log(TextName[i]);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
