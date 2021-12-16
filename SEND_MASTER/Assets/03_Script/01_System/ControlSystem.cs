using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlSystem : MonoBehaviour {
    
    // Field
    
    // Property
    public PlayerInput      GetSetPlayerInput {
        get; set;
    }
    public MainInputSystem  GetSetMainInput{
        get; set;
    }
    // Method
    public  void StartInput () {
        GetSetMainInput     = new MainInputSystem();
        GetSetPlayerInput   = GetComponent<PlayerInput>();
        GetSetMainInput.Enable();
    }

    // Signal
    
    // Unity

}
