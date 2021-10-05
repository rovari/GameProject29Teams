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

    [SerializeField][Range(0.01f, 1.0f)] private float scale = 1;

    //
    private void Update() {
        Time.timeScale = scale;
    }

    // User  Method ===============================================
    public STATE GetSetState { get; set; } = STATE.MENU;


}
