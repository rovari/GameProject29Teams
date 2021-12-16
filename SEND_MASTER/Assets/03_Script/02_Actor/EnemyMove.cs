using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : ActorData {

    // Field
    private EffectData      hitStopEffect;
    private EffectData      deadEffect;

    // Property

    // Method
    private void        LookAt      () {
        if (!actor.GetActorState().isWillDead && actor.GetSetTarget != null)
            actor.GetSetTransform.LookAt(actor.GetSetTarget.transform.position);
    }
    private void        CheckDead   () {
        if (actor.GetActorState().life < 0) StartCoroutine("Dead");
    }
    private IEnumerator Dead        () {
        
        float   period  = deadEffect.time;
        float   inc     = 1.0f / (period + Mathf.Epsilon);
        float   count   = 0.0f;

        actor.effect.PlayEffect(EFFECT.TIMESTOP, hitStopEffect);
        
        GRADE grade =((Enemy)actor).GetGrade();

        if(grade >= GRADE.HIGH)     actor.effect.PlayEffect(EFFECT.EXPLOSION,   deadEffect);
        if(grade >= GRADE.BOSS)     actor.effect.PlayEffect(EFFECT.CA,          deadEffect);
        if(grade >= GRADE.BOSS)     actor.effect.PlayEffect(EFFECT.FILL,        deadEffect);
        if(grade >= GRADE.ENDBOSS)  actor.effect.PlayEffect(EFFECT.SLOWMOTION,  deadEffect);

        tag = "Untagged";

        while (period > 0) {

            foreach (var s in actor.surfaceList) {
                s.SetDissolve(1.0f - count);
            }

            count   += inc * actor.GetActorDeltaTime();
            period  -= actor.GetActorDeltaTime();
            yield return null;
        }

        foreach (var s in actor.surfaceList) {
            s.SetDissolve(0.0f);
        }

        Destroy(actor.gameObject);
    }

    // Signal

    // Unity
	private void Start() {

	}

	// Dependent Update by State
    protected override void GameUpdate   () {
        //LookAt      ();
        CheckDead   ();
	}
    protected override void MenuUpdate   () { 

	}
    protected override void LoadUpdate   () { 

	}
    protected override void EventUpdate  () { 

	}
}
