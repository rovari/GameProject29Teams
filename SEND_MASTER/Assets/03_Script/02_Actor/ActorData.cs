using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorData : MonoBehaviour {

    // Field
    [SerializeField] protected Actor actor;
    
    // Property

    // Method
    protected bool CheckState(STATE state) {
        return (StateManager.GetSetState == state) ? true : false;
    }

    protected virtual void GameUpdate   () { }
    protected virtual void MenuUpdate   () { }
    protected virtual void LoadUpdate   () { }
    protected virtual void EventUpdate  () { }
    
    // Unity
    private void Update() {

        switch (StateManager.GetSetState) {
            case STATE.MENU:    LoadUpdate  (); break;
            case STATE.GAME:    GameUpdate  (); break;
            case STATE.LOAD:    MenuUpdate  (); break;
            case STATE.EVENT:   EventUpdate (); break;
            default: break;
        }
    }
}
