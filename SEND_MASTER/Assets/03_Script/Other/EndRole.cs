using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndRole : MonoBehaviour {

    // Field
    [SerializeField] VideoPlayer vidoPlayer;
    // Property

    // Method

	// Signal

    // Unity
	private void Start() {
        vidoPlayer.loopPointReached += _ => Load();
	}

    private void Load() {
        LoadManager.Load();
    }
}
