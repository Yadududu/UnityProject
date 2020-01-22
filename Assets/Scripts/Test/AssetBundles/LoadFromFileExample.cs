using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class LoadFromFileExample : MonoBehaviour {

    // Use this for initialization
    IEnumerator Start() {
        string path = "AssetBundle/model/cube.unity3d";
        //AssetBundle ab = AssetBundle.LoadFromFile(path);
        //GameObject cubePrefab = ab.LoadAsset<GameObject>("Cube");
        //Instantiate(cubePrefab);
        //AssetBundle ab2 = AssetBundle.LoadFromFile("AssetBundle/material/chartlet.unity3d");
        //Object[] objs = ab.LoadAllAssets();
        //foreach (Object o in objs) {
        //    Instantiate(o);
        //}

        //第一种加载AB的方式 LoadFromMemoryAsync
        //异步加载
        //AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        //yield return request;
        //AssetBundle ab = request.assetBundle;
        //同步加载
        //AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));

        //第二种加载AB的方式 LoadFromFile
        //异步加载
        //AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
        //yield return request;
        //AssetBundle ab = request.assetBundle;

        //第三种加载AB的方式 WWW
        //while (Caching.ready == false) {
        //    yield return null;
        //}
        ////file://  file:///
        ////后面是版本号，如果同一版本号会检查是否下载，没下载的下载，如果不是同一版本号，则全部下载
        ////WWW www = WWW.LoadFromCacheOrDownload(@"file:///D:/Projects/UnityProjects/UnityProject/AssetBundle/model/cube.unity3d", 1);
        //WWW www = WWW.LoadFromCacheOrDownload(@"http://localhost/AssetBundle/model/cube.unity3d", 1);
        //yield return www;
        //if (string.IsNullOrEmpty(www.error) == false) {
        //    Debug.Log(www.error); yield break;
        //}
        //AssetBundle ab = www.assetBundle;

        //第四种方式 使用UnityWebRequest
        //string uri = @"file:///D:/Projects/UnityProjects/UnityProject/AssetBundle/model/cube.unity3d";
        string uri = @"http://localhost/AssetBundle/model/cube.unity3d";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri);
        yield return request.Send();
        //AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;

        GameObject cubePrefab = ab.LoadAsset<GameObject>("Cube");
        Instantiate(cubePrefab);

        //加载依赖
        AssetBundle manifestAB = AssetBundle.LoadFromFile("AssetBundle/AssetBundle");
        AssetBundleManifest manifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        foreach (string name in manifest.GetAllAssetBundles()) {
            print(name);
        }
        string[] strs = manifest.GetAllDependencies("model/cube.unity3d");
        foreach (string name in strs) {
            print(name);
            AssetBundle ab2 = AssetBundle.LoadFromFile("AssetBundle/" + name);
        }
    }

    // Update is called once per frame
    void Update() {
        //if (Input.GetMouseButtonDown(0)) {
        //    AssetBundle.LoadFromFile("AssetBundle/material/chartlet.unity3d");
        //}
    }
}
