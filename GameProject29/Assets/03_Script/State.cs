using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

 public enum STATE {

     MENU   = 0,
     GAME,
     LOAD,
     EVENT,
}

public class State : MonoBehaviour
{
    public STATE state;
    public STATE GetSetState { get; set; }

    public float SceneLoadWaitTime = 0.0f;

    private void Awake() { DontDestroyOnLoad(gameObject); }

    private void Start() { state = STATE.GAME; }

    public void StartLoadScenes (string sceneName) {
        StartCoroutine(LoadScene("Load", 0.0f));
        StartCoroutine(LoadScene(sceneName, SceneLoadWaitTime));
    }

    private IEnumerator LoadScene(string sceneName, float minTime) {

        var async = SceneManager.LoadSceneAsync(sceneName);

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(minTime);
        async.allowSceneActivation = true;
    }
}