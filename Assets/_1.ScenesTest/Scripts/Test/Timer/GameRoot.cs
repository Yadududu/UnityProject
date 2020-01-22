using UnityEngine;

public class GameRoot : MonoBehaviour {
	int tid;
	private void Start () {
		Debug.Log("GameStart...");
		TimerSys timerSys = GetComponent<TimerSys>();
		timerSys.InitSys();
	}
	public void ClickAddBtn(){
		Debug.Log("Add Time Task");
        tid = TimerSys.Instance.AddTimeTask(() => {
            Debug.Log("Tid：" + tid + "" + System.DateTime.Now);
        }, 1000, 0, PETimeUnit.Millisecond);
	}
	void FuncA(){
		Debug.Log("Tid：" + tid);
	}
	public void ClickDelBtn(){
		bool ret = TimerSys.Instance.DeleteTimeTask(tid);
		Debug.Log("Del Time Task" + ret);
	}
    public void ClickRepBtn() {
        bool ret = TimerSys.Instance.ReplaceTimeTask(tid, FuncB, 2000);
        Debug.Log("Rep Time Task" + ret);
    }
    void FuncB() {
        Debug.Log("New Task Replace Done.");
    }

    public void ClickAddFrameBtn() {
        Debug.Log("Add Frame Task");
        tid = TimerSys.Instance.AddFrameTask(() => {
            Debug.Log("FrameTid：" + tid + "" + System.DateTime.Now);
        }, 50, 0);
    }
    public void ClickDelFrameBtn() {
        bool ret = TimerSys.Instance.DeleteFrameTask(tid);
        Debug.Log("Del Frame Task" + ret);
    }
    public void ClickRepFrameBtn() {
        bool ret = TimerSys.Instance.ReplaceFrameTask(tid, FuncB, 2000);
        Debug.Log("Rep Frame Task" + ret);
    }
}
//如何扩展取消定时任务？
//--生成局唯一ID
//--通过ID索引操作任务

//如何扩展循环定时任务？
//通过任务计数运算

//如何扩展时间单位支持？
//统一换算成最小的毫秒运算

//如何支持多线程定时任务？
//通过临时列表进行缓存，错开操作时间
//避免使用锁，提升操作效率

//如何实现基础定时任务？
//通过Update()来检测任务操作

