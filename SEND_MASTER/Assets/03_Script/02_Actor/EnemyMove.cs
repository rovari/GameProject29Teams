using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMY_MOVE { 
    
    // GENERAL
    FIRE_ANIMATION_PLAY,

    POINT_WARP_CENTER,
    POINT_WARP_CENTER_LEFT,
    POINT_WARP_CENTER_RIGHT,

    POINT_WARP_UP,
    POINT_WARP_UP_LEFT,
    POINT_WARP_UP_RIGHT,

    POINT_WARP_DOWN,
    POINT_WARP_DOWN_LEFT,
    POINT_WARP_DOWN_RIGHT,
        
    RAM_ATTAK_FRONT,
    RAM_ATTAK_PLAYER,
    RAM_ATTAK_HOMING,

    TURN_LEFT_HALF,
    TURN_LEFT_ONE,
    TURN_LEFT_TWO,
    TURN_LEFT_THREE,

    TURN_RIGHT_HALF,
    TURN_RIGHT_ONE,
    TURN_RIGHT_TWO,
    TURN_RIGHT_THREE,
    
    SHIVERING,
}

public class EnemyMove : ActorData {

    // Field
    [SerializeField] private EffectData      deadEffect;
    private double          currentTime;

    // Property

    // Method
    private void        LookAt      () {

        if (((Enemy)actor).GetFireSystem().GetTarget() == null) return; 

        actor.GetSetTransform.LookAt(((Enemy)actor).GetFireSystem().GetTarget().transform, Vector3.up);
    }
    private void        CheckDead   () {
        if (actor.GetActorState().life <= 1) StartCoroutine("Dead");
    }
    private IEnumerator Dead        () {

        StateManager.GetSetEnemyDown = true;

        float   period  = 0.5f;
        float   inc     = 1.0f / (period + Mathf.Epsilon);
        float   count   = 0.0f;
        
        GRADE grade =((Enemy)actor).GetGrade();

        if(grade >= GRADE.MIDDLE)   actor.effect.PlayEffect(EFFECT.EXPLOSION,   deadEffect);
        if(grade >= GRADE.BOSS)     actor.effect.PlayEffect(EFFECT.CA,          deadEffect);
        if(grade >= GRADE.BOSS)     actor.effect.PlayEffect(EFFECT.FILL,        deadEffect);
        if(grade >= GRADE.ENDBOSS)  actor.effect.PlayEffect(EFFECT.SLOWMOTION,  deadEffect);

        tag = "Untagged";

        while (period > 0) {

            foreach (var s in actor.surfaceList) {
                s.SetDissolve(count);
            }

            count   += inc * actor.GetActorDeltaTime();
            period  -= actor.GetActorDeltaTime();
            yield return null;
        }

        foreach (var s in actor.surfaceList) {
            s.SetDissolve(1.0f);
        }

        if (grade >= GRADE.BOSS) StateManager.GetSetBossDown = true;

        Destroy(actor.gameObject);
    }

