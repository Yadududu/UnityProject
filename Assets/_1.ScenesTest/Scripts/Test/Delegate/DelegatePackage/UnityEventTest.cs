using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable] 
public class TestClassEvent : UnityEvent<TestClass> { }
public class UnityEventTest : MonoBehaviour {
    public UnityEvent Grid;
    public UnityEvent OnGrid = new UnityEvent();
    public TestClassEvent Test = new TestClassEvent();

	void Start () {
        OnGrid.AddListener(EventMethod);
        //OnGrid.Invoke();
        Test.AddListener(EventMethod);
        Test.Invoke(new TestClass("你好"));

	}
    void EventMethod() {
        Grid.Invoke();
    }
    void EventMethod(TestClass hd) {
        Debug.Log("打印:" + hd.str);
    }
}

public class TestClass{
    public string str;
    public TestClass(string _str) {
        str = _str;
    }
}
