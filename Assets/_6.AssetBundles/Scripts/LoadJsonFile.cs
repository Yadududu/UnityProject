using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadJsonFile : MonoBehaviour {

    public string sceneName;
    public string uri;

    private URIPath path;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(GetWWWURI());
    }

    IEnumerator GetWWWURI() {
        //获取地址,各个平台uri地址都不同,所以要用System.uri转换
        var _uri = new System.Uri(Path.Combine(Application.streamingAssetsPath, "uriByJson.json"));
        UnityWebRequest request = UnityWebRequest.Get(_uri);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError) {
            Debug.Log(request.error);
        } else {
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
                Debug.Log("LoadSuccess");
            } else {
                Debug.Log("找不到该地址");
            }
        }
        request.Dispose();
    }
}
