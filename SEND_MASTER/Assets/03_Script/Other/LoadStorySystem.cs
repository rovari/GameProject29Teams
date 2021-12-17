using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
struct LoadStory {

    public string story;
    public Sprite sprite;
}

public class LoadStorySystem : MonoBehaviour {

    // Field
    [SerializeField] List<LoadStory> storySprites;
    [SerializeField] Image  storyImage;
    [SerializeField] Text   storyText;

    // Property

    // Method
    public void OpenPreLoadSystem() {
        LoadManager.GetIsPreLoad() = true;
        StateManager.GetSetState = STATE.NONE;
    }

    private void SetSequenceNumTexture() {
        storyImage.sprite   = storySprites[LoadManager.GetSequenceNum()].sprite;
        storyText.text      = storySprites[LoadManager.GetSequenceNum()].story;
    }

	// Signal

    // Unity
	private void Start() {
        StateManager.GetSetState = STATE.LOAD;
        InputManager.GetLOADActions().Enter.started += _ => OpenPreLoadSystem();
	}
}
