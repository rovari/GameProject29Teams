using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainSystem : MonoBehaviour {
    
    // Show  Field ================================================
    public static MainSystem singleton;

    // Unity Method ===============================================
    private void Awake  () {

        CreateManager();
    }
    private void Start  () {
        
        //LoadScene.Load(0);
    }
    private void Update () {
        Quit();
    }

    // User  Method ===============================================
    private void CreateManager  () {

        if (singleton == null) {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }

        else {
            Destroy(gameObject);
        }
    }
    private void Quit           () {

        if (Keyboard.current.escapeKey.isPressed && Keyboard.current.shiftKey.isPressed) { 

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
            #endif
        }
    }
}
