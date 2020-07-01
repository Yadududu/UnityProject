using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dic;
using System.Collections.Concurrent;

[ExecuteInEditMode]
public class TestMain : MonoBehaviour {

    /**
     * 自动的属性初始化器Auto Property initialzier
     */
    public long PostID { get; } = 1;
    public string PostName { get; } = "Post 1";
    public string PostTitle { get; protected set; } = string.Empty;


    private void OnEnable() {

        /**
         * 扩展方法
         */
        //传统的做法
        //Debug.Log(int.Parse("123"));
        //Debug.Log(Convert.ToInt32("123"));
        ////扩展方法
        //Debug.Log("123".ConvertToInt32());

        /**
         * 字典初始化器
         */
        //TestDic test = new TestDic();
        //Debug.Log(test.OldDic["users"]);
        //Debug.Log(test.NewDic["users"]);

        /**
         * 声明表达式
         */
        //Debug.Log(OldCheckUserExist("123"));
        //Debug.Log(NewCheckUserExist("123"));

        /**
         * 异常过滤器
         */
        //try {
        //    //Some code
        //} catch (Exception ex) {
        //    if (ex.InnerException != null) {
        //        //Do work;
        //    }
        //}
        ////现在可以改写为
        //try {
        //    //Some code
        //} catch (Exception ex) when (ex.InnerException == null) {
        //    //Do work
        //}

        /**
         * 检查NULL值的条件访问操作符
         */
        //int? id = null;
        ////var i = id != null ? id+1 : 0;
        //var i = id + 1 ?? 0;
        //Debug.Log(i);

        /**
         * 输出变量声明
         */
        //OldPrintCoordinates(new Point());
        //NewPrintCoordinates(new Point());

        /**
        * 具有模式的 is 表达式
        */
        //PrintStars(11);
        //PrintInt("123");

        /**
        * c#7.0 switch支持不同类型的一起switch了。
        */
        //Print(5);

        /**
         * 元组,返回多个变量
         */
        var names1 = LookupName1();
        Debug.Log($"found {names1.Item1} {names1.Item3}");
        var names2 = LookupName2();
        Debug.Log($"found {names2.first} {names2.last}");
        //多种获取的方式
        //(string first, string middle, string last) = LookupName2();
        //(var first, var middle, var last) = LookupName2();
        var (first, middle, last) = LookupName2();
        (first, middle, last) = LookupName2();
        Debug.Log($"found {first} {last}");
        ////进阶
        ////(var myX, var myY) = new Point2(2, 1); // calls Deconstruct(out myX, out myY);
        //(var myX, _) = new Point2(2, 1); // I only care about myX
        //Debug.Log(myX);
        //Debug.Log(Fibonacci(4));

        /**
        * C＃7.0 引入了二进制文字，这样你就可以指定二进制模式而不用去了解十六进制。
        */
        //var d = 123_456;
        //var x = 0xAB_CD_EF;
        //var b = 0b1010_1011_1100_1101_1110_1111;
        //Debug.Log(d);

        /**
        * 就像在 C# 中通过引用来传递参数（使用引用修改器），你现在也可以通过引用来返回参数，同样也可以以局部变量的方式存储参数。
        */
        //int[] array = { 1, 15, -39, 0, 7, 14, -12 };
        //ref int place = ref Find(7, array); // aliases 7's place in the array
        //Debug.Log(array[4]); // prints 7
        //place = 9; // replaces 7 with 9 in the array
        //Debug.Log(array[4]); // prints 9

        //Person person = new Person("lmj");
        //person.Name = "llj";
        //Debug.Log(person.Name);

        //Person2 person2 = new Person2("l mj");
        //Debug.Log(person2.GetFirstName());
        //Debug.Log(person2.GetLastName());
    }

    /**
     * 使用声明表达式我们还可以在if表达式和各种循环表达式中声明变量
     */
    public static int OldCheckUserExist(string userId) {
        //Example 1
        int id;
        if (int.TryParse(userId, out id)) {
            return id;
        }
        return 0;
    }
    public static int NewCheckUserExist(string userId) {
        if (int.TryParse(userId, out var id)) {
            return id;
        }
        return 0;
    }

