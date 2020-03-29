using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.IO;
using System;


public class AutoCreateComponentCode : Editor {

    public static string generateClassName = "generateClassName";

    [MenuItem("GameObject/@(Alt+C)Create Code &c", false, 0)]
    static void CreateCode() {
        var gameObject = Selection.objects.First() as GameObject;
        
        if (!gameObject) {
            Debug.LogWarning("需要选择 GameObject");
            return;
        }
        //创建文件路径
        var scriptsFolder = Application.dataPath + "/CreateScripts";
        if (!Directory.Exists(scriptsFolder)) {
            Directory.CreateDirectory(scriptsFolder);
        }

        ComponentTemplate.Write(gameObject.name, scriptsFolder);
        EditorPrefs.SetString(generateClassName, gameObject.name);
        Debug.Log("Create Code finish!");
        AssetDatabase.Refresh();
    }

    //编辑完后自动回调
    [UnityEditor.Callbacks.DidReloadScripts]
    static void AddComponent2GameObject() {
        string className = EditorPrefs.GetString(generateClassName);
        if (string.IsNullOrEmpty(className)) {
            return;
        }

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var defaultAssembly = assemblies.First(assembly => assembly.GetName().Name == "Assembly-CSharp");

        var typeName = string.IsNullOrEmpty(ComponentTemplate.namespaceName) ? className : ComponentTemplate.namespaceName + "." + className;
        var type = defaultAssembly.GetType(typeName);
        if (type == null) {
            Debug.Log("编译失败");
            return;
        }

        var gameObject = GameObject.Find(className);
        var scriptComponent = gameObject.GetComponent(type);
        if (!scriptComponent) {
            scriptComponent = gameObject.AddComponent(type);
        }
        EditorPrefs.DeleteKey(generateClassName);
    }

}



public class ComponentTemplate {
    public static string namespaceName = "";

    public static void Write(string name, string scriptsFolder) {

        var scriptFile = scriptsFolder + $"/{name}.cs";
        if (File.Exists(scriptFile)) {
            return;
        }
        //创建文件并写入文本
        var writer = File.CreateText(scriptFile);

        writer.WriteLine("using System.Collections;");
        writer.WriteLine("using System.Collections.Generic;");
        writer.WriteLine("using UnityEngine;");

        writer.WriteLine();

        if (string.IsNullOrEmpty(namespaceName)) {
            writer.WriteLine("// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间");
        }

        if (!string.IsNullOrEmpty(namespaceName)) {
            writer.WriteLine($"namespace {namespaceName}");
            writer.WriteLine("{");
        }

        writer.WriteLine($"\tpublic  class {name} : MonoBehaviour");
        writer.WriteLine("\t{");
        writer.WriteLine("\t\tvoid Start()");
        writer.WriteLine("\t\t{");
        writer.WriteLine();
        writer.WriteLine("\t\t}");
        writer.WriteLine("\t}");

        if (!string.IsNullOrEmpty(namespaceName)) {
            writer.WriteLine("}");
        }

        writer.Close();
    }
}