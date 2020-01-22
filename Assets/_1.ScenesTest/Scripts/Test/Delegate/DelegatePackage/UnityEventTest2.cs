using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int> {
}

public class UnityEventTest2 : MonoBehaviour {
    public MyIntEvent m_MyEvent;

    void Start() {
        if (m_MyEvent == null)
            m_MyEvent = new MyIntEvent();

        m_MyEvent.AddListener(Ping);
    }

    void Update() {
        if (Input.anyKeyDown && m_MyEvent != null) {
            m_MyEvent.Invoke(5);
        }
    }

    void Ping(int i) {
        Debug.Log("Ping" + i);
    }
}


