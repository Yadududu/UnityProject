using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProgram : MonoBehaviour { 
	public static DefaultProgram Get { get; private set; }
	private DefaultUIPanel _UIPanel = new DefaultUIPanel();


    private DefaultProgram() {
		Get = this;

    }

    private void Awake() {
		_UIPanel.OnAwake(gameObject);

    }

    public void Action() {

    }
}