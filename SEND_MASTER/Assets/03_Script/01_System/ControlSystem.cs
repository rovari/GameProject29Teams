using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlSystem : MonoBehaviour {
    
    // Field
    private MainInputSystem input;
	
    public  PlayerInput  GetSetPlayerInput {
        get; set;
    }
    // Property

    // Method

	// Signal
    

    // Unity
	private void Start      () {

	}
    private void OnEnable   () {

        input = new MainInputSystem();
        GetSetPlayerInput = GetComponent<PlayerInput>();

        InputManager.LoadInput(this);
        input.Enable();
    }
    private void OnDisable  () {
        input.Disable();
    }
    private void OnDestroy  () {
        input.Dispose();
    }
}
