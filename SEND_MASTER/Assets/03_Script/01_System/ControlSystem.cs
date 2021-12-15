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

    // Signal
    
    // Unity
    private void Start      () {

	}
    private void OnEnable   () {

        GetSetMainInput     = new MainInputSystem();
        GetSetPlayerInput   = GetComponent<PlayerInput>();


        InputManager.LoadInput(this);
        GetSetMainInput.Enable();
    }
    private void OnDisable  () {
        GetSetMainInput.Disable();
    }
    private void OnDestroy  () {
        GetSetMainInput.Dispose();
    }
}
