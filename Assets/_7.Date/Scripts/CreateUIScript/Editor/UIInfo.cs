using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI元素信息
public class UIInfo {
    public string field;
    public string body1;
    public string body2;
    public UIInfo(string name, string typeKey, string path) {
        field = string.Format("public {0} {1};", CreateSprite.typeMap[typeKey], name);
        if (typeKey == "go") {
            body1 = string.Format("{0} = viewGO.transform.Find(\"{1}\").gameObject;", name, path);
        } else {
            body1 = string.Format("{0} = viewGO.transform.Find(\"{1}\").GetComponent<{2}>();", name, path, CreateSprite.typeMap[typeKey]);
        }
        body2 = string.Format("{0} = null;", name);
    }
    public UIInfo(string name, string typeKey, string path, string arrName,bool isExistVar) {
        if(!isExistVar) field = string.Format("public List<{0}> {1} = new List<{0}>();", CreateSprite.typeMap[typeKey], arrName);
        if (typeKey == "go") {
            body1 = string.Format("{0}.add(viewGO.transform.Find(\"{1}\").gameObject);", arrName, path);
        } else {
            body1 = string.Format("{0}.Add(viewGO.transform.Find(\"{1}\").GetComponent<{2}>());", arrName, path, CreateSprite.typeMap[typeKey]);
        }
        if (!isExistVar) body2 = string.Format("{0} = null;", arrName);
    }
}
