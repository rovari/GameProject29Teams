using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MENU_CURRENT {
    RETURN,
    RETRY,
    MASTER_VL,
    BGM_VL,
    SE_VL,
    VOS_VL,
    EXIT
}

public class MenuSystem : MonoBehaviour {

    // Field
    [SerializeField] private GameObject menuUI;

    private STATE oldState;
    private float oldTimeScale = 0.0f;
    private float lockTime;
    
    // Property

    // Method
    void OpenMenu() {
        
        AudioManager.ShmoothLowPass(true, false, 0.0f);

        oldState        = StateManager.GetSetState;
        oldTimeScale    = Time.timeScale;
        
        StateManager.GetSetState = STATE.MENU;
        Time.timeScale = 0.0f;
        
        menuUI.SetActive(true);
    }

    void ExitMenu() {
        
        menuUI.SetActive(false);

        Time.timeScale = oldTimeScale;
        StateManager.GetSetState = oldState;
        
        AudioManager.ShmoothLowPass(true, true, 0.0f);
    }


	// Signal

    // Unity
	private void Start() {

         oldState = StateManager.GetSetState;

        StateManager.GetSetState = STATE.GAME;
        InputManager.GetPlayerInput().currentActionMap["Menu"]  .started += _ => OpenMenu();

        StateManager.GetSetState = STATE.MENU;
        InputManager.GetPlayerInput().currentActionMap["Escape"].started += _ => ExitMenu();
        
        StateManager.GetSetState = oldState;
    }
}
