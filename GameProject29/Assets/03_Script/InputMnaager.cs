using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMnaager : MonoBehaviour {

    // Show  Property =============================================
    private static MainInputSystem _input;

    // Unity Method ===============================================
    private void    Awake       () {
        _input = new MainInputSystem();

        GetGAMEInput    = _input.GAME;
        GetEVENTInput   = _input.EVENT;
        GetLOADInput    = _input.LOAD;
        GetMENUInput    = _input.MENU;
    }
    private void    OnEnable    () { _input.Enable (); }
    private void    OnDisable   () { _input.Disable(); }
    private void    OnDestroy   () { _input.Dispose(); }

    // User  Method ===============================================
    public  static  MainInputSystem.GAMEActions   GetGAMEInput    { get; set; }
    public  static  MainInputSystem.EVENTActions  GetEVENTInput   { get; set; }
    public  static  MainInputSystem.LOADActions   GetLOADInput    { get; set; }
    public  static  MainInputSystem.MENUActions   GetMENUInput    { get; set; }
}
