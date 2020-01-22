using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
//using System.Threading.Tasks;


public class ThreadBase : MonoBehaviour {

	void Start () {
        //第一种开启线程的方法
        var t1 = new Thread(ThreadMain);
        t1.Start();
        //t1.Abort();//终止这个线程的执行
        t1.Join();//当前线程睡眠，等待t1线程执行完，然后继续运行下面的代码

        //Thread类-Lambda表达式
        var t2 = new Thread(() => Debug.Log("Running in a thread, id : " + Thread.CurrentThread.ManagedThreadId));
        t2.Start();

        //给线程传递数据-通过委托
        var d = new Data { Message = "给线程传递数据-通过委托" };
        var t3 = new Thread(ThreadMainWithParameters);
        t3.Start(d);

        //给线程传递数据-自定义类
        var obj = new MyThread("给线程传递数据-自定义类");
        var t4 = new Thread(obj.ThreadMain);
        t4.IsBackground = true;//设置为后台线程
        t4.Start();

        //线程池
        ThreadPool.QueueUserWorkItem(ThreadMethod);
        ThreadPool.QueueUserWorkItem(ThreadMethod);
        ThreadPool.QueueUserWorkItem(ThreadMethod);

        //任务
        //第一种开启方式
        //Task t5 = new Task(ThreadMethod);
        //t5.Start();
        //第二种开始方式
        //TaskFactory tf = new TaskFactory();
        //Task t6 = tf.StartNew(ThreadMethod);
        //任务有父子关系
        //如果父任务执行完了但是子任务没有执行完，它的状态会设置为WaitingForChildrenToComplete
        //只有子任务也执行完了，父任务的状态就变成RunToCompletion
        //Task task1 = new Task(DoFirst);
        //Task task2 = task1.ContinueWith(DoSecond);//父任务是task1
        //Task task3 = task1.ContinueWith(DoSecond);//父任务是task1
        //Task task4 = task2.ContinueWith(DoSecond);//父任务是task2




        Debug.Log("This is the main thread.");
	}
    void ThreadMain() {
        Debug.Log("Running in a thread.");
    }

    public struct Data {//声明一个结构体用来传递数据
        public string Message;
    }
    void ThreadMainWithParameters(System.Object o) {
        Data d = (Data)o;
        Debug.Log("Running in a thread , received :" + d.Message);
    }
    void ThreadMethod(object state) {
        Debug.Log("线程开始" + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(2000);
        Debug.Log("线程结束");
    }

}
public class MyThread {
    private string data;
    public MyThread(string data) {
        this.data = data;
    }
    public void ThreadMain() {
        Debug.Log("Running in a thread , data : " + data);
    }
}

///
/// 在默认情况下，用Thread类创建的线程是前台线程。线程池中的线程总是后台线程。
///

