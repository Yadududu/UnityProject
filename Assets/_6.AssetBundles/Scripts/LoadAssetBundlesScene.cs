using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;

public class LoadAssetBundlesScene : MonoBehaviour {

    public static LoadAssetBundlesScene Get { get; private set; }
    public string sceneName;
    public string uri;
    public AssetBundleManifest manifest { get; private set; }
    public List<AssetBundle> assetBundle = new List<AssetBundle>();//记录加载的AssetBundle,以便卸载

    private URIPath path;
    

    private LoadAssetBundlesScene(){
        Get = this;
    }
    private void Start() {
        //GetLocalURI();
        StartCoroutine(GetWWWURI());
        DontDestroyOnLoad(this);
    }

    private void GetLocalURI() {
        //本地获取
        StreamReader sr = new StreamReader(Application.dataPath + "/StreamingAssets/uriByJson.json");
        path = JsonUtility.FromJson<URIPath>(sr.ReadToEnd());
        sr.Close();
        sceneName = path.sceneName;
        uri = path.path;

        if (!string.IsNullOrEmpty(uri)) {
            StartCoroutine(LoadAssetBundle());
        } else {
            Debug.Log("找不到该地址");
        }
    }
    IEnumerator GetWWWURI() {
        //获取地址,各个平台uri地址都不同,所以要用System.uri转换
        var _uri = new System.Uri(Path.Combine(Application.streamingAssetsPath, "uriByJson.json"));
        UnityWebRequest request = UnityWebRequest.Get(_uri);
        yield return request.SendWebRequest();
        if (request.isDone) {
            StringReader sr = new StringReader(request.downloadHandler.text);
            string s = sr.ReadToEnd();
            sr.Close();
            //Debug.Log(s);

            //用Json读取文件
            path = JsonUtility.FromJson<URIPath>(s);
            uri = path.path;
            sceneName = path.sceneName;

            //用XML读取文件
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(request.downloadHandler.text);
            //XmlNodeList nodeList = xmlDoc.FirstChild.ChildNodes;
            //foreach (XmlNode node in nodeList) {
            //    if (node.Name == "sceneName") sceneName = node.InnerText;
            //    else if (node.Name == "path") uri = node.InnerText;
            //}

            if (!string.IsNullOrEmpty(uri)) {
                StartCoroutine(LoadAssetBundle());
            } else {
                Debug.Log("找不到该地址");
            }
        }
        request.Dispose();
    }

    //IEnumerator LoadScene() {
    //    //string uri = @"http://localhost/AssetBundles/WebGL/scenes/" + SceneName;
    //    UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri + SceneName);
    //    yield return request.SendWebRequest();
    //    AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
    //    //string[] strs = ab.GetAllScenePaths();
    //    //foreach (string s in strs) {
    //    //    Debug.Log(s);
    //    //}
    //    SceneManager.LoadScene(SceneName);

    //    //本地加载依赖
    //    AssetBundle manifestAB = AssetBundle.LoadFromFile("AssetBundles/WebGL/WebGL");
    //    AssetBundleManifest manifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
    //    //foreach (string name in manifest.GetAllAssetBundles()) {
    //    //    Debug.Log(name);
    //    //}
    //    string[] str = manifest.GetAllDependencies("scenes/" + SceneName);
    //    foreach (string name in str) {
    //        //Debug.Log(name);
    //        AssetBundle ab2 = AssetBundle.LoadFromFile("AssetBundles/WebGL/" + name);
    //    }

    //}
    IEnumerator LoadAssetBundle() {
        //string uri = "http://localhost/AssetBundles/WebGL/";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri + "WebGL");
        yield return request.SendWebRequest();
        AssetBundle abManifest = DownloadHandlerAssetBundle.GetContent(request);
        assetBundle.Add(abManifest);

        //网络加载依赖
        manifest = abManifest.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //先加载依赖
        string[] sceneDepends = manifest.GetAllDependencies("scenes/" + sceneName);
        foreach (string name in sceneDepends) {
            //Debug.Log(name);
            UnityWebRequest requestDepend = UnityWebRequestAssetBundle.GetAssetBundle(uri + name);
            yield return requestDepend.SendWebRequest();
            AssetBundle abDepend = DownloadHandlerAssetBundle.GetContent(requestDepend);
            assetBundle.Add(abDepend);
        }
        //再加载场景
        //foreach (string name in manifest.GetAllAssetBundles()) {
        //    Debug.Log(name);
        //}
        UnityWebRequest requestScene = UnityWebRequestAssetBundle.GetAssetBundle(uri + "scenes/" + sceneName);
        yield return requestScene.SendWebRequest();
        AssetBundle abScene = DownloadHandlerAssetBundle.GetContent(requestScene);
        assetBundle.Add(abScene);
        SceneManager.LoadScene(sceneName);
    }
    [System.Serializable]
    public class URIPath {
        public string sceneName;
        public string path;
    }
}
