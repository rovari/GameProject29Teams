using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartUpGame : MonoBehaviour {

    // Field
    private StartUpGame singleton;

    // Property

    // Method
    private void CreateStartUp  () {

        if (singleton == null) {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }

        else {
            Destroy(gameObject);
        }
    }
    private void QuitGame       () {
        if (Keyboard.current.escapeKey.isPressed && Keyboard.current.shiftKey.isPressed) { 

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
            #endif
        }
    }
    private void ImportCSV      () {


    }

    // Signal

    // Unity
    private void Awake  () {
        CreateStartUp();
    }
    private void Update () {
        QuitGame();
    }
}
