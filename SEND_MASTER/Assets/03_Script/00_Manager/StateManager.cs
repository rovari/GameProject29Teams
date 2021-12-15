using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum STATE {
    NONE,
    MENU,
    GAME,
    LOAD,
    EVENT
}

public class StateManager : MonoBehaviour {

    // Field
    [SerializeField] private PlayableAsset introTL;
    [SerializeField] private PlayableAsset generalTL;
    [SerializeField] private PlayableAsset endTL;

    static private STATE            state;

    static private PlayableDirector director;
    static private PlayableAsset    intro;
    static private PlayableAsset    talk;
    static private PlayableAsset    general;
    static private PlayableAsset    end;

    // Property
    static public  STATE        GetSetState {
        get {
            return state;
        }
        set {
            state = value;
            AttachStateMap();
        }
    }
    static public  float        GetSetScore     { get; set; }
    static public  bool         GetSetBossDown  { get; set; }
    static public  LevelData    GetSetLevelData { get; set; }

    // Method 
    static private void  AttachStateMap () {

        switch (GetSetState) {
            case STATE.GAME:
                InputManager.GetPlayerInput().currentActionMap = InputManager.GetPlayerInput().actions.actionMaps[0];
                break;
            case STATE.LOAD:
                InputManager.GetPlayerInput().currentActionMap = InputManager.GetPlayerInput().actions.actionMaps[1];
                break;
            case STATE.EVENT:
                InputManager.GetPlayerInput().currentActionMap = InputManager.GetPlayerInput().actions.actionMaps[2];
                break;
            case STATE.MENU:
                InputManager.GetPlayerInput().currentActionMap = InputManager.GetPlayerInput().actions.actionMaps[3];
                break;
        }
    }

    // Unity
	private void Start() {

	}
}
