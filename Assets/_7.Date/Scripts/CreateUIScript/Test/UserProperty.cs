using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class UserProperty : MonoBehaviour {

    public void OnEnable() {
        //通过属性名（字符串）获取对象属性值
        //User u = new User();
        //u.Name = "lily";
        //var propName = "Name";
        //var propNameVal = u.GetType().GetProperty(propName).GetValue(u, null);
        //Debug.Log(propNameVal);// "lily"

        //通过属性名（字符串）设置对象属性值
        //User u = new User();
        //u.Name = "lily";
        //var propName = "Name";
        //var newVal = "MeiMei";
        //u.GetType().GetProperty(propName).SetValue(u, newVal);
        //Debug.Log(u.Name);// "MeiMei"

        //获取对象的所有属性名称及类型
        //通过类的对象实现
        //User u = new User();
        //foreach (var item in u.GetType().GetProperties()) {
        //    Debug.Log($"propName:{item.Name},propType:{item.PropertyType.Name}");
        //}
        //// propName: Id,propType: Int32
        //// propName:Name,propType: String
        //// propName:Age,propType: String

        //通过类实现
        //foreach (var item in typeof(User).GetProperties()) {
        //    Debug.Log($"propName:{item.Name},propType:{item.PropertyType.Name}");
        //}
        //// propName: Id,propType: Int32
        //// propName:Name,propType: String
        //// propName:Age,propType: String

        //判断对象是否包含某个属性
        //User u = new User();
        //bool isContain = ContainProperty(u, "Name");// true
        //Debug.Log(isContain);

        User u = new User();
        bool isContain = u.ContainProperty("Name");// true
    }
    //public static bool ContainProperty(object instance, string propertyName) {
    //    if (instance != null && !string.IsNullOrEmpty(propertyName)) {
    //        PropertyInfo _findedPropertyInfo = instance.GetType().GetProperty(propertyName);
    //        return (_findedPropertyInfo != null);
    //    }
    //    return false;
    //}
}
