using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeState2 : MonoBehaviour {

	public GameObject GameObject;
	T_State Open;
	T_State Hide;

	// Use this for initialization
	void Start () {
		Open=new T_State("Open");
		Open.OnCurState=Perform;

		Hide=new T_State("Hide");
		Hide.OnCurState=Perform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Send(string s){
		if(s=="Open"){
			Open.Perform(Open);
		}
		if(s=="Hide"){
			Hide.Perform(Hide);
		}
	}

	public void Perform(T_State state){
		if(state.name=="Open"){
			GameObject.SetActive(true);
		}
		if(state.name=="Hide"){
			GameObject.SetActive(false);
		}
	}

}

public class T_State{
	public string name;
	public delegate void CurState(T_State State);
	public CurState OnCurState;
	T_State(){

	}
	public T_State(string _name){
		name = _name;
	}

	public void Perform(T_State _state){
		if(OnCurState!=null){
			OnCurState(_state);
		}
	}
	

}
