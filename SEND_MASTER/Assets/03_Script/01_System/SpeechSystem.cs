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
}

[Serializable]
public struct Speech {

    public SPEECH_BUBBLE    bubble;
    public string           speech;
    public bool             isButton;
}

public class SpeechSystem : MonoBehaviour {

    // Field
    [SerializeField] private List<Speech>   speecheList;

    [Space(10)]
    [SerializeField] private GameObject     targetCunvas;
    [SerializeField] private Image          bubbleImage;
    [SerializeField] private Text           targetText;

    [Space(10)]
    [SerializeField] private Sprite         normalBubble;
    [SerializeField] private Sprite         thinkBubble;
    [SerializeField] private Sprite         thornBubble;

    private int     currentIndex;
    private int     oldIndex;
    private bool    isFinish;
    private bool    isLock;

    // Property
    
    // Method
    public  void Speech     () {
        
        if (speecheList.Count < 0) {

            isLock      = true;
            isFinish    = true;

            targetCunvas.SetActive(false);
            return;
        }
        
        if(oldIndex != currentIndex) {

            isLock = true;

            if (currentIndex < speecheList.Count) {

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
                        
                    default: break;
                }
            }
            else {
                
                targetCunvas.SetActive(false);
                isFinish = true;
                return;
            }

            targetText.text     = speecheList[currentIndex].speech;
            isLock              = false;
        }
    }
    private void AddIndex   () {
        if (speecheList[currentIndex].isButton && !isLock) ++currentIndex;
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
        InputManager.GetEVENTActions().Apply.started += _ => AddIndex();
	}
    
}
