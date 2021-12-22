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
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    [SerializeField] private Slider vosSlider;

    private float masterVL;
    private float bgmVL;
    private float seVL;
    private float vosVL;

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

        if (StateManager.GetSetState != STATE.MENU) return;

        switch (menuIndex) {

            case MENU_INDEX.RETURN:

                AudioManager.PlayOneShot(SOUNDTYPE.SYSTEM, "Apply_mse");
                ExitMenu();

                break;
            case MENU_INDEX.RETRY:

                AudioManager.PlayOneShot(SOUNDTYPE.SYSTEM, "Apply_mse");
                LoadManager.ReLoad();
                break;

            case MENU_INDEX.EXIT:

                AudioManager.PlayOneShot(SOUNDTYPE.SYSTEM, "Apply_mse");
                
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #elif UNITY_STANDALONE
                UnityEngine.Application.Quit();
                #endif

                break;

            default: break;
        }
    }
    private void AddIndex           () {

        if (StateManager.GetSetState != STATE.MENU) return;
        AudioManager.PlayOneShot(SOUNDTYPE.SYSTEM, "Cursor_mse");

        if (menuIndex < MENU_INDEX.EXIT)    ++menuIndex;
        else menuIndex = MENU_INDEX.RETRY;
    }
    private void SubIndex           () {

        if (StateManager.GetSetState != STATE.MENU) return;
        AudioManager.PlayOneShot(SOUNDTYPE.SYSTEM, "Cursor_mse");

        if (menuIndex > MENU_INDEX.RETRY)   --menuIndex;
        else menuIndex = MENU_INDEX.EXIT;
    }
    private void SliderSelectMenu   () {

        Vector2 stick = InputManager.GetPlayerInput().currentActionMap["VL"].ReadValue<Vector2>();

        masterVL    = (AudioManager.GetVolume(SOUNDTYPE.MASTER) + 80f) * 0.01f;
        bgmVL       = (AudioManager.GetVolume(SOUNDTYPE.BGM) + 80f) * 0.01f;
        seVL        = (AudioManager.GetVolume(SOUNDTYPE.SYSTEM) + 80f) * 0.01f;
        vosVL       = (AudioManager.GetVolume(SOUNDTYPE.VOICE) + 80f) * 0.01f;

        switch (menuIndex) {

            case MENU_INDEX.MASTER_VL:

                masterVL += stick.x * Time.unscaledDeltaTime;
                masterVL = Mathf.Clamp01(masterVL);

                break;

            case MENU_INDEX.BGM_VL:
                bgmVL += stick.x * Time.unscaledDeltaTime;
                bgmVL = Mathf.Clamp01(bgmVL);

                break;
            case MENU_INDEX.SE_VL:
                seVL += stick.x * Time.unscaledDeltaTime;
                seVL = Mathf.Clamp01(seVL);

                break;
            case MENU_INDEX.VOS_VL:
                vosVL += stick.x * Time.unscaledDeltaTime;

                vosVL = Mathf.Clamp01(vosVL);

                break;

            default: break;
        }

        masterSlider.value = masterVL;
        AudioManager.Volume(SOUNDTYPE.MASTER, masterVL);
        bgmSlider.value = bgmVL;
        AudioManager.Volume(SOUNDTYPE.BGM, bgmVL);
        seSlider.value = seVL;
        AudioManager.Volume(SOUNDTYPE.SYSTEM, seVL);
        vosSlider.value = vosVL;
        AudioManager.Volume(SOUNDTYPE.VOICE, vosVL);
    }

    // Signal

    // Unity
    private void Start      () {

        oldState = StateManager.GetSetState;

        StateManager.GetSetState = STATE.GAME;
        InputManager.GetPlayerInput().currentActionMap["Menu"].started += _ => OpenMenu();

        StateManager.GetSetState = STATE.MENU;
        InputManager.GetPlayerInput().currentActionMap["Escape"].started += _ => ExitMenu();
        InputManager.GetPlayerInput().currentActionMap["Apply"] .started += _ => ApplySelectMenu();
        InputManager.GetPlayerInput().currentActionMap["Up"]    .started += _ => SubIndex();
        InputManager.GetPlayerInput().currentActionMap["Down"]  .started += _ => AddIndex();

        StateManager.GetSetState = oldState;




    }
    private void  Update    () {

        if (StateManager.GetSetState == STATE.MENU) SliderSelectMenu();
    }
}
