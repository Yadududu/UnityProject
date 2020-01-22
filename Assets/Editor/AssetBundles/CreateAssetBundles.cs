using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreatAssetBundles : MonoBehaviour {

	[MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles(){
        string dir = "AssetBundle";
        if(Directory.Exists(dir) == false){
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
    }
}
