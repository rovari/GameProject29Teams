using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    
    // Field
    static private PlayerInput      _playerInput;

    // Property

    //Method
    static public  void        LoadInput        (ControlSystem input) {
        _playerInput    = input.GetSetPlayerInput;
    }
    static public  PlayerInput GetPlayerInput   () {
        return _playerInput;
    }
    
    // Unity
	private void Start() {

	}
}
