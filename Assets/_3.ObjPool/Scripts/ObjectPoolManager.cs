﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ObjcetPoolManager 用来管理多个对象池
public class ObjectPoolManager : MonoBehaviour {
    public static ObjectPoolManager Instance { get; private set; }

    private Dictionary<string, ObjectPool> m_PoolDic;

    private Transform m_RootPoolTrans;

    public ObjectPoolManager() {
        Instance = this;
    }
    private void Awake() {
        m_PoolDic = new Dictionary<string, ObjectPool>();
        // 根对象池
        GameObject go = new GameObject("ObjcetPoolManager");
        m_RootPoolTrans = go.transform;
    }
    // 创建一个新的对象池
    public T CreateObjectPool<T>(string poolName) where T : ObjectPool, new() {
        if (m_PoolDic.ContainsKey(poolName)) {
            return m_PoolDic[poolName] as T;
        }

        GameObject obj = new GameObject(poolName);
        obj.transform.SetParent(m_RootPoolTrans);
        T pool = new T();
        pool.Init(poolName, obj.transform);
        m_PoolDic.Add(poolName, pool);
        return pool;
    }

    public GameObject GetGameObject(string poolName, Vector3 position, float lifetTime) {
        if (m_PoolDic.ContainsKey(poolName)) {
            return m_PoolDic[poolName].Get(position, lifetTime);
        }
        return null;
    }

    public void RemoveGameObject(string poolName, GameObject go) {
        if (m_PoolDic.ContainsKey(poolName)) {
            m_PoolDic[poolName].Remove(go);
        }
    }

    // 销毁所有对象池
    public void Destroy() {
        m_PoolDic.Clear();
        GameObject.Destroy(m_RootPoolTrans);

    }
}
