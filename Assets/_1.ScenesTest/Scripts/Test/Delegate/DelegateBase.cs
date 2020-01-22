using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




delegate void GetString(string str);


public class DelegateBase : MonoBehaviour {

    event GetString GetStringEvent;

    void Start() {
        //委托赋值有两种方法
        //GetString s = new GetString(TestMethod);
        GetString s = TestMethod1;

        //调用委托有两种方法
        s("Delegate");
        s.Invoke("Delegate");

        //Action转换
        Action<string> del = delegate(string n) { Debug.Log("delegate:" + n); };
        del("Action转换");

        //多播委托
        s += TestMethod2;
        s("MultiDelegate");

        //获取多播委托中所有方法的委托
        Delegate[] delegates = s.GetInvocationList();
        int i = 0;
        foreach (Delegate d in delegates) {
            i += 1;
            d.DynamicInvoke(i.ToString());
        }

        //Action委托(可以传入参数，没有返回值的委托)(Action<in T1,in T2 ....  inT16>)
        //Action<string> act = new Action<string>(TestMethod1);
        Action<string> act = TestMethod1;
        act("Action");

        //Action使用lambda表达式
        //Action<string> lambdaAct = ((string str) => Debug.Log("Test1：" + str));
        Action<string, int> lambdaAct = ((str, x) => Debug.Log("Test1：" + str + x.ToString()));
        lambdaAct("Action使用lambda表达式", 1);

        //Action作为参数传
        Action<string> ac = (p => Debug.Log("Action传入值：" + p));//实例化一个委托
        Test(ac, "参数1");//调用test方法，传入委托参数

        //Func委托(可以传入参数，必须有返回值的委托)(Func<int T1,inT2,,,,,,in T16,out TResult>)
        Func<string, string> fun = TestMethod3;
        Debug.Log(fun("Func"));

        //Func使用lambda表达式
        Func<string, string> fun2 = (str) => { return "Test3：" + str; };
        Debug.Log(fun2("Func使用lambda表达式"));

        //Func作为参数传
        //实例化一个委托,注意不加大括号，写的值就是返回值，不能带return
        Func<string, string> fun3 = (p) => "Func传入值:" + p;
        Debug.Log(Test2(fun3, "参数1"));

        //事件
        GetStringEvent += new GetString(TestMethod1);
        GetStringEvent += new GetString(TestMethod2);
        if (GetStringEvent != null) {
            GetStringEvent("Event");
        }
    }
    void TestMethod1(string str) {
        Debug.Log("Test1：" + str);
    }
    void TestMethod2(string str) {
        Debug.Log("Test2：" + str);
    }
    string TestMethod3(string str) {
        return "Test3：" + str;
    }
    void Test<T>(Action<T> ac, T inputParam) {
        ac(inputParam);
    }
    string Test2<T>(Func<T, string> func, T inputParam) {
        return func(inputParam);
    }
    ///
    /// Delegate至少0个参数，至多32个参数，可以无返回值，也可以指定返回值类型
    /// Func可以接受0个至16个传入参数，必须具有返回值
    /// Action可以接受0个至16个传入参数，无返回值
    /// 事件不能在类的外部触发，只能在类的内部触发
    ///
}
