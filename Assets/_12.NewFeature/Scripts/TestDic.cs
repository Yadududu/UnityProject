using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dic {
    public class TestDic {

        public Dictionary<string, string> OldDic = new Dictionary<string, string>()
        {
        {"users", "Venkat Baggu Blog" },
        {"Features", "Whats new in C# 6" }
    };
        public Dictionary<string, string> NewDic { get; } = new Dictionary<string, string>() {
            ["users"] = "Venkat Baggu Blog",
            ["Features"] = "Whats new in C# 6"
        };

        public static void TestMethod() {
            Debug.Log("TestMethod()");
        }
    }
}

