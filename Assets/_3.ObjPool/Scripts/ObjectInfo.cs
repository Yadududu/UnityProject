using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ObjcetInfo.cs 用来记录对象信息 并且 定时回收对象(可根据需要自己看着办修改)
public class ObjectInfo : MonoBehaviour {
    public float Lifetime = 0;
    public string PoolName;

    private WaitForSeconds m_WaitTime;

    private void Awake() {
        if (Lifetime > 0) {
            m_WaitTime = new WaitForSeconds(Lifetime);
        }
    }

    private void OnEnable() {
        if (Lifetime > 0) {
            StartCoroutine(CountDown(Lifetime));
        }
    }

    IEnumerator CountDown(float lifetime) {
        yield return m_WaitTime;
        ObjectPoolManager.Instance.RemoveGameObject(PoolName, gameObject);
    }
}
