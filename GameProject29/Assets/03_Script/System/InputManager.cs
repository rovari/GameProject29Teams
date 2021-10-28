using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    // Show  Property =============================================
    private static MainInputSystem  _input;
    private static STATE            _state;
    private static bool             _flag;

    // Unity Method ===============================================
    private void    Awake       () {
        
        Initialize();
    }
    private void    OnEnable    () { _input.Enable (); }
    private void    OnDisable   () { _input.Disable(); }
    private void    OnDestroy   () { _input.Dispose(); }

    // User  Method ===============================================
    
    private static  void Initialize() {

        if (!_flag) {
            _input  = new MainInputSystem();
            _flag   = true;        
        }

        _state  = StateManager.GetSetState;

        GetGAMEInput    = _input.GAME;
        GetEVENTInput   = _input.EVENT;
        GetLOADInput    = _input.LOAD;
        GetMENUInput    = _input.MENU;
    }

    public  static  MainInputSystem.GAMEActions   GetGAMEInput    { get; set; }
    public  static  MainInputSystem.EVENTActions  GetEVENTInput   { get; set; }
    public  static  MainInputSystem.LOADActions   GetLOADInput    { get; set; }
    public  static  MainInputSystem.MENUActions   GetMENUInput    { get; set; }
}
