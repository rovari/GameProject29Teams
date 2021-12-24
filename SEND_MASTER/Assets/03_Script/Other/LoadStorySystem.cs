using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

[Serializable]
struct LoadStory {

    [Multiline(5)]
    public string story;
    public Sprite sprite;
}

public class LoadStorySystem : MonoBehaviour {

    // Field
    [SerializeField] Text               storyText;
    [SerializeField] Image              storyImage;
    [SerializeField] PlayableDirector   storyTL;
    [SerializeField] List<LoadStory>    storySprites;
    [SerializeField] GameObject         button;
    
    // Property

    // Method
    public void OpenPreLoad         () {

        if (storyTL == null) return;
        if (storyTL.time < storyTL.duration) return;

        LoadManager .OpenLoad();
        StateManager.GetSetState    = STATE.NONE;
    }

    private void SetStoryTexture    () {
        storyImage.sprite   = storySprites[LoadManager.GetSequenceNum()].sprite;
        storyText.text      = storySprites[LoadManager.GetSequenceNum()].story;
    }

	// Signal

    // Unity
	private void Start() {
        StateManager.GetSetState = STATE.LOAD;
        InputManager.GetPlayerInput().currentActionMap["Enter"].started += _ => OpenPreLoad();

        SetStoryTexture();
        button.gameObject.SetActive(false);
	}

    private void Update() {
        if (storyTL.time >= storyTL.duration) button.SetActive(true);
    }
}
