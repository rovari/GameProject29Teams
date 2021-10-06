using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE {
        MENU,
        GAME,
        LOAD,
        EVENT,
}

public class StateManager : MonoBehaviour {
    
    // User  Method ===============================================
    public STATE GetSetState { get; set; } = STATE.MENU;
}
