using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace ConsoleTimer {
    class Program {
        private static readonly string obj = "lock";

        static void Main(string[] args) {
            Console.WriteLine("Test Start");
            //TimerTest();
            //Test1();
            Test2();
            Console.ReadKey();
        }

        //在主线程检测并处理
        static void Test1() {
            PETimer pt = new PETimer();
            pt.SetLog((string info) => {
                Console.WriteLine("ConsoleLog:" + info);
            });

            pt.AddTimeTask((int tid) => {
                Console.WriteLine("Time:" + DateTime.Now);
                Console.WriteLine("Process线程ID:{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            }, 1000, 0, PETimeUnit.Millisecond);

            while (true) {
                pt.Update();
            }
        }

        //独立线程检测并处理
        static void Test2() {
            Queue<TaskPack> tpQue = new Queue<TaskPack>();
            PETimer pt = new PETimer(50);
            pt.SetLog((string info) => {
                Console.WriteLine("ConsoleLog:" + info);
            });
            int id = pt.AddTimeTask((int tid) => {
                Console.WriteLine("Process线程ID:{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            }, 1000, 0, PETimeUnit.Millisecond);

            //pt.SetHandle((Action<int> cb, int tid) => { 
            //    if(cb != null){
            //        lock(obj){
            //            tpQue.Enqueue(new TaskPack(tid, cb));
            //        }
            //    }
            //});
            
            while(true){
                string ipt = Console.ReadLine();
                if(ipt == "d"){
                    pt.DeleteTimeTask(id);
                }

                if (tpQue.Count > 0) {
                    TaskPack tp;
                    lock (obj) { 
                        tp = tpQue.Dequeue();
                    }
                    tp.cb(tp.tid);
                }
            }
        }

        static void TimerTest() {
            System.Timers.Timer t = new System.Timers.Timer(50);
            t.AutoReset = true;
            t.Elapsed += (object sender, ElapsedEventArgs args) => {
                //Console.WriteLine("Time:" + DateTime.Now);
                Console.WriteLine("Process线程ID:{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            };
            t.Start();
        }
    }
}

class TaskPack {
    public int tid;
    public Action<int> cb;
    public TaskPack(int tid,Action<int> cb) {
        this.tid = tid;
        this.cb = cb;
    }
}
