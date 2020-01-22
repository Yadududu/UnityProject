using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContextMenuItemText : MonoBehaviour {
    
    [ContextMenuItem("Add 10", "Add")]
    public int i = 200;

    void Add() {
        i += 10;
        
    }

    [ContextMenu("Init i")]
    public void Init() {
        i = 200;
    }
}
