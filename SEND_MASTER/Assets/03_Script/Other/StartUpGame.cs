using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartUpGame : MonoBehaviour {

    // Field
    [SerializeField] private bool debugEnable;

    static private StartUpGame  singleton;
    static public  bool         isDebug;
    static public  bool         isLunch;
    
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
    private void Start  () {

        isDebug = debugEnable;
        CreateStartUp();
    }
    private void Update () {

        if (!isLunch) {
            isLunch = true;
            LoadManager.Load(0);
        }

        QuitGame();
    }
}
