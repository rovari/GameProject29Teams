using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour {

    // [ Hide Field   ] ===============================================
    private bool    _playerTimeState;
    private float   _oldTimeScale;
    private bool    _lockFrame;

    // [ Show Field   ] ===============================================
    [SerializeField] private GameObject     menuUIObject;
    [SerializeField] private GameObject     gameUIObject;

    // [ Property     ] ===============================================

    // [ Unity Method ] ===============================================
    private void Start() {
        menuUIObject.SetActive(false);

        STATE state = StateManager.GetSetState;

        StateManager.GetSetState = STATE.GAME;
        InputManager.GetPlayerInput().currentActionMap["Menu"]  .started += _ => OpenMenu();

        StateManager.GetSetState = STATE.MENU;
        InputManager.GetPlayerInput().currentActionMap["Escape"].started += _ => ExitMenu();

        StateManager.GetSetState = state;
    }

    private void Update() {
        //ExitMenu();
    }

    // [ User  Method ] ===============================================
    private void OpenMenu() {
        
        _oldTimeScale = Time.timeScale;
        _lockFrame = true;

        StateManager.GetSetState = STATE.MENU;
        Time.timeScale = 0.0f;

        gameUIObject.SetActive(false);
        menuUIObject.SetActive(true);
        
    }

    private void ExitMenu() {

        if (StateManager.GetSetState == STATE.MENU && !_lockFrame) {

            if (InputManager.GetPlayerInput().currentActionMap["Escape"].enabled) {
                menuUIObject.SetActive(false);
                gameUIObject.SetActive(true);

                Time.timeScale = _oldTimeScale;
                StateManager.GetSetState = STATE.GAME;
            }
        }
        else _lockFrame = false;
    }
}
