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
    [SerializeField] private Slider masterVL;
    [SerializeField] private Slider bgmVL;
    [SerializeField] private Slider seVL;
    [SerializeField] private Slider vosVL;

    private float lockTime;
    private float oldTimeScale;
    private STATE oldState;
    private MENU_INDEX menuIndex;

    // Property

    // Method
    private void OpenMenu           () {

        AudioManager.ShmoothLowPass(true, false, 0.0f);

        oldState = StateManager.GetSetState;
        oldTimeScale = Time.timeScale;

        StateManager.GetSetState = STATE.MENU;
        Time.timeScale = 0.0f;

        menuUI.SetActive(true);
    }
    private void ExitMenu           () {

        menuUI.SetActive(false);

        Time.timeScale = oldTimeScale;
        StateManager.GetSetState = oldState;

        AudioManager.ShmoothLowPass(true, true, 0.0f);
    }
    private void ApplySelectMenu    () {

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
    private void SliderSelectMenu   () {

        Vector2 stick = InputManager.GetPlayerInput().currentActionMap["VL"].ReadValue<Vector2>();

        switch (menuIndex) {

            case MENU_INDEX.MASTER_VL:
                masterVL.value += (stick.x < 0) ? -0.5f * Time.unscaledDeltaTime : 0.5f * Time.unscaledDeltaTime;
                break;
            case MENU_INDEX.BGM_VL:
                bgmVL.value += (stick.x < 0) ? -0.5f * Time.unscaledDeltaTime : 0.5f * Time.unscaledDeltaTime;
                break;
            case MENU_INDEX.SE_VL:
                seVL.value += (stick.x < 0) ? -0.5f * Time.unscaledDeltaTime : 0.5f * Time.unscaledDeltaTime;
                break;
            case MENU_INDEX.VOS_VL:
                vosVL.value += (stick.x < 0) ? -0.5f * Time.unscaledDeltaTime : 0.5f * Time.unscaledDeltaTime;
                break;

            default: break;
        }
    }
    private void AddIndex           () {
        menuIndex += 1;
    }
    private void SubIndex           () {
        menuIndex -= 1;
    }

    // Signal

    // Unity
    private void Start      () {
        
        InputManager.GetGAMEActions().Menu.started      += _ => OpenMenu        ();
        InputManager.GetMENUActions().Escape.started    += _ => ExitMenu        ();
        InputManager.GetMENUActions().Apply.started     += _ => ApplySelectMenu ();


        StateManager.GetSetState = oldState;
    }
    private void  Update    () {

        if (StateManager.GetSetState == STATE.MENU) SliderSelectMenu();
    }
}
