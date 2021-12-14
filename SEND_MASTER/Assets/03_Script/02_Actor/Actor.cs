using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ELEMENT {
    NONE,
    NORMAL,
    SPECIAL
}

public enum TSCALE {
    NONE,
    UNSCALE,
    GAME_UNSCALE
}

[Serializable]
public struct ActorState {

    // Field
    public  bool    isDead;
    public  bool    isInvincible;
    public  bool    isTurbo;
    public  int     life;
    public  float   hp;
    public  float   defence;
    public  ELEMENT resist;

    private int     defLife;
    private float   defHp;

    // Method
    public  void    StateUpdate         () {
        CalcpHp    ();
        CalcLife   ();
    }

    private void    CalcpHp             () {

        hp      = (hp > defHp)
                ? defHp
                : (hp < 0.0f)
                ? 0.0f
                : hp;

        if (hp == 0.0f) --life;
    }
    private void    CalcLife            () {

        life = (life > defLife)
                ? defLife
                : (life < -1)
                ? -1
                : life;

        if (life == -1) isDead = true; 
    }
}

public class Actor : MonoBehaviour {

    // Field
    [SerializeField] private List<MeshRenderer> modelList;
    [SerializeField] private ActorState         actorState;
    [SerializeField] private ActorCollision     collision;
    
    public  List<Surface>   surfaceList;
    public  EffectSystem    effect;

    // Property
    public  Transform       GetSetTransform { get; set; }
    public  GameObject      GetSetTarget    { get; set; }
    public  Vector2         GetSetHitPos    { get; set; }

    // Method
    public  float               GetActorDeltaTime   () {

        float scale = Time.timeScale;
        
        scale = (actorState.isTurbo) ? 1.0f : scale;
        scale = (StateManager.GetSetState != STATE.GAME)
                ? 0.0f : scale;
        
        return Time.unscaledDeltaTime * scale;
    }
    public  Type                GetActorType        () {
        return this.GetType();
    }
    public  ref ActorState      GetActorState       () {
        return ref actorState;
    }
    public  ref ActorCollision  GetActorCollision   () {
        return ref collision;
    }

    // Unity
    private void            Start           () {

    }
    private void            Update          () {
        GetActorState().StateUpdate();
    }
    private void            OnDestroy       () {
        //surface release;
    }
}
