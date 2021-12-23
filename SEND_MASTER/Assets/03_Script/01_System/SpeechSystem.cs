using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SPEECH_BUBBLE {
    MANUAL,
    NORMAL,
    THORN,
    THINK,
}

[Serializable]
public struct Speech {

    public bool             isButton;
    public SPEECH_BUBBLE    bubble;

    [Multiline(3)]
    public string           speech;
}

public class SpeechSystem : MonoBehaviour {

    // Field
    [SerializeField] private List<Speech> speecheList;

    [Space(10)]
    [SerializeField] private GameObject targetCunvas;
    [SerializeField] private TitleErace titleErace;
    [SerializeField] private GameObject encount;
    [SerializeField] private Image bubbleImage;
    [SerializeField] private Text targetText;

    [Space(10)]
    [SerializeField] private Sprite noneBubble;
    [SerializeField] private Sprite normalBubble;
    [SerializeField] private Sprite thinkBubble;
    [SerializeField] private Sprite thornBubble;

    public bool isThutorial;

    private int currentIndex;
    private int oldIndex;
    private bool isFinish;
    private bool isLock;
    private bool isFadeLock;

    // Property

    // Method
    public  void Speech         () {

        if (speecheList.Count < 0) {

            isLock = true;
            isFinish = true;

            targetCunvas.SetActive(false);
            return;
        }

        if (oldIndex != currentIndex) {

            if (currentIndex == 1) {

                titleErace.StartDissolve();
            }

            targetCunvas.SetActive(true);
            isLock = true;

            if (currentIndex < speecheList.Count) {

                oldIndex = currentIndex;
                AudioManager.PlayOneShot(SOUNDTYPE.GAME, "Speech_Bubble_gse");

                switch (speecheList[currentIndex].bubble) {

                    case SPEECH_BUBBLE.NORMAL:
                        bubbleImage.transform.localScale = new Vector3(2.0f, 1.5f);
                        bubbleImage.sprite = normalBubble;
                        break;

                    case SPEECH_BUBBLE.THINK:
                        bubbleImage.transform.localScale = new Vector3(3.0f, 2.0f);
                        bubbleImage.sprite = thinkBubble;
                        break;

                    case SPEECH_BUBBLE.THORN:
                        bubbleImage.transform.localScale = new Vector3(3.5f, 2.5f);
                        bubbleImage.sprite = thornBubble;
                        break;

                    default:
                        bubbleImage.transform.localScale = new Vector3(3.0f, 3.0f);
                        bubbleImage.sprite = noneBubble;
                        break;
                }
            }
            else {

                targetCunvas.SetActive(false);
                isFinish = true;
                if (!isThutorial) encount.SetActive(true);
                return;
            }

            targetText.text = speecheList[currentIndex].speech;
            isLock = false;
        }
    }
    public  bool GetIsFinish    () {
        return isFinish;
    }
    public  void ThutorialLoad  () {

        if (!isFadeLock) {
            isFadeLock = true;
            StartCoroutine("FadeLoad");
        }
    }
    
    private void AddIndex       () {
        if (!isLock && speecheList[currentIndex].isButton) ++currentIndex;
    }

    private IEnumerator FadeLoad() {

        float time = 3.0f;

        AudioManager.ShmoothFade(true, time, 0.0f);

        yield return new WaitForSecondsRealtime(time);

        LoadManager.Load();
    }


	// Signal
    public  void AddIndexSignal() {

        ++currentIndex;
    }

    // Unity
	private void Start() {

        isLock      = true;
        oldIndex    = -1;
        InputManager.GetEVENTActions().Apply.started += _ => AddIndex();
    }
    
}
