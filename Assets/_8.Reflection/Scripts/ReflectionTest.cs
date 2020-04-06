using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class ReflectionTest : MonoBehaviour {
    public List<GameObject> gos;
    public List<Transform> trans;
    public GameObject go;
    public GameObject go1;
    public GameObject go2;
    public Transform tran;

    public void OnEnable() {
        var scriptComponent = gameObject.GetComponent("ReflectionTestClass");
        var scriptComponent2 = new ReflectionMenberTest();

        //获取属性类型
        Debug.Log("属性名:" + scriptComponent.GetType().GetField("obj_go").Name);
        Debug.Log("属性类型:" + scriptComponent.GetType().GetField("obj_go").FieldType.Name);
        Debug.Log("IsGenericType:" + scriptComponent.GetType().GetField("obj_go").FieldType.IsGenericType);

        Debug.Log("list属性名:" + scriptComponent.GetType().GetField("list_go").Name);
        Debug.Log("list属性类型:" + scriptComponent.GetType().GetField("list_go").FieldType.Name);
        Debug.Log("list泛型类型:" + scriptComponent.GetType().GetField("list_go").FieldType.GetGenericArguments()[0].Name);
        Debug.Log("list.IsGenericType:" + scriptComponent.GetType().GetField("list_go").FieldType.IsGenericType);

        //给属性赋值
        scriptComponent.GetType().GetField("obj_go").SetValue(scriptComponent,go);
        Debug.Log("obj_go值:" + scriptComponent.GetType().GetField("obj_go").GetValue(scriptComponent));

        //list不是泛型
        //FieldInfo fieldInfo = scriptComponent.GetType().GetField("list_go");
        //Debug.Log(fieldInfo.FieldType);
        //object entityList = Activator.CreateInstance(fieldInfo.FieldType);
        //fieldInfo.FieldType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public).Invoke(entityList, new object[] { go1 });
        //fieldInfo.FieldType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public).Invoke(entityList, new object[] { go2 });
        //fieldInfo.SetValue(scriptComponent, entityList);
        //Debug.Log("list_go值:" + fieldInfo.GetValue(scriptComponent));

        //list是泛型
        FieldInfo fieldInfo = scriptComponent.GetType().GetField("list_go");
        object genericList = CreateGeneric(fieldInfo.FieldType.GetGenericTypeDefinition(), typeof(GameObject));
        Debug.Log(genericList);
        fieldInfo.FieldType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public).Invoke(genericList, new object[] { go1 });
        fieldInfo.FieldType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public).Invoke(genericList, new object[] { go2 });
        fieldInfo.SetValue(scriptComponent, genericList);
        Debug.Log("list_go值:" + fieldInfo.GetValue(scriptComponent));

        //获取属性和方法
        string strMenber = "";
        foreach (MemberInfo m in scriptComponent2.GetType().GetMembers()) {
            strMenber = strMenber +","+ m.Name;
        }
        Debug.Log(strMenber);
        //获取方法
        string strMethod = "";
        foreach (MethodInfo m in scriptComponent2.GetType().GetMethods()) {
            strMethod = strMethod + "," + m.Name;
        }
        Debug.Log(strMethod);
    }

    public static object CreateGeneric(Type generic, Type innerType, params object[] args) {
        //生成通用类型
        Type specificType = generic.MakeGenericType(new Type[] { innerType });
        return Activator.CreateInstance(specificType, args);
    }
}
public class ReflectionMenberTest{
    public List<GameObject> gos;
    public List<Transform> trans;
    public GameObject go;
    public Transform tran;

    public void Start(){

    }
    public void Update() {

    }
}

