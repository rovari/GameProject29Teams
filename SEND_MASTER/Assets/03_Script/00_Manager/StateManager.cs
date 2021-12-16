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
    SPEECH,
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
    static private SpeechSystem     speech;
    
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
        sequence = MAIN_TL.INTRO;

        if (introTL) {
            timeline.playableAsset = introTL;
            timeline.Play();
        }
    }
    private void Sequence       () {
        
        switch (sequence) {
            case MAIN_TL.INTRO:
                
                if(timeline.playableAsset && timeline.time >= timeline.duration) {

                    state                   = STATE.EVENT;

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = generalTL;
                    sequence                = MAIN_TL.SPEECH;
                }
                else if (!timeline.playableAsset) {
                    sequence                = MAIN_TL.SPEECH;
                }

                break;

            case MAIN_TL.SPEECH:

                speech.Speech();

                if (speech.GetIsFinish()) {

                    state       = STATE.GAME;
                    sequence    = MAIN_TL.GENERAL;

                    if (timeline.playableAsset != null) timeline.Play();
                } 

                break;

            case MAIN_TL.GENERAL:
                
                if(timeline.playableAsset && timeline.time >= timeline.duration) {

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = resultTL;
                    sequence                = MAIN_TL.RESULT;
                }
                else if (!timeline.playableAsset) {
                    sequence                = MAIN_TL.RESULT;
                }
                break;

            case MAIN_TL.RESULT:

                if(GetSetBossDown) {
                    if (timeline.playableAsset != null) timeline.Play();
                } 

                if(timeline.playableAsset && timeline.time >= timeline.duration) {

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
        
        speech      = GetComponent<SpeechSystem>();
        StartSequence();
	}

    private void Update () {

        Sequence();
    }
}
