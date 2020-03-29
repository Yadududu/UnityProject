using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asProgram : MonoBehaviour { 
	public static asProgram Get { get; private set; }
	private asUIPanel _UIPanel = new asUIPanel();


    private asProgram() {
		Get = this;

    }

    private void Awake() {
		_UIPanel.OnAwake(gameObject);

    }

    public void Action() {

    }
}