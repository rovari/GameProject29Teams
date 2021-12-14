using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInput : MonoBehaviour {

    // Hide  Field ================================================
        private MainInputSystem _input;

        // Unity Method ===============================================
        private void    OnEnable    () {

            _input = new MainInputSystem();
            GetSetPlayerInput = GetComponent<PlayerInput>();

            InputManager.LoadInput(this);
            _input.Enable();
        }
        private void    OnDisable   () { _input.Disable(); }
        private void    OnDestroy   () { _input.Dispose(); }
    
        // User  Method ===============================================
        public PlayerInput  GetSetPlayerInput { get; set; }
}
