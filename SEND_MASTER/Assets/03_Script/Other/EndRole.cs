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

	}

    private void Update() {

        if (vidoPlayer.isPlaying) {
            LoadManager.Load(0);
        }
    }
}