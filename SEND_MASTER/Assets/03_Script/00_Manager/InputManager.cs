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
    static public  void                         LoadInput       (ControlSystem input) {
        controlSystem = input;
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
	private void Start() {

	}
}
