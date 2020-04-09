using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zeus.UITemplate {
    //UI元素信息
    public class UIInfo {
        public string varName;
        public string pathName;
        public string field;
        public UIInfo(string name, string typeKey, string path) {
            varName = name;
            pathName = path;
            field = string.Format("public {0} {1};", CreateSprite.typeMap[typeKey], name);
        }
        public UIInfo(string name, string typeKey, string path, string arrName, bool isExistVar) {
            varName = arrName;
            pathName = path;
            if (!isExistVar) field = string.Format("public List<{0}> {1} = new List<{0}>();", CreateSprite.typeMap[typeKey], arrName);
        }
    }

}
