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
    [SerializeField] private PlayableAsset talkTL;
    [SerializeField] private PlayableAsset generalTL;
    [SerializeField] private PlayableAsset endTL;

    static private STATE            state;

    static private PlayableDirector director;
    static private PlayableAsset    intro;
    static private PlayableAsset    talk;
    static private PlayableAsset    general;
    static private PlayableAsset    end;

    // Property
    static public  STATE    GetSetState {
        get {
            return state;
        }
        set {
            state = value;
            //AttachInputMaptoState();
        }
    }
    static public  float    GetSetScore     { get; set; }
    static public  bool     GetSetBossDown  { get; set; }

    // Method 
    

    // Unity
	private void Start() {

	}
}
