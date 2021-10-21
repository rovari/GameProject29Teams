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
    public static float GetSetScore { get; set; } = 0.0f;
    public static STATE GetSetState { get; set; } = STATE.MENU;
}
