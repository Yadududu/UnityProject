using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Expands{
    /**扩展方法*/
    public static string ConvertToString(this object s) {
        if (s == null) {
            return "";
        } else {
            return Convert.ToString(s);
        }
    }
    public static Int32 ConvertToInt32(this string s) {
        int i = 0;
        if (s == null) {
            return 0;
        } else {
            int.TryParse(s, out i);
        }
        return i;
    }
}
