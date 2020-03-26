using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEditor;
using UnityEngine;

//导出脚本的模版
public class CreateSpriteUnit {
    public string classname;
    public string template = @"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class @ClassName {   
@fields

    public void OnAwake(GameObject viewGO){
@body1
    }

    public void OnDestroy(){
@body2
    }
}
";
    //缓存的所有子对象信息
    public List<UIInfo> evenlist = new List<UIInfo>();
    /// <summary>
    /// 把拼接好的脚本写到本地。
    /// （自己可以个窗口支持改名和选择路径，真实工程里是带这些功能的）
    /// </summary>
    public void WtiteClass(string path) {
        bool flag = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(flag, throwOnInvalidBytes);
        bool append = false;
        if (File.Exists(Application.dataPath + "/" + classname + ".cs")) {
            EditorUtility.DisplayDialog("警告", classname + ".cs文件已存在,请先删除" + classname + ".cs或者修改文件名再生成脚本", "确定");
        } else {
            //StreamWriter writer = new StreamWriter(Application.dataPath + "/" + classname + ".cs", append, encoding);
            StreamWriter writer = new StreamWriter(path, append, encoding);
            writer.Write(GetClasss());
            writer.Close();
            AssetDatabase.Refresh();
        }
    }
    //脚本拼接
    public string GetClasss() {
        var fields = new StringBuilder();
        var body1 = new StringBuilder();
        var body2 = new StringBuilder();
        for (int i = 0; i < evenlist.Count; i++) {
            if (evenlist[i].field != null) fields.AppendLine("\t" + evenlist[i].field);
            body1.AppendLine("\t\t" + evenlist[i].body1);
            if (evenlist[i].body2 != null) body2.AppendLine("\t\t" + evenlist[i].body2);
        }
        template = template.Replace("@ClassName", classname).Trim();
        template = template.Replace("@body1", body1.ToString()).Trim();
        template = template.Replace("@body2", body2.ToString()).Trim();
        template = template.Replace("@fields", fields.ToString()).Trim();
        return template;
    }
}
