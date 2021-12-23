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
    public  bool    isWillDead;
    public  bool    isPlayer;

    [HideInInspector] public  bool    isInvincible;
    [HideInInspector] public  bool    isTurbo;

    public  int     life;
    public  float   hp;
    public  float   defence;
    public  ELEMENT resist;

    public int      defLife;
    public float    defHp;

    // Method
    public  void    StateSave           () {
        defLife = life;
        defHp   = hp;
    }
    public  void    StateUpdate         () {
        CalcpHp    ();
        CalcLife   ();
    }
    public  void    CalcDamage          (float inDamage, ELEMENT element) {

        float damage;

        damage = (inDamage * 0.5f) - (defence * 0.25f);
        damage = (resist == element) ? damage : damage * 0.5f;

        hp -= damage;
    }

    private void    CalcpHp             () {

        hp      = (hp > defHp)
                ? defHp
                : (hp < 0.0f)
                ? 0.0f
                : hp;

        if (!isPlayer && hp == 0.0f) --life;
    }
    private void    CalcLife            () {

        life = (life > defLife)
                ? defLife
                : (life < 1)
                ? 1
                : life;

        if (life < 2) isWillDead = true;
        else isWillDead = false;
    }
}

public class Actor : MonoBehaviour {

    // Field
    [SerializeField]  private       List<MeshRenderer>          meshlList;
    [SerializeField]  private       List<SkinnedMeshRenderer>   skinMeshlList;

    [SerializeField]  private       ActorState          actorState;
    [SerializeField]  protected     ActorCollision      collision;
    
    [HideInInspector] public    List<Surface>       surfaceList;
    [HideInInspector] public    EffectSystem        effect;
    
    // Property
    public  Transform           GetSetTransform {
        get { return transform; }
        set {
            transform.position      = value.position;
            transform.rotation      = value.rotation;
            transform.localScale    = value.localScale;
        }
    }
    public  Vector2             GetSetHitPos    { get; set; }

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
    public  bool                IsMeshVisible       () {

        bool visible = true;

        foreach(var m in meshlList) {
            if (!m.isVisible) visible = false;
        }

        return visible;
    }

    // Unity
    protected   void Start      () {

        surfaceList = new List<Surface>();
        effect      = GameObject.FindGameObjectWithTag("Effect").GetComponent<EffectSystem>();

        foreach(var m in meshlList) {
            surfaceList.Add(new Surface(m.material));
        }
        foreach(var m in skinMeshlList) {
            surfaceList.Add(new Surface(m.material));
        }

        actorState.StateSave();
    }
    protected   void Update     () {

        GetActorState().StateUpdate();
    }
}
