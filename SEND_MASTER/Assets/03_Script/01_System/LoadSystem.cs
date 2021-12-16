using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public struct SceneData {
    public SceneObject     Scene;
    public LevelData       Data;
}

public class LoadSystem : MonoBehaviour {

    // Field
    [SerializeField] private bool               isPreLoad;
    [SerializeField] private int                sequensNum;
    [SerializeField] private SceneObject        loadingScene;
    [SerializeField] private List<SceneData>    sceneSequens;
    
    // Property

    // Method
    public  void        LoadScene           (int index) {
        
        ScreenCapture.CaptureScreenshot("Assets/00_System/capture.png");
        StartCoroutine("PreLoad", index);
    }
    public  void        ReLoadScene         () {

        StateManager.GetSetState = STATE.LOAD;
        StartCoroutine("PreLoad", sequensNum);
    }
    private IEnumerator PreLoad             (int index) {

        if (loadingScene != null) SceneManager.LoadSceneAsync(loadingScene);

        sequensNum = (index >= 0) ? index : ++sequensNum;
        sequensNum = (sequensNum < sceneSequens.Count) ? sequensNum : 0;

        var async = SceneManager.LoadSceneAsync(sceneSequens[sequensNum].Scene);
        async.allowSceneActivation      = false;

        while (!async.isDone && !isPreLoad) { yield return null; }
        async.allowSceneActivation      = true;
        isPreLoad                       = false;
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