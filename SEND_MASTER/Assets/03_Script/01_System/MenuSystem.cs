using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MENU_INDEX {
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
    [SerializeField] private Slider     masterVL;
    [SerializeField] private Slider     bgmVL;
    [SerializeField] private Slider     seVL;
    [SerializeField] private Slider     vosVL;

    private float       lockTime;
    private float       oldTimeScale;
    private STATE       oldState;
    private MENU_INDEX  menuIndex;

    // Property

    // Method
    private void OpenMenu   () {
        
        AudioManager.ShmoothLowPass(true, false, 0.0f);
        
        oldState        = StateManager.GetSetState;
        oldTimeScale    = Time.timeScale;
        
        StateManager.GetSetState = STATE.MENU;
        Time.timeScale = 0.0f;
        
        menuUI.SetActive(true);
    }
    private void ExitMenu   () {
        
        menuUI.SetActive(false);

        Time.timeScale = oldTimeScale;
        StateManager.GetSetState = oldState;
        
        AudioManager.ShmoothLowPass(true, true, 0.0f);
    }
    private void ApplySelectMenu () {

        switch (menuIndex) {

            case MENU_INDEX.RETURN:
                ExitMenu();

                break;
            case MENU_INDEX.RETRY:
                LoadManager.ReLoad();
                break;

            case MENU_INDEX.EXIT:
                
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #elif UNITY_STANDALONE
                UnityEngine.Application.Quit();
                #endif
                break;

            default: break;
        }
    }
    private void SliderSelectMenu () {

        switch (menuIndex) {

            case MENU_INDEX.MASTER_VL:

                break;
            case MENU_INDEX.BGM_VL:

                break;
            case MENU_INDEX.SE_VL:

                break;
            case MENU_INDEX.VOS_VL:


                break;

            default: break;
        }
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
