using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultProgram : MonoBehaviour {

    public GameObject UICanvas;
    public static defaultProgram Get { get; private set; }
    private defaultUIPanel defaultUIPanel = new defaultUIPanel();

    private defaultProgram() {
        Get = this;
        defaultUIPanel.OnAwake(gameObject);
    }
    private void Start() {
        Action();
    }
    public void Action() {
        defaultUIPanel.Year_input.text = "123";
    }
    //public void print() {
    //    Debug.Log("ok");
    //}
    //public static defaultProgram Get() {
    //    if (get == null) {
    //        get = new defaultProgram();
    //    }
    //    return get;
    //}
}
