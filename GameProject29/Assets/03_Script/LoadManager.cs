using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LoadManager : MonoBehaviour {
    
    // Show  Property =============================================
    [SerializeField] private RenderTexture      _srcFrame;
    [SerializeField] private RenderTexture      _srcCut;
    [SerializeField] private bool               _DebugPreLoad;
    [SerializeField] private bool               _openPreLoad;
    [SerializeField] private int                _sequensNumber;
    [SerializeField] private SceneObject        _loadingScene;
    [SerializeField] private List<SceneObject>  _sceneSequens;

    // Unity Method ===============================================
    private void Start  () {
        
        if(_sceneSequens.Count > 0)SceneManager.LoadScene(_sceneSequens[_sequensNumber]);
    }
    private void Update () {
        
        if (_DebugPreLoad) {
            LoadScene();
            _DebugPreLoad = false;
        }
    }

    // User  Method ===============================================
    public  void        LoadScene (int sequensNum = -1) {
        
        ScreenCapture.CaptureScreenshot("Assets/Resource/capture.png");
        
        IEnumerator loadScene = PreLoad(sequensNum);
        StartCoroutine(loadScene);
    }
    private IEnumerator PreLoad   (int sequensNum) {
   
        if (_loadingScene != null) SceneManager.LoadSceneAsync(_loadingScene);

        _sequensNumber = (sequensNum >= 0) ? sequensNum : ++_sequensNumber;
        _sequensNumber = (_sequensNumber < _sceneSequens.Count) ? _sequensNumber :  0;

        var async = SceneManager.LoadSceneAsync(_sceneSequens[_sequensNumber]);

        async.allowSceneActivation = false;

        while (!_openPreLoad && !async.isDone) { yield return null; }

        async.allowSceneActivation  = true;
        _openPreLoad                = false;
    }
}
