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

    // Hide  Property =============================================
    private static PlayableDirector start;
    private static PlayableDirector game;
    private static PlayableDirector result;
    
    // Show  Property =============================================
    [SerializeField] private GameObject startTL;
    [SerializeField] private GameObject gameTL;
    [SerializeField] private GameObject resultTL;

    // User  Method ===============================================
    private void Start() {
        Fetch();
    }

    // User  Method ===============================================
    public  static void  Fetch       () {
        start   = GameObject.Find("StartTL" ).gameObject.GetComponent<PlayableDirector>();
        game    = GameObject.Find("MainTL"  ).gameObject.GetComponent<PlayableDirector>();
        result  = GameObject.Find("ResultTL").gameObject.GetComponent<PlayableDirector>();
    }
    public  static float GetSetScore    {
        get; set;
    } = 0.0f;
    public  static STATE GetSetState    {
        get; set;
    } = STATE.MENU;
    public  static bool  GetSetTakeDown {
        get; set;
    } = false;
    public  static void  CallResult  () {
        GetSetState = STATE.EVENT;
        if(result != null) result.Play();
    }
}