    // Constant Move
    private void        PointWarp   (Vector3 point) {
        actor.GetSetTransform.position = point;
        
        ((Enemy)actor).GetTimeline().Resume();
    }
    private IEnumerator RamAttack   (int index) {

        if (((Enemy)actor).GetFireSystem().GetTarget() == null) {
            yield break;
        }
        
        var calcPos     = actor.GetSetTransform.position;
        var velocity    = Vector3.zero;
        var period      = 1.0f;
        var lastPos     = Vector3.zero;

        var targetPos   = (index == 0) 
            ? actor.GetSetTransform.forward * new Vector3(actor.GetSetTransform.position.x, actor.GetSetTransform.position.y, ((Enemy)actor).GetFireSystem().GetTarget().transform.position.z).magnitude
            : ((Enemy)actor).GetFireSystem().GetTarget().transform.position;
        
        while (period > 0.0f) {

            Vector3 acc = Vector3.zero;

            Vector3 diff;

            if (((Enemy)actor).GetFireSystem().GetTarget()) {

                if(index == 2) { 
                    lastPos = ((Enemy)actor).GetFireSystem().GetTarget().transform.position;
                    diff    = lastPos - transform.position;
                }
                else {
                    diff    = targetPos - transform.position;
                }
            }
            else {

                if(index == 2 && lastPos != Vector3.zero) {
                    diff = lastPos - transform.position;
                }
                else {
                    break;
                }
            }
            
            acc += (diff - velocity * period) * 2f / (period * period);
            
            if (acc.magnitude > 100f) acc = acc.normalized * 500f;
            
            period      -= Time.deltaTime;
            velocity    += acc * Time.deltaTime;

            transform.forward   = velocity.normalized;
            transform.position  = calcPos;
            calcPos += velocity * Time.deltaTime;
            
            yield return null;
        }
        
        ((Enemy)actor).GetTimeline().Resume();
    }
    private IEnumerator Turn        (float radian) {
        
        float period    = 1.0f;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        
        while (period > 0) {

            Quaternion rotY = Quaternion.AngleAxis(radian * actor.GetActorDeltaTime(),Vector3.up);

            transform.localRotation = transform.localRotation * rotY;
            
            count += inc * actor.GetActorDeltaTime();
            period -= actor.GetActorDeltaTime();
            yield return null;
        }

        transform.localRotation = Quaternion.AngleAxis(radian, Vector3.up);

        ((Enemy)actor).GetTimeline().time = currentTime + actor.GetActorDeltaTime();
        ((Enemy)actor).GetTimeline().Resume();
    }
    private IEnumerator Shivering   () {

        var defPos = actor.GetSetTransform.position;

        float period    = 2.0f;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        
        while(period > 0) {
            float nx = UnityEngine.Random.Range(-1.0f, 1.0f) * count * 0.5f;
            float ny = UnityEngine.Random.Range(-1.0f, 1.0f) * count * 0.5f;
            float nz = UnityEngine.Random.Range(-1.0f, 1.0f) * count * 0.5f;

            Quaternion noiseRot = Quaternion.Euler(nx, ny, nz);

            actor.GetSetTransform.rotation = Quaternion.Slerp(
                actor.GetSetTransform.rotation,
                actor.GetSetTransform.rotation * noiseRot,
                Time.time * 5.0f);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        actor.GetSetTransform.position = defPos;
        ((Enemy)actor).GetTimeline().Resume();
    }

    // Signal
    public void         ConstantMove(ENEMY_MOVE move) {

        currentTime = ((Enemy)actor).GetTimeline().time;
        ((Enemy)actor).GetTimeline().Pause();
        
        switch (move) {
            case ENEMY_MOVE.FIRE_ANIMATION_PLAY:        break;

            case ENEMY_MOVE.POINT_WARP_CENTER:          PointWarp(new Vector3(   0.0f, 4.5f, 0.0f)); break;
            case ENEMY_MOVE.POINT_WARP_CENTER_LEFT:     PointWarp(new Vector3( -10.0f, 4.5f, 0.0f)); break;
            case ENEMY_MOVE.POINT_WARP_CENTER_RIGHT:    PointWarp(new Vector3(  10.0f, 4.5f, 0.0f)); break;

            case ENEMY_MOVE.POINT_WARP_DOWN:            PointWarp(new Vector3(   0.0f, 1.0f, 0.0f)); break;
            case ENEMY_MOVE.POINT_WARP_DOWN_LEFT:       PointWarp(new Vector3( -10.0f, 1.0f, 0.0f)); break;
            case ENEMY_MOVE.POINT_WARP_DOWN_RIGHT:      PointWarp(new Vector3(  10.0f, 1.0f, 0.0f)); break;

            case ENEMY_MOVE.POINT_WARP_UP:              PointWarp(new Vector3(   0.0f, 8.0f, 0.0f)); break;
            case ENEMY_MOVE.POINT_WARP_UP_LEFT:         PointWarp(new Vector3( -10.0f, 8.0f, 0.0f)); break;
            case ENEMY_MOVE.POINT_WARP_UP_RIGHT:        PointWarp(new Vector3(  10.0f, 8.0f, 0.0f)); break;

            case ENEMY_MOVE.RAM_ATTAK_FRONT:            StartCoroutine("RamAttack", 0); break;
            case ENEMY_MOVE.RAM_ATTAK_PLAYER:           StartCoroutine("RamAttack", 0); break;
            case ENEMY_MOVE.RAM_ATTAK_HOMING:           StartCoroutine("RamAttack", 0); break;
                    
            case ENEMY_MOVE.TURN_LEFT_HALF:             StartCoroutine("Turn",  90); break;
            case ENEMY_MOVE.TURN_LEFT_ONE:              StartCoroutine("Turn", 180); break;
            case ENEMY_MOVE.TURN_LEFT_TWO:              StartCoroutine("Turn", 360); break; 
            case ENEMY_MOVE.TURN_LEFT_THREE:            StartCoroutine("Turn", 540); break;

            case ENEMY_MOVE.TURN_RIGHT_HALF:            StartCoroutine("Turn", -90); break;
            case ENEMY_MOVE.TURN_RIGHT_ONE:             StartCoroutine("Turn",-180); break;
            case ENEMY_MOVE.TURN_RIGHT_TWO:             StartCoroutine("Turn",-360); break;
            case ENEMY_MOVE.TURN_RIGHT_THREE:           StartCoroutine("Turn",-540); break;

            case ENEMY_MOVE.SHIVERING:                  StartCoroutine("Shivering"); break;

            default: break;
        }
    }
    
    // Unity
	private void Start() {

	}

	// Dependent Update by State
    protected override void GameUpdate   () {
        LookAt      ();
        CheckDead   ();
	}
    protected override void MenuUpdate   () { 

	}
    protected override void LoadUpdate   () { 

	}
    protected override void EventUpdate  () { 

	}
}
