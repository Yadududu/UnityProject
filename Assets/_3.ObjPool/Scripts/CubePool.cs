using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//CubePool 用来对游戏里的对象进行特殊处理 (这里是改变颜色)
public class CubePool : ObjectPool {
    public override GameObject Get(Vector3 pos, float lifetime) {
        GameObject obj;
        obj = base.Get(pos, lifetime);

        obj.GetComponent<Renderer>().material.color = Random.ColorHSV();

        return obj;
    }
}
