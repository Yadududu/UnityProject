using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//测试主程序
public class PoolDemo : MonoBehaviour {
    private ObjectPool m_TestPool;
    public GameObject Prefab;

    public Button TestButton;

    // Start is called before the first frame update
    void Start() {
        m_TestPool = ObjectPoolManager.Instance.CreateObjectPool<CubePool>("CubePool");
        m_TestPool.Prefab = Prefab;


        TestButton.onClick.AddListener(() => {

            ObjectPoolManager.Instance.GetGameObject("CubePool", new Vector3(0, 0, 0), 2);
        });
    }

    // Update is called once per frame
    void Update() {

    }
}
