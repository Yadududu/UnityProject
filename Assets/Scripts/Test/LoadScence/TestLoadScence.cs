using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLoadScence : MonoBehaviour {
    public int i = 10;
    public GameObject[] DontDestroyObjects;
    private static bool isExist;

    private void Awake() {
        if (!isExist) {
            for (int i = 0; i < DontDestroyObjects.Length; i++) {
                DontDestroyOnLoad(DontDestroyObjects[i]);
            }
            isExist = true;
        } else {
            for (int i = 0; i < DontDestroyObjects.Length; i++) {
                Destroy(DontDestroyObjects[i]);
            }
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Test");
        }
	}
}
