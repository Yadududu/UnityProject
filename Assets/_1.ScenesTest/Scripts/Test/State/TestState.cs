using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State{
    /// 
    /// 状态名
    /// 
    public string name = "";
    /// 
    /// 构造
    /// 
    public State(string _name){
        name = _name;
    }
    public State(){
 
    }
 
    public delegate void TransitionEventHandler(State _from, State _to);
    public delegate void OnActionHandler(State _curState);
 
    /// 
    /// 进入时的事件
    /// 
    public TransitionEventHandler onEnter;//System.Action
    /// 
    /// 退出时的事件 
    /// 
    public TransitionEventHandler onExit;
    /// 
    /// 在状态机Update()时候调用的更新事件
    /// 
    public OnActionHandler onAction;
 
    public virtual void Enter(State _from, State _to){
        if (onEnter != null)
            onEnter(_from, _to);
    }
 
    public virtual void Excute(State _curState){
        if (onAction != null)
            onAction(_curState);
    }
 
    public virtual void Exit(State _from, State _to){
        if (onExit != null)
            onExit(_from, _to);
    }
}


public class Machine{
    private State curState = null;
    private State lastState = null;
 
    /*Update*/  
    public void Update ()  {  
        if (curState != null)
            curState.Excute(curState);  
    }  
  
    /*状态改变*/  
    public void ChangeState (State _newState)  {
        if (_newState == null){  
            Debug.LogError ("can't find this state");  
        }
        if (curState != null && _newState.name == curState.name)
            Debug.LogError("can't change to the same state");  
          
        //触发退出状态调用Exit方法  
        curState.Exit(curState, _newState);  
        //保存上一个状态   
        lastState = curState;  
        //设置新状态为当前状态  
        curState = _newState;  
        //m_pCurrentState.Target = m_pOwner;  
        //进入当前状态调用Enter方法  
        curState.Enter(lastState, curState);  
    }
 
    public Machine(){
        curState = null;
        lastState = null;
    }
 
    public Machine(State _curState){
        curState = _curState;
        lastState = new State("init");
        curState.Enter(lastState, _curState);
    }
}



public class TestState : MonoBehaviour {

	protected State moveState = null;
	protected State idleState = null;
	protected State attackState = null;

	Machine curMachine = null;

	void Start () {
		idleState = new State("idle");
		idleState.onEnter = EnterIdle;
		idleState.onExit = ExitIdle;
		idleState.onAction = ExcuteIdle;

		moveState = new State("move");
		moveState.onEnter = EnterMove;
		moveState.onExit = ExitMove;
		moveState.onAction = ExcuteMove;

		attackState = new State("attack");
		attackState.onEnter = EnterAttack;
		attackState.onExit = ExitAttack;
		attackState.onAction = ExcuteAttack;

		curMachine = new Machine(idleState);
	}
	
	void Update () {
		if (curMachine != null)
			curMachine.Update();
	}

	void EnterIdle(State _from, State _to){
		Debug.Log("EnterIdle _from:" + _from.name);
	}
	void ExitIdle(State _from, State _to){
		Debug.Log("ExitIdle _to:" + _to.name);
	}
	void ExcuteIdle(State _curState){

	}

	void EnterMove(State _from, State _to){
		Debug.Log("EnterMove _from:" + _from.name);
	}
	void ExitMove(State _from, State _to){
		Debug.Log("ExitMove _to:" + _to.name);
	}
	void ExcuteMove(State _curState){

	}

	void EnterAttack(State _from, State _to){
		Debug.Log("EnterAttack _from:" + _from.name);
	}
	void ExitAttack(State _from, State _to){
		Debug.Log("ExitAttack _to:" + _to.name);
	}
	void ExcuteAttack(State _curState){

	}

	void OnGUI(){
		if (GUILayout.Button("idle")){
			if (curMachine != null)
				curMachine.ChangeState(idleState);
		}
		if (GUILayout.Button("move")){
			if (curMachine != null)
				curMachine.ChangeState(moveState);
		}
		if (GUILayout.Button("attack")){
			if (curMachine != null)
				curMachine.ChangeState(attackState);
		}
	}
}


