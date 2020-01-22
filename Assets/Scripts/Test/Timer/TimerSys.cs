using System;
using UnityEngine;
using System.Collections.Generic;

public class TimerSys : MonoBehaviour {
	public static TimerSys Instance;
    private PETimer pt;

	public void InitSys () {
		Instance = this;
        pt = new PETimer();
        pt.SetLog((string info) => {
            Debug.Log("PETimeLog:" + info);
        });
        //pt.SetLog(delegate(string info) { 
        //    Debug.Log("PETimeLog:" + info); });

		Debug.Log("TimerSys Init Done");
	}
    private void Update() {
        pt.Update();
    }
#region TimeTask
    public int AddTimeTask(Action callback, float delay,int count = 1, PETimeUnit timeUnit = PETimeUnit.Millisecond){
        return pt.AddTimeTask(callback, delay, count, timeUnit);
	}
	public bool DeleteTimeTask(int tid){
        return pt.DeleteTimeTask(tid);
	}
    public bool ReplaceTimeTask(int tid,Action callback, float delay, int count = 1, PETimeUnit timeUnit = PETimeUnit.Millisecond) {
        return pt.ReplaceTimeTask(tid, callback, delay, count, timeUnit);
    }
#endregion
#region FrameTask
    public int AddFrameTask(Action callback, int delay, int count = 1) {
        return pt.AddFrameTask(callback, delay, count);
    }
    public bool DeleteFrameTask(int tid) {
        return pt.DeleteFrameTask(tid);
    }
    public bool ReplaceFrameTask(int tid, Action callback, int delay, int count = 1) {
        return pt.ReplaceFrameTask(tid, callback, delay, count);
    }
#endregion
}
