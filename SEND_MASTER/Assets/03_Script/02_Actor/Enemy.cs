using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum SEQUENCE {
    IDLE,
    ENCOUNT,
    GENERAL,
    RETURN
}

public enum GRADE {
    NONE,
    LOW,
    MIDDLE,
    HIGH,
    BOSS,
    ENDBOSS
}

public class Enemy : Actor {

    // Field
    [SerializeField] private GRADE          grade;
    [SerializeField] private float          activeTime;
    [SerializeField] private float          activeCount;
    [SerializeField] private PlayableAsset  encountTL;
    [SerializeField] private PlayableAsset  generalTL; 
    [SerializeField] private PlayableAsset  returnTL;

    private SEQUENCE            sequence;
    private PlayableDirector    timeline;

    // Property

    // Method
    public  GRADE   GetGrade    () {
        return grade;
    }

    private void    Sequence    () {

        switch (sequence) {
            case SEQUENCE.ENCOUNT:

                if(timeline.time >= timeline.duration) {

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = generalTL;

                    if (timeline.playableAsset != null) {
                        sequence = SEQUENCE.GENERAL;
                        timeline.Play();
                    }
                }
                break;

            case SEQUENCE.GENERAL:

                if(activeCount > activeTime) {

                    timeline.Stop();
                    activeCount             = 0.0f;
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = returnTL;

                    if(timeline.playableAsset != null) {

                        sequence = SEQUENCE.GENERAL;
                        timeline.Play();
                    }
                }
                else {

                    if(timeline.time >= timeline.duration) {

                        timeline.Stop();
                        timeline.initialTime = 0.0f;
                        timeline.Play();
                    }
                }
                break;

            case SEQUENCE.RETURN:

                if(timeline.time >= timeline.duration) {

                    timeline.Stop();
                    timeline.initialTime    = 0.0f;
                    timeline.playableAsset  = null;
                    sequence                = SEQUENCE.IDLE;
                }
                break;
        }
    }

    // Unity
    private new void Start() {
        base.Start();

        timeline = new PlayableDirector();
    }
}
