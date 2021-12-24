using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public struct SceneData {

    public SceneObject  Scene;
    public LevelData    Data;
    public bool         isSkipLoadScene;
}

public class LoadManager : MonoBehaviour {

    [SerializeField] private List<SceneData> sceneList;
    [SerializeField] private SceneObject     loadScene;

    // Field
    static public int               sequensNum;
    static public AsyncOperation    async;
    static public List<SceneData>   sceneSequens;
    static public SceneObject       loadingScene;

    static private bool             isLock;

    // Property

    // Method
    static public void Load             (int sceneNumber = -1) {

        ScreenCapture.CaptureScreenshot("Assets/00_System/capture.png");
        SceneData oldSceneData = sceneSequens[sequensNum];

        if (loadingScene != null && !oldSceneData.isSkipLoadScene) {
            SceneManager.LoadSceneAsync(loadingScene);
        }
        
        sequensNum = (sceneNumber >= 0) ? sceneNumber : ++sequensNum;
        sequensNum = (sequensNum < sceneSequens.Count) ? sequensNum : 0;
        
        async = SceneManager.LoadSceneAsync(sceneSequens[sequensNum].Scene);
        async.allowSceneActivation  = false;

        if (oldSceneData.isSkipLoadScene) {
            async.allowSceneActivation = true;
        }
    }
    static public void ReLoad           () {

        if (!isLock) {
            isLock = true;

            ScreenCapture.CaptureScreenshot("Assets/00_System/capture.png");

            if (loadingScene != null) {

                SceneManager.LoadSceneAsync(loadingScene);
            }

            async = SceneManager.LoadSceneAsync(sceneSequens[sequensNum].Scene);
            async.allowSceneActivation = false;

            isLock = false;
        }
    }
    static public void OpenLoad         () {
        async.allowSceneActivation = true;
    }
    static public void SetSequenceNum   (int num) {
        sequensNum = num;
    }
    static public int  GetSequenceNum   () {
        return sequensNum;
    }
    static public LevelData GetLevelData() {
        return sceneSequens[sequensNum].Data;
    }


    // Unity
	private void Start() {
        sceneSequens   = sceneList;
        loadingScene   = loadScene;
	}

}
