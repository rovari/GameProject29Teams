using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum STATE {
        MENU,
        GAME,
        LOAD,
        EVENT,
}

public class StateManager : MonoBehaviour {

    // Hide  Field ================================================
    private static PlayableDirector start;
    private static PlayableDirector game;
    private static PlayableDirector result;
    private static STATE            _state;
    
    // Show  Field ================================================
    [SerializeField] private GameObject startTL;
    [SerializeField] private GameObject gameTL;
    [SerializeField] private GameObject resultTL;
    [SerializeField] private TextAsset  csv;
    
    // Property    ================================================
    public static STATE  GetSetState    {
        get {
            return _state;
        }
        set {
            _state = value;
            AttachStateMap();
        }
    }
    public  static float GetSetScore    {
        get; set;
    } = 0.0f;
    public  static bool  GetSetTakeDown {
        get; set;
    } = false;

    // Unity Method ===============================================
    private void Start  () {
        Fetch();

        GetSetState = STATE.GAME;

        LEVEL_CSV data;
        LoadLevelCSV.LoadCSV(csv, out data);
    }

    // User  Method ===============================================
    public  static void  Fetch          () {
        start   = GameObject.Find("StartTL" ).gameObject.GetComponent<PlayableDirector>();
        game    = GameObject.Find("MainTL"  ).gameObject.GetComponent<PlayableDirector>();
        result  = GameObject.Find("ResultTL").gameObject.GetComponent<PlayableDirector>();
    }
    public  static void  CallResult     () {
        GetSetState = STATE.EVENT;
        if(result != null) result.Play();
    }
    private static void  AttachStateMap () {

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
}

