using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    // Hide  Field ================================================
    private static CustomInput _cInput;
    private static STATE        _state;
    
    // User  Method ===============================================
    public  static  void                            LoadInput(CustomInput input) {

        _cInput = input;
        _state  = StateManager.GetSetState;
        
        GetGAMEInput    = _cInput.GAMEActions;
        GetEVENTInput   = _cInput.EVENTActions;
        GetLOADInput    = _cInput.LOADActions;
        GetMENUInput    = _cInput.MENUActions;
    }
    public  static  MainInputSystem.GAMEActions     GetGAMEInput    { get; set; }
    public  static  MainInputSystem.EVENTActions    GetEVENTInput   { get; set; }
    public  static  MainInputSystem.LOADActions     GetLOADInput    { get; set; }
    public  static  MainInputSystem.MENUActions     GetMENUInput    { get; set; }
}
