using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScene : MonoBehaviour {

    // Field
    [SerializeField] VideoPlayer vidoPlayer;
    [SerializeField] bool   isLunch;
    [SerializeField] string fristScene;
    // Property

    // Method

	// Signal

    // Unity
	private void Start() {
        vidoPlayer.loopPointReached += _ => Load();
	}

    private void Load() {

        if (isLunch) SceneManager.LoadScene(fristScene);
        else SceneManager.LoadScene("Lunch");
    }
}
