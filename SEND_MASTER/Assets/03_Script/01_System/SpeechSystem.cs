using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SPEECH_BUBBLE {
    NONE,
    NORMAL,
    THORN,
    THINK
}

[Serializable]
public struct Speech {

    public SPEECH_BUBBLE    bubble;
    public string           talk;
    public float            time;
    public int              icon;
}

public class SpeechSystem : MonoBehaviour {

    // Field
    [SerializeField] private List<Speech> speecheList;

    // Property

    // Method

	// Signal

    // Unity
	private void Start() {

	}
}
