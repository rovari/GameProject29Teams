using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    
    // Field
    static private ControlSystem controlSystem;

    // Property

    //Method
    public void     LoadInput () {
        controlSystem = GetComponent<ControlSystem>();
        controlSystem.StartInput();
    }

    static public  PlayerInput                  GetPlayerInput  () {
        return controlSystem.GetSetPlayerInput;
    }
    static public  MainInputSystem.GAMEActions  GetGAMEActions  () {
        return controlSystem.GetSetMainInput.GAME;
    }
    static public  MainInputSystem.EVENTActions GetEVENTActions () {
        return controlSystem.GetSetMainInput.EVENT;
    }
    static public  MainInputSystem.MENUActions  GetMENUActions  () {
        return controlSystem.GetSetMainInput.MENU;
    }
    static public  MainInputSystem.LOADActions  GetLOADActions  () {
        return controlSystem.GetSetMainInput.LOAD;
    }
    
    // Unity
	public void Start    () {
        LoadInput();
	}

    public void OnDisable() {
        controlSystem.GetSetMainInput.Disable();
    }

    public void OnDestroy() {
        controlSystem.GetSetMainInput.Dispose();
    }
}
