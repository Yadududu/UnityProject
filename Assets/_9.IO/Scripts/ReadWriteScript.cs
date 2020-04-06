using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class ReadWriteScript : MonoBehaviour {
    private string path = "";
    private string varName;

    public void OnEnable() {
        path = Application.dataPath + "/Resources/NeedAlterScript.cs";
        varName = "public GameObject go;";
        //Debug.Log(path);

        //TextAsset textAsset = Resources.Load<TextAsset>("NeedAlterScript");
        //Debug.Log(textAsset.text);
        //Debug.Log(GetNewVarName(textAsset.text, varName));

        bool flag = true;//省略 BOM
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(flag, throwOnInvalidBytes);
        bool append = false;//覆盖原来的文件
        if (File.Exists(path)) {
            StreamReader textAsset = new StreamReader(path);
            string textStr = textAsset.ReadToEnd();
            textAsset.Close();
            Debug.Log(textStr);

            StreamWriter writer = new StreamWriter(path, append, encoding);
            writer.Write(GetNewVarName(textStr, varName));
            writer.Close();
            AssetDatabase.Refresh();
        }
    }
    private string GetNewVarName(string text, string varName) {
        string frontPart = "";
        string latePart = "";
        string str = text;
        frontPart = str.Substring(0, str.IndexOf("//--AutoCreateStart") == -1 ? str.Length : str.IndexOf("//--AutoCreateStart"));
        if (frontPart.Length == str.Length) {
            latePart = str.Substring(str.Length);
        } else {
            latePart = str.Substring(str.IndexOf("//--AutoCreateEnd") == -1 ? 0 : str.IndexOf("//--AutoCreateEnd"));
        }
        if (latePart.Length == str.Length) frontPart="";
        //Debug.Log(frontPart);
        //Debug.Log(latterPart);
        //Debug.Log(varName);

        var fields = new StringBuilder();
        fields.Append(frontPart);
        fields.AppendLine("//--AutoCreateStart");
        fields.AppendLine("\t" + varName);
        fields.AppendLine("\t" + latePart);
        return fields.ToString();
    }
}
