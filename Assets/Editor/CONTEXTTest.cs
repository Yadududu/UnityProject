using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CONTEXTTest {

    [MenuItem("CONTEXT/ShowDate/AddTen")]// CONTEXT 组件名 按钮名
    static void InitHealthAndSpeed(MenuCommand cmd)//menucommand是当前正在操作的组件
    {
        //Debug.Log(cmd.context.GetType().FullName);
        ShowDate date = cmd.context as ShowDate;
        date.num = 10;
        Debug.Log("Init");
    }
    [MenuItem("CONTEXT/Rigidbody/Clear")]
    static void ClearMassAndGravity(MenuCommand cmd) {
        Rigidbody rgd = cmd.context as Rigidbody;
        rgd.mass = 0;
        rgd.useGravity = false;
    }
}
