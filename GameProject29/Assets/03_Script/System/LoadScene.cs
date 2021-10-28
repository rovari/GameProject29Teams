using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    static LoadManager loadManager;

    private void Start() {
        loadManager = GetComponent<LoadManager>();
    }

    public static void Load(int sceneNumber = -1) {
        loadManager.LoadScene(sceneNumber);
    }
}
