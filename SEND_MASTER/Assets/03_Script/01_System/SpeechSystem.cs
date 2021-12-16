using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SPEECH_BUBBLE {
    NONE,
    NORMAL,
    THORN,
    THINK,
    TUTORIAL
}

[Serializable]
public struct Speech {

    public SPEECH_BUBBLE    bubble;
    public string           speech;
    public Sprite           icon;
    public bool             isUseButton;
}

public class SpeechSystem : MonoBehaviour {

    // Field
    [SerializeField] private List<Speech>   speecheList;

    [Space(10)]
    [SerializeField] private GameObject     targetCunvas;
    [SerializeField] private Image          bubbleImage;
    [SerializeField] private Image          iconImage;
    [SerializeField] private Text           targetText;

    [Space(10)]
    [SerializeField] private Sprite         normalBubble;
    [SerializeField] private Sprite         thinkBubble;
    [SerializeField] private Sprite         thornBubble;
    [SerializeField] private Sprite         tutorialBubble;

    private int     currentIndex;
    private int     oldIndex;
    private bool    isFinish;

    // Property
    
    // Method
    public  void Speech     () {

        if(oldIndex < 0) {
            targetCunvas.SetActive(true);
        }
        
        if(oldIndex != currentIndex) {
            oldIndex = currentIndex;

            switch (speecheList[currentIndex].bubble) {
                
                case SPEECH_BUBBLE.NORMAL:
                    bubbleImage.sprite = normalBubble;             
                    break;

                case SPEECH_BUBBLE.THINK:
                    bubbleImage.sprite = thinkBubble;
                    break;

                case SPEECH_BUBBLE.THORN:
                    bubbleImage.sprite = thornBubble;
                    break;

                case SPEECH_BUBBLE.TUTORIAL:
                    bubbleImage.sprite = tutorialBubble;
                    break;

                default: break;
            }

            targetText.text     = speecheList[currentIndex].speech;
            iconImage.sprite    = speecheList[currentIndex].icon;
        }

        if (speecheList.Count == currentIndex) {
            targetCunvas.SetActive(false);
            isFinish = true;
        }
    }
    private void AddIndex   () {
        if (speecheList[currentIndex].isUseButton) ++currentIndex;
    }
    public  bool GetIsFinish() {
        return isFinish;
    }

	// Signal
    public  void AddIndexSignal() {

        ++currentIndex;
    }

    // Unity
	private void Start() {

        oldIndex = -1;
        //InputManager.GetEVENTActions();
	}
    
}
