using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemProgram : MonoBehaviour { 
	public static TemProgram Get { get; private set; }
	private TemUIPanel _UIPanel = new TemUIPanel();


    private TemProgram() {
		Get = this;

    }

    private void Awake() {
		_UIPanel.OnAwake(gameObject);

    }

    public void Action() {

    }
    public void SetText(string str) {
        _UIPanel.Year_input.text = str; 
    }
}