using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[ExecuteInEditMode]
public class LinqExample : MonoBehaviour {

    private int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    private void OnEnable() {
        //第一种方法
        var l1= from ls in list
                where ls > 5
                orderby ls descending
                select ls;
        //print(l1.ToList<int>());

        //第二种方法
        var l2 = list.Where(ls => ls > 5).OrderByDescending(ls => ls);
        print(l2.ToList<int>());
    }
    private void print(List<int> l) {
        foreach (int i in l) {
            Debug.Log(i);
        }
    }

    
}
