using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MakeGenericTypeTest : MonoBehaviour {
    private void OnEnable() {
        Main();
    }
    public static void Main() {
        Debug.Log("\r\n--- Create a constructed type from the generic Dictionary type.");

        // 创建表示泛型字典的类型对象
        // 类型，省略类型参数(但保留逗号分隔它们，因此编译器可以推断类型参数的数量)。     
        Type generic = typeof(Dictionary<,>);
        DisplayTypeInfo(generic);

        // 创建一个类型数组来替代类型
        // 字典的参数,键的类型是string和字典中包含的类型是Test。
        Type[] typeArgs = { typeof(string), typeof(MakeGenericTypeTest) };

        // 创建一个表示构造的泛型的类型对象
        // type.
        Type constructed = generic.MakeGenericType(typeArgs);
        DisplayTypeInfo(constructed);

        // 将上面获得的类型对象与类型对象进行比较
        // 使用typeof()和GetGenericTypeDefinition()获得。
        Debug.Log("\r\n--- Compare types obtained by different methods:");

        Type t = typeof(Dictionary<String, MakeGenericTypeTest>);
        Debug.Log(string.Format("\tAre the constructed types equal? {0}", t == constructed));
        Debug.Log(string.Format("\tAre the generic types equal? {0}", t.GetGenericTypeDefinition() == generic));
    }

    private static void DisplayTypeInfo(Type t) {
        Debug.Log(string.Format("\r\n{0}", t));

        Debug.Log(string.Format("\tIs this a generic type definition? {0}", t.IsGenericTypeDefinition));

        Debug.Log(string.Format("\tIs it a generic type? {0}", t.IsGenericType));

        Type[] typeArguments = t.GetGenericArguments();
        Debug.Log(string.Format("\tList type arguments ({0}):", typeArguments.Length));
        foreach (Type tParam in typeArguments) {
            Debug.Log(string.Format("\t\t{0}", tParam));
        }
    }


    /* This example produces the following output:

    --- Create a constructed type from the generic Dictionary type.

    System.Collections.Generic.Dictionary`2[TKey,TValue]
            Is this a generic type definition? True
            Is it a generic type? True
            List type arguments (2):
                    TKey
                    TValue

    System.Collections.Generic.Dictionary`2[System.String, Test]
            Is this a generic type definition? False
            Is it a generic type? True
            List type arguments (2):
                    System.String
                    Test

    --- Compare types obtained by different methods:
            Are the constructed types equal? True
            Are the generic types equal? True
     */
}
