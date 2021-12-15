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

public enum MAIN_TL {
    IDLE,
    INTRO,
    GENERAL,
    TALK,
    RESULT,
}

public class StateManager : MonoBehaviour {

    // Field
    [SerializeField] private PlayableAsset introTL;
    [SerializeField] private PlayableAsset generalTL;
    [SerializeField] private PlayableAsset resultTL;

    static private STATE            state;
    static private MAIN_TL          sequence;
    static private PlayableDirector timeline;
    
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
    private void StartSequence  () {

        timeline = GetComponent<PlayableDirector>();
        sequence = MAIN_TL.IDLE;

        if (introTL) {

            sequence                = MAIN_TL.INTRO;
            timeline.playableAsset  = introTL;
            timeline.Play();
        }
    }
    private void Sequence       () {
        
        switch (sequence) {
            case MAIN_TL.INTRO:

                if(timeline.time >= timeline.duration) {

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = generalTL;

                    if (timeline.playableAsset != null) {
                        sequence = MAIN_TL.TALK;
                    }
                }
                break;

            case MAIN_TL.TALK:

                //if (isFinishTalk) { timeline.Play; sequence = MAIN_TL.GENERAL; } 

                break;

            case MAIN_TL.GENERAL:
                
                if(timeline.time >= timeline.duration) {

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = resultTL;

                    if (timeline.playableAsset != null) {
                        sequence = MAIN_TL.RESULT;
                    }
                }
                break;

            case MAIN_TL.RESULT:

                //if(isResult) { timeline.Play; } 
                if(timeline.time >= timeline.duration) {

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = resultTL;

                    LoadManager.Load();
                }
                
                break;

            default: break;
        }
    }
    
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
	private void Start  () {

        GetSetState = STATE.GAME;
        StartSequence();
	}

    private void Update () {
        Sequence();
    }
}
