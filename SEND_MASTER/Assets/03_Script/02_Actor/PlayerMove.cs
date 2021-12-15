using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : ActorData {

    // Field
    private bool    isJump;
    private float   velocity;
    private float   oldHp;
    private Vector3 defaultPos;

    [SerializeField] private float          jumpPow;
    [SerializeField] private float          maxSpeed;
    [SerializeField] private float          moveSpeed;
    [SerializeField] private float          returnTime;
    [SerializeField] private AnimationCurve blowCurve;
    [SerializeField] private AnimationCurve frictionCurve;

    // Property

    public Vector2 test;

    // Method
    private void        CalcStabillity  () {

        float e = Mathf.Epsilon;
        float f = frictionCurve.Evaluate(actor.GetActorState().hp) * actor.GetActorDeltaTime();

        if (Mathf.Abs(velocity) > 0.0f) velocity += (velocity > 0.0f) ? -f : f;

        velocity = (Mathf.Abs(velocity) < f + e) ? 0.0f : velocity;
    }
    private void        DamageBlow      () {

        float damage = oldHp - actor.GetActorState().hp;

        if (damage > 0 && actor.GetActorState().hp < 1.0f) {

            oldHp = actor.GetActorState().hp;

            float blow = Mathf.Clamp(
                blowCurve.Evaluate(actor.GetActorState().hp) *
                (-damage * 10.0f) * 10.0f, 1.0f, 100.0f);

            blow = (actor.GetSetHitPos.x > actor.GetSetTransform.position.x) ? blow : -blow;

            velocity += blow;
        }
        else if (damage < 0) oldHp = actor.GetActorState().hp;
    }
    private void        Move            () {

        velocity    += Mathf.Lerp   (-moveSpeed, moveSpeed, (InputManager.GetPlayerInput().currentActionMap["Move"].ReadValue<Vector2>().x + 1.0f) * 0.5f) * actor.GetActorDeltaTime();
        velocity    =  Mathf.Clamp  (velocity, -maxSpeed,maxSpeed);
        
        float rot = 1.0f - Vector3.Dot(Vector3.up, Vector3.Normalize(new Vector3(velocity, 1.0f, 0.0f)));
        rot = (velocity < 0.0f) ? rot : -rot;

        actor.GetSetTransform.position += new Vector3(velocity * actor.GetActorDeltaTime(), 0.0f);
        actor.GetSetTransform.rotation = Quaternion.Euler(0.0f, 0.0f, rot * (180.0f / Mathf.PI) * 0.5f);
    }
    private void        PosIsInView     () {

        Rect    rect        = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(actor.GetSetTransform.position);

        if (rect.Contains(viewportPos) && !actor.GetActorState().isDead) StartCoroutine("Dead");
    }

    private IEnumerator Jump            () {

        float power = jumpPow;

        if (!isJump) {

            isJump = true;

            while (defaultPos.y <= actor.GetSetTransform.position.y) {

                actor.GetSetTransform.position += new Vector3(0.0f, power * actor.GetActorDeltaTime(), 0.0f);

                power -= 9.8f * actor.GetActorDeltaTime();
                yield return null;
            }

            actor.GetSetTransform.position
                = new Vector3(
                    actor.GetSetTransform.position.x,
                    defaultPos.y,
                    actor.GetSetTransform.position.z
                    );

            isJump = false;
        }
    }
    private IEnumerator Dead            () {
        
        StateManager.GetSetState = STATE.EVENT;
    
        yield return null;
        // ReloadGame    
    }
    private IEnumerator Return          () {

        StateManager.GetSetState = STATE.EVENT;

        float period    = returnTime;
        float inc       = 1.0f / (period + Mathf.Epsilon); 
        float count     = 0.0f;

        Vector3 returnPos = new Vector3(defaultPos.x, defaultPos.y, defaultPos.z - 10.0f);

        while (period > 0) {

            actor.GetSetTransform.position =
                Vector3.Lerp(returnPos, defaultPos, count);

            count   += inc * actor.GetActorDeltaTime();
            period  += actor.GetActorDeltaTime();

            yield return null;
        }

        actor.GetSetTransform.position = defaultPos;

        StateManager.GetSetState = STATE.GAME;
    }

    // Signal

    // Unity
	private void        Start           () {

        defaultPos = actor.GetSetTransform.position;
        
        InputManager.GetGAMEActions().Jump.started += _ => StartCoroutine("Jump");
    }

    // Dependent Update by State
    protected override void GameUpdate   () {

        CalcStabillity  ();
        DamageBlow      ();
        Move            ();
	}
    protected override void MenuUpdate   () { 

	}
    protected override void LoadUpdate   () { 

	}
    protected override void EventUpdate  () { 

	}
}
