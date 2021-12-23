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
    SPEECH,
    GENERAL,
    BOSS,
    RESULT,
}

public class StateManager : MonoBehaviour {

    // Field
    [SerializeField] private PlayableAsset  introTL;
    [SerializeField] private PlayableAsset  generalTL;
    [SerializeField] private PlayableAsset  bossTL;
    [SerializeField] private PlayableAsset  resultTL;

    static private STATE            state;
    static private MAIN_TL          sequence;
    static private PlayableDirector timeline;
    static private SpeechSystem     speech;

    static private PlayableAsset    intro;
    static private PlayableAsset    general;
    static private PlayableAsset    boss;
    static private PlayableAsset    result;

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
    static public  bool         GetSetEnemyDown { get; set; }
    static public  bool         GetSetBossDown  { get; set; }
    static public  LevelData    GetSetLevelData { get; set; }
    
    // Method 

    static public  void  StartSequence  () {
        
        sequence = MAIN_TL.IDLE;
        
        if (intro != null && GetSetState != STATE.LOAD) {
            
            AudioManager.Play           (SOUNDTYPE.BGM, "Stage01_bgm");
            AudioManager.Play           (SOUNDTYPE.ENVIRONMENT, "Window_env");

            AudioManager.ShmoothLowPass (true, false, 0.0f);

            AudioManager.Volume         (SOUNDTYPE.BGM, 0.0f);
            AudioManager.ShmoothFade    (true, 3.0f, 10.0f);

            GetSetState = STATE.EVENT;
            sequence    = MAIN_TL.INTRO;
            timeline.playableAsset = intro;
            timeline.Play();
        }
    }

    static private void  Sequence       () {
        
        switch (sequence) {
            case MAIN_TL.INTRO:
                
                if(timeline.playableAsset && timeline.time >= timeline.duration) {

                    GetSetState             = STATE.EVENT;

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = general;
                    sequence                = MAIN_TL.SPEECH;
                }

                break;

            case MAIN_TL.SPEECH:

                speech.Speech();

                if (speech.GetIsFinish()) {

                    GetSetState = STATE.GAME;
                    sequence = MAIN_TL.GENERAL;

                    AudioManager.ShmoothLowPass(true, true, 0.5f);
                    
                    if (timeline.playableAsset != null) timeline.Play();
                }

                break;

            case MAIN_TL.GENERAL:

                if(timeline.playableAsset && timeline.time >= timeline.duration) {
                    
                    timeline.playableAsset  = boss;
                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    sequence                = MAIN_TL.BOSS;

                    AudioManager.SwapBGM(5.0f, "Boss_bgm");
                    if (timeline.playableAsset != null) timeline.Play();
                }
                break;
                
            case MAIN_TL.BOSS:

                if(GetSetBossDown) {

                    GetSetState = STATE.EVENT;
                    
                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = result;
                    sequence                = MAIN_TL.RESULT;

                    AudioManager.SwapBGM(5.0f, "Thutorial_bgm");
                    if (timeline.playableAsset != null) timeline.Play();
                }
                break;

            case MAIN_TL.RESULT:

                double fadeTime = 2.0;

                if(timeline.playableAsset && timeline.time >= timeline.duration) {

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    GetSetBossDown          = false;           
                    LoadManager.Load();
                }
                if(timeline.playableAsset && timeline.time >= timeline.duration - fadeTime) {
                    AudioManager.ShmoothFade(true, (float)fadeTime, 0.0f);
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
            default: break;
        }
    }

    static public  ref PlayableDirector GetTimeLine() {
        return ref timeline;
    }

    // Unity
    private void Start  () {

        intro       = introTL;
        general     = generalTL;
        boss        = bossTL;
        result      = resultTL;

        timeline    = GetComponent<PlayableDirector>();
        speech      = GetComponent<SpeechSystem>();

        StartSequence();
	}

    private void Update () {

        Sequence();
    }
}
