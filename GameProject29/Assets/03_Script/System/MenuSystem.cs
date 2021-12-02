using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour {

    // [ Hide Field   ] ===============================================
    private bool    _playerTimeState;
    private float   _oldTimeScale;

    // [ Show Field   ] ===============================================
    [SerializeField] private GameObject     menuObject;

    // [ Property     ] ===============================================

    // [ Unity Method ] ===============================================
    private void Start() {
        menuObject.SetActive(false);
        InputManager.GetPlayerInput().currentActionMap["MenueButton"].started += _ => OpenMenu();
    }
    
    // [ User  Method ] ===============================================
    private void OpenMenu() {

        if (StateManager.GetSetState == STATE.GAME ||  StateManager.GetSetState == STATE.EVENT) {

            _oldTimeScale = Time.timeScale;

            StateManager.GetSetState = STATE.MENU;
            Time.timeScale = 0.0f;

            menuObject.SetActive(true);
        }
    }

    private void ExitMenu() {

        menuObject.SetActive(false);

        Time.timeScale = _oldTimeScale;
        StateManager.GetSetState = STATE.GAME;
    }
}
