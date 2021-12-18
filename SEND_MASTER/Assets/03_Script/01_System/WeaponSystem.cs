using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LOCKTYPE {
    NONE,
    AIM,
    LOCK
}

public class WeaponSystem : MonoBehaviour {

    // Field
    [SerializeField] protected Actor        actor;
    [SerializeField] protected LOCKTYPE     lockType;
    [SerializeField] protected float        recastTime;
    [SerializeField] protected float        interval;
    [SerializeField] protected List<Bullet> bulletList;

    [SerializeField] protected   bool        isRecast;
    protected   float       castCount;
    protected   GameObject  target;

    private     IEnumerator coroutine;

    // Property
    
    // Method
    public  void                    Lunch       (GameObject inTarget) {

        if (isRecast || inTarget == null) return;

        target   = inTarget;
        isRecast = true;

        StartCoroutine("TimeLine");
    }
    public  float                   GetRecastNormalize   () {

        if (castCount == 0.0f) return 0.0f;

        return 1.0f / recastTime * castCount;
    }
    public  LOCKTYPE                GetLockType () {
        return lockType;
    }

    private IEnumerator             Cast        () {
        
        float period    = recastTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        while(period > 0) {

            castCount    = count;
            count       += inc * actor.GetActorDeltaTime();
            period      -= actor.GetActorDeltaTime();
            yield return null;
        }

        isRecast = false;
    }

    virtual protected IEnumerator   TimeLine    () {


        foreach (var b in bulletList) {
            b.StartBullet(ref target);
            
            float count = 0.0f;

            while (interval > count) {
                count += actor.GetActorDeltaTime();
                yield return null;
            }
        }
        
       yield return Cast();
    }

    // Unity
	private void Start() {

	}
}
