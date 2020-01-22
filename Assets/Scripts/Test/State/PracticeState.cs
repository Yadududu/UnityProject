using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PracticeState : MonoBehaviour {

	public GameObject GameObject;

	MyMachine MyMachine = new MyMachine();
	MyState Open;

	MyState Hide;

	// Use this for initialization
	void Start () {
		Open = new MyState("Open");
		Open.OnAction = ActionEvent;
		Open.OnEnter = Enter;
		Open.OnExit = Exit;

		Hide = new MyState("Hide");
		Hide.OnAction = ActionEvent;
		Hide.OnEnter = Enter;
		Hide.OnExit = Exit;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SendEvent(string s){
		if(s=="Open"){
			MyMachine.ChangState(Open);
		}
		if(s=="Hide"){
			MyMachine.ChangState(Hide);
		}

	}

	public void Enter(MyState _from ,MyState _to){
		Debug.Log("Enter" + _to.name);
	}
	public void Exit(MyState _from ,MyState _to){
		Debug.Log("Exit" + _from.name);
	}
	public void ActionEvent(MyState Event){
		Debug.Log("Action" + Event.name);

		if(Event.name == "Open"){
			GameObject.SetActive(true);
		}
		if(Event.name == "Hide"){
			GameObject.SetActive(false);
		}
	}
}

class MyMachine{
	MyState  CurState;

	MyState  LastState;

	public MyMachine(){
		CurState=null;
		LastState=null;
	}
	MyMachine(MyState _CurState){
		CurState = _CurState;
		LastState = new MyState("init");
		CurState.Enter(LastState,CurState);
	}
	public void ChangState(MyState _CurState){
		if(LastState==null){
			LastState = new MyState("init");
		}
		CurState = _CurState;
		CurState.Exit(LastState,CurState);
		CurState.Enter(LastState,CurState);
		LastState=CurState;
		CurState.Action(CurState);

	}
}

class MyState{
	public string name;

	public MyState(){

	}

	public MyState(string _name){
		name = _name;
	}

	public delegate void ChangeEvent(MyState from ,MyState to);
	public delegate void Execute(MyState CurState);

	public ChangeEvent OnEnter;
	public ChangeEvent OnExit;
	public Execute OnAction;

	public void Enter(MyState _from ,MyState _to){
		if(OnEnter!=null){
			OnEnter(_from ,_to);
		}
	}

	public void Exit(MyState _from ,MyState _to){
		if(OnExit!=null){
			OnExit(_from ,_to);
		}
	}

	public void Action(MyState _CurState){
		if(OnAction!=null){
			OnAction(_CurState);
		}
	}

}
