using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSystem : MonoBehaviour {

    // Field
    [SerializeField] private int                sequensNum;
    [SerializeField] private SceneObject        loadingScene;
    [SerializeField] private List<SceneObject>  sceneSequens;

    private bool isPreLoad;

    // Property

    // Method
    public  void        LoadScene           (int index) {

        StateManager.GetSetState = STATE.LOAD;

        ScreenCapture.CaptureScreenshot("Assets/00_System/DontTouch/capture.png");
        StartCoroutine("PreLoad", index);
    }
    private IEnumerator PreLoad             (int index) {

        if (loadingScene != null) SceneManager.LoadSceneAsync(loadingScene);

        sequensNum = (index >= 0) ? index : ++sequensNum;
        sequensNum = (sequensNum < sceneSequens.Count) ? sequensNum : 0;

        var async = SceneManager.LoadSceneAsync(sceneSequens[sequensNum]);
        async.allowSceneActivation = false;

        while (!async.isDone && isPreLoad) { yield return null; }

        StateManager.GetSetState = STATE.EVENT;
        async.allowSceneActivation  = true;
        isPreLoad                   = false;
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
