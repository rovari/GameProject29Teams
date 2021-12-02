using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    
    // Hide  Field ================================================-
    private static PlayerInput      _playerInput;
    
    // User  Method ===============================================
    public  static void             LoadInput       (CustomInput input) {
        _playerInput    = input.GetSetPlayerInput;
    }
    
    public  static PlayerInput GetPlayerInput () {
        return _playerInput;
    }
}
