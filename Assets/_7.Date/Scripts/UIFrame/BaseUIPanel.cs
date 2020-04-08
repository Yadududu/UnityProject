using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIPanel : MonoBehaviour {

    public abstract void Open();
    public abstract void Close();
    public abstract void OnEnter();
    public abstract void OnPause();
    public abstract void OnResume();
    public abstract void OnExit();

}
