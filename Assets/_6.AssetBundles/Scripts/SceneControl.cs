using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


namespace AssetBundles {
    public class SceneControl : MonoBehaviour {

        public string sceneName;

        public void LoadSceneByName() {
            SceneManager.LoadScene(sceneName);
        }
        public void LoadSceneByNameAssetBundle() {
            StartCoroutine(LoadSceneAssetBundle());
        }
        IEnumerator LoadSceneAssetBundle() {
            //string uri = LoadAssetBundlesScene.Get.uri;
            string uri = Application.dataPath + "/AssetBundles/WebGL/";
            Debug.Log(uri + "scenes/" + sceneName);
            //UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri + "WebGL");
            //yield return request.SendWebRequest();
            //AssetBundle abManifest = DownloadHandlerAssetBundle.GetContent(request);

            //网络加载依赖
            //AssetBundleManifest manifest = abManifest.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            //先加载依赖
            string[] sceneDepends = LoadAssetBundlesScene.Get.manifest.GetAllDependencies("scenes/" + sceneName);
            foreach (string name in sceneDepends) {
                Debug.Log(name);
                //if (!LoadAssetBundlesScene.Get.assetBundleName.Contains(name)) {
                UnityWebRequest requestDepend = UnityWebRequestAssetBundle.GetAssetBundle(uri + name);
                yield return requestDepend.SendWebRequest();
                AssetBundle abDepend = DownloadHandlerAssetBundle.GetContent(requestDepend);
                //}
            }
            //再加载场景
            //foreach (string name in manifest.GetAllAssetBundles()) {
            //    Debug.Log(name);
            //}
            UnityWebRequest requestScene = UnityWebRequestAssetBundle.GetAssetBundle(uri + "scenes/" + sceneName);
            yield return requestScene.SendWebRequest();
            AssetBundle abScene = DownloadHandlerAssetBundle.GetContent(requestScene);
            SceneManager.LoadScene(sceneName);
        }
    }
}

