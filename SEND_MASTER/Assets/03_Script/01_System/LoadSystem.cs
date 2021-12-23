using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public struct SceneData {
    public SceneObject      Scene;
    public LevelData        Data;
    public bool             isSkipLoadScene;
}

public class LoadSystem : MonoBehaviour {

    // Field
    [SerializeField] private SceneObject        loadingScene;
    [SerializeField] private List<SceneData>    sceneSequens;
    
    public int  sequensNum;
    public bool isPreLoad;
    public bool isReLoad;

    // Property

    // Method
    public  void        LoadScene           (int index) {

        StateManager.GetSetState = STATE.LOAD;
        ScreenCapture.CaptureScreenshot("Assets/00_System/capture.png");
        StartCoroutine("PreLoad", index);
    }
    public  void        ReLoadScene         () {

        StateManager.GetSetState = STATE.LOAD;
        ScreenCapture.CaptureScreenshot("Assets/00_System/capture.png");

        isReLoad = true;
        StartCoroutine("PreLoad", sequensNum);


    }

    private IEnumerator PreLoad             (int index) {

        SceneData oldSceneData = sceneSequens[sequensNum];

        if (loadingScene != null) {
           if(!oldSceneData.isSkipLoadScene) SceneManager.LoadSceneAsync(loadingScene);
        }

        sequensNum = (index >= 0) ? index : ++sequensNum;
        sequensNum = (sequensNum < sceneSequens.Count) ? sequensNum : 0;

        var async = SceneManager.LoadSceneAsync(sceneSequens[sequensNum].Scene);
        async.allowSceneActivation      = false;
        
        if (!oldSceneData.isSkipLoadScene || isReLoad) {

            while (!async.isDone && !isPreLoad) { yield return null; }
            async.allowSceneActivation = true;
            isPreLoad = false;
        }
        else { 
            async.allowSceneActivation = true;
        }

        isReLoad = false;
        StateManager.GetSetState = STATE.NONE;
    }
    
	// Signal
    public  void        AddIndexLoadSignal  () {
        ++sequensNum;
        LoadScene(sequensNum);
    }
    public  void        OpenLoadSignal      () {
        isPreLoad = true;
    }
    
    // Unity
	private void Start() {

	}
}
