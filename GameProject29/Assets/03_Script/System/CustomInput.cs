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
        
        GAMEActions     = _input.GAME;
        EVENTActions    = _input.EVENT;
        MENUActions     = _input.MENU;
        LOADActions     = _input.LOAD;

        InputManager.LoadInput(this);
        _input.Enable();

        Debug.Log("Set");
    }
    private void    OnDisable   () { _input.Disable(); }
    private void    OnDestroy   () { _input.Dispose(); }

    // User  Method ===============================================
    public  MainInputSystem.GAMEActions     GAMEActions     { get; set; }
    public  MainInputSystem.EVENTActions    EVENTActions    { get; set; }
    public  MainInputSystem.MENUActions     MENUActions     { get; set; }
    public  MainInputSystem.LOADActions     LOADActions     { get; set; }

}
