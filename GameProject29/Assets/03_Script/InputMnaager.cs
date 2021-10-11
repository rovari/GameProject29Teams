using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMnaager : MonoBehaviour {

    // Hide  Property =============================================
    private STATE _state;

    private static int _lStick;
    private static int _rStick;
                
    private static int _lTrigger;
    private static int _rTrigger;
            
    private static int _lButton;
    private static int _rButton;
            
    private static int _north;
    private static int _south;
    private static int _east;
    private static int _west;
            
    private static int _up;
    private static int _down;
    private static int _left;
    private static int _right;
            
    private static int _start;
    private static int _select;
    
    public void OnLeftStick     (InputAction.CallbackContext context) { _lStick     = context.ReadValue<int>(); }
    public void OnRightStick    (InputAction.CallbackContext context) { _rStick     = context.ReadValue<int>(); }
    public void OnLeftTrgger    (InputAction.CallbackContext context) { _lTrigger   = context.ReadValue<int>(); }
    public void OnRightTrgger   (InputAction.CallbackContext context) { _rTrigger   = context.ReadValue<int>(); }
    public void OnLeftButton    (InputAction.CallbackContext context) { _lButton    = context.ReadValue<int>(); }
    public void OnRightButton   (InputAction.CallbackContext context) { _rButton    = context.ReadValue<int>(); }
    public void OnNorth         (InputAction.CallbackContext context) { _north      = context.ReadValue<int>(); }
    public void OnSouth         (InputAction.CallbackContext context) { _south      = context.ReadValue<int>(); }
    public void OnEast          (InputAction.CallbackContext context) { _east       = context.ReadValue<int>(); }
    public void OnWest          (InputAction.CallbackContext context) { _west       = context.ReadValue<int>(); }
    public void OnUp            (InputAction.CallbackContext context) { _up         = context.ReadValue<int>(); }
    public void OnDown          (InputAction.CallbackContext context) { _down       = context.ReadValue<int>(); }
    public void OnLeft          (InputAction.CallbackContext context) { _left       = context.ReadValue<int>(); }
    public void OnRight         (InputAction.CallbackContext context) { _right      = context.ReadValue<int>(); }
    public void OnStart         (InputAction.CallbackContext context) { _start      = context.ReadValue<int>(); }
    public void OnSelect        (InputAction.CallbackContext context) { _select     = context.ReadValue<int>(); }

    // Show  Property =============================================

    // Unity Method ===============================================
    private void Update() {
        _state = StateManager.GetSetState;
    }

    // User  Method ===============================================
    public static int  GetLeftStick     () { return _lStick; }
    public static int  GetRightStick    () { return _rStick; }
    public static int  GetLeftTrgger    () { return _lTrigger; }
    public static int  GetRightTrgger   () { return _rTrigger; }
    public static int  GetLeftButton    () { return _lButton; }
    public static int  GetRightButton   () { return _rButton; }
    public static int  GetNorth         () { return _north; }
    public static int  GetSouth         () { return _south; }
    public static int  GetEast          () { return _east; }
    public static int  GetWest          () { return _west; }
    public static int  GetUp            () { return _up; }
    public static int  GetDown          () { return _down; }
    public static int  GetLeft          () { return _left; }
    public static int  GetRight         () { return _right; }
    public static int  GetSelect        () { return _select; }
    public static int  GetStart         () { return _start; }
}
