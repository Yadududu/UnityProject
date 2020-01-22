using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName="Inventory/Item")]
public class Item : ScriptableObject {

    public new string name = "Item";
    public Sprite icon = null;
    public int count;
    public GameObject gameObject;

    public virtual void Use() { 
    
    }
}