    /**
    * 输出变量声明
    */
    /// <summary>Olds the print coordinates.</summary>
    /// <param name="p">The p.</param>
    /// 修 改 人：吕铭基
    /// 修改日期：2020/6/29
    public void OldPrintCoordinates(Point p) {
        int x, y; // have to "predeclare"
        p.GetCoordinates(out x, out y);
        Debug.Log($"({x}, {y})");
    }
    public void NewPrintCoordinates(Point p) {
        p.GetCoordinates(out int x, out int y);
        Debug.Log($"({x}, {y})");
    }

    /**
    * 具有模式的 is 表达式
    */
    public void PrintStars(object o) {
        if (o is null) return;     // constant pattern "null"
        //if (o is int) { int i = (int)o;}
        //int? i = o as int?;
        if (!(o is int i)) return; // type pattern "int i"
        Debug.Log(new string('*', i));
    }
    public void PrintInt(object o) {
        //判断是否为int类型,如果是int类型直接打印
        //判断是否为String类型,如果是String类型就转换int类型
        if (o is int i || (o is string s && int.TryParse(s, out i))) {
            Debug.Log(i);
        }
    }


    /**
     * c#7.0 switch支持不同类型的一起switch了。
     */
    public void Print(object o) {
        switch (o) {
            case int i when (i < 10):
                Debug.Log(i);
                break;
            case string s:
                Debug.Log($"{s}的长度为:{s.Length}");
                break;
            case float f:
                Debug.Log(f);
                break;
            default:
                Debug.Log("<unknown shape>");
                break;
            case null:
                throw new ArgumentNullException();
        }
    }
    /**
     * 元组,返回多个变量
     */
    public (string, string, string) LookupName1() { // tuple return type
        // retrieve first, middle and last from data storage
        string first = "1";
        string middle = "2";
        string last = "3";
        return (first, middle, last); // tuple literal
    }
    public (string first, string middle, string last) LookupName2() { // tuple return type
        // retrieve first, middle and last from data storage
        string first = "1";
        string middle = "2";
        string last = "3";
        return (first, middle, last); // tuple literal
    }
    //进阶
    public int Fibonacci(int x) {
        if (x < 0) throw new ArgumentException("Less negativity please!", nameof(x));
        return Fib(x).current;

        (int current, int previous) Fib(int i) {
            if (i == 0) return (1, 0);
            var (p, pp) = Fib(i - 1);
            //Debug.Log(p + "," + pp);
            return (p + pp, p);
        }
    }

    /**
     * 就像在 C# 中通过引用来传递参数（使用引用修改器），你现在也可以通过引用来返回参数，同样也可以以局部变量的方式存储参数。
     */
    public ref int Find(int number, int[] numbers) {
        for (int i = 0; i < numbers.Length; i++) {
            if (numbers[i] == number) {
                return ref numbers[i]; // return the storage location, not the value
            }
        }
        throw new IndexOutOfRangeException($"{nameof(number)} not found");
    }
}
public class Point {
    internal void GetCoordinates(out int x, out int y) {
        x = 1;
        y = 2;
    }
}
public class Point2 {
    public int X { get; }
    public int Y { get; }

    public Point2(int x, int y) { X = x; Y = y; }
    public void Deconstruct(out int x, out int y) { x = X; y = Y; }
}
class Person {
    private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();
    private int id = 1;

    public Person(string name) => names.TryAdd(id, name); // constructors
    ~Person() => names.TryRemove(id, out var v);          // destructors
    public string Name {
        get => names[id];                                 // getters
        set => names[id] = value;                         // setters
    }
}
class Person2 {
    public string Name { get; }
    public Person2(string name) => Name = name ?? throw new ArgumentNullException(name);
    public string GetFirstName() {
        var parts = Name.Split(' ');
        return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
    }
    public string GetLastName() => throw new NotImplementedException();
}
