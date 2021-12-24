using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ORBIT {
    NONE,
    SHOT,
    HOMING,
    UNTRACK,
    THROW,
    BLADE,
    ENVIRONMENT,
    BOMB
}

public class Bullet : Actor {

    // Field
    [SerializeField] private Actor      owner;
    [SerializeField] private ORBIT      orbit;
    [SerializeField] private ELEMENT    element;
    [SerializeField] private float      damageTime;
    [SerializeField] private float      flightTime;
    [SerializeField] private Vector3    lunchVector;
    [SerializeField] private Transform  muzzle;

    private bool       isWait;
    private GameObject target;

    // Property

    // Method
    public void StartBullet(ref GameObject inTarget) {

        if (inTarget == null || isWait) return;

        switch (element) {
            case ELEMENT.NORMAL:
                AudioManager.PlayOneShot(SOUNDTYPE.GAME, "Lunch_Normal_gse");
                break;

            case ELEMENT.SPECIAL:
                AudioManager.PlayOneShot(SOUNDTYPE.GAME, "Lunch_Special_gse");
                break;

            default: break;
        }
        
        target = inTarget;
        gameObject.SetActive(true);
        
        switch (orbit) {
            case ORBIT.SHOT:        StartCoroutine("Shot");         break; 
            case ORBIT.HOMING:      StartCoroutine("Homing");       break; 
            case ORBIT.UNTRACK:     StartCoroutine("UnTrack");      break; 
            case ORBIT.THROW:       StartCoroutine("Throw");        break; 
            case ORBIT.BLADE:       StartCoroutine("Blade");        break; 
            case ORBIT.ENVIRONMENT: StartCoroutine("Environment");  break; 
            case ORBIT.BOMB:        StartCoroutine("Bomb");         break; 

            default: break;
        }
    }
    public  ELEMENT     GetElement          () {
        return element;
    } 

    private void        ActiveCollision     (bool active) {
        collision.gameObject.SetActive(active);
    }

    // Lunch Orbits
    private IEnumerator Shot            () {

        if (target == null) yield break;
        isWait = true;
        
        var startPos    = muzzle.position;
        var endPos      = target.transform.position;
        var speed       = flightTime;
        var length      = (startPos - endPos).sqrMagnitude;
        var calcPos     = transform.position;

        ActiveCollision(true);
        
        while ( 0 < length - (startPos - transform.position).sqrMagnitude) {

            calcPos += Vector3.Normalize(endPos - startPos) * speed * Time.deltaTime;
            transform.position = calcPos;
            yield return null;
        }
   
        transform.position = endPos;

        ActiveCollision(false);
      
        transform.position  = muzzle.position;
        transform.rotation  = Quaternion.identity;
        
        gameObject.SetActive(false);
    }
    private IEnumerator Homing          () {
        
        if (target == null) yield break;
        isWait = true;
        
        transform.position = muzzle.position;
        
        var calcPos     = muzzle.position;
        var velocity    = lunchVector;
        var period      = flightTime;
        var lastPos     = Vector3.zero;
        
        while (period > 0.0f) {

            Vector3 acc = Vector3.zero;

            Vector3 diff;

            if (target) {
                lastPos = target.transform.position;
                diff    = lastPos - transform.position;
            }
            else {
                diff = lastPos - transform.position;
            }
            
            acc += (diff - velocity * period) * 2f / (period * period);
            
            if (acc.magnitude > 100f) acc = acc.normalized * 100f;
            
            period      -= Time.deltaTime;
            velocity    += acc * Time.deltaTime;

            transform.forward   = velocity.normalized;
            transform.position  = calcPos;
            calcPos += velocity * Time.deltaTime;
            
            yield return null;
        }
        
        ActiveCollision(true);

        float   count   = damageTime;
        
        while (count > 0.0f) {
            transform.position = calcPos;
            count -= Time.deltaTime;
            yield return null;
        }

        ActiveCollision(false);

        transform.position  = muzzle.position;
        transform.rotation  = Quaternion.identity;

        gameObject.SetActive(false);
    }
    private IEnumerator UnTrack         () {
        
        if (target == null) yield break;
        isWait = true;
        
        transform.position = muzzle.position;
        
        var calcPos     = muzzle.position;
        var velocity    = lunchVector;
        var period      = flightTime;
        var targetPos   = target.transform.position;

        while (period > 0.0f) {

            Vector3 acc = Vector3.zero;
            Vector3 diff;

            if (target) diff = targetPos - transform.position;
            else break;
            
            acc += (diff - velocity * period) * 2f / (period * period);
            
            if (acc.magnitude > 100f) acc = acc.normalized * 100f;
            
            period      -= Time.deltaTime;
            velocity    += acc * Time.deltaTime;

            transform.forward   = velocity.normalized;
            transform.position  = calcPos;
            calcPos += velocity * Time.deltaTime;
            
            yield return null;

        }
        
        ActiveCollision(true);

        float   count   = damageTime;
        
        while (count > 0.0f) {
            transform.position = calcPos;
            count -= Time.deltaTime;
            yield return null;
        }

        ActiveCollision(false);

        transform.position  = muzzle.position;
        transform.rotation  = Quaternion.identity;

        this.gameObject.SetActive(false);
    }
    private IEnumerator Throw           () {
        
        if (target == null) yield break;
        isWait = true;

        var gravity     = -9.8f;
        var startPos    = muzzle.position;
        var endPos      = (target) ? target.transform.position : Vector3.zero;
        var diffY       = (endPos - startPos).y;
        var vn          = (diffY - gravity * 0.5f * flightTime * flightTime) / flightTime;
        var calcPos     = Vector3.zero;
        
        for (var t = 0.0f ; t < flightTime; t += Time.deltaTime) {
            
            calcPos             = Vector3.Lerp(startPos, endPos, t/flightTime);
            calcPos.y           = startPos.y + vn * t + 0.5f * gravity * t * t;
            transform.position  = calcPos;
        
            yield return null;
        }
        
        ActiveCollision(true);

        float count = damageTime;

        while (count > 0.0f) {
            transform.position = calcPos;
            count -= Time.deltaTime;
            yield return null;
        }

        ActiveCollision(false);

        transform.position  = muzzle.position;
        transform.rotation  = Quaternion.identity;

        gameObject.SetActive(false);
    }
    private IEnumerator Blade           () {
        
        if (target == null) yield break;
        isWait = true;
        
        var startPos    = muzzle.position;
        var endPos      = startPos + new Vector3( 0.0f, 0.0f, 30.0f);
        var speed       = 10.0f;
        var length      = (startPos - endPos).sqrMagnitude;
        var calcPos     = transform.position;

        ActiveCollision(true);

        while ( 0 < length - (startPos - transform.position).sqrMagnitude) {
            calcPos += Vector3.Normalize(endPos - startPos) * speed * Time.deltaTime;
            transform.position = calcPos;
            yield return null;
        }

        transform.position = endPos;

        ActiveCollision(false);

        transform.position  = muzzle.position;
        transform.rotation  = Quaternion.identity;
        
        this.gameObject.SetActive(false);
    }
    private IEnumerator Environment     () {

        isWait = true;

        bool useEnvSpeed = false;

        var vector      = (owner.transform.forward.z < 0) ? new Vector3(0.0f, 0.0f, -1.0f) : new Vector3(0.0f, 0.0f, 1.0f);
        var speed       = flightTime;
        var startPos    = owner.transform.position - owner.transform.forward * 10.0f;

        transform.position = startPos;

        ActiveCollision(true);

        while (true) {

            startPos += vector * speed;
            transform.position = startPos;
            
            if (vector.z < 0.0f && Vector3.Dot(vector, (Camera.main.transform.position - startPos)) < 0.0f) break;
            if (vector.z > 0.0f && Vector3.Dot(vector, (vector * 100.0f - startPos)) > 0.0f) break;

            yield return null;
        }

        ActiveCollision(false);

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        this.gameObject.SetActive(false);
    }
    private IEnumerator Bomb            () {
        
        isWait = true;
        
        ActiveCollision(true);

        float count = damageTime;

        while (count > 0.0f) {
            transform.position = Vector3.zero;
            count -= Time.deltaTime;
            yield return null;
        }

        ActiveCollision(false);

        transform.position  = Vector3.zero;
        transform.rotation  = Quaternion.identity;

        this.gameObject.SetActive(false);
    }
    
    // Unity
    private new void Start () {
        base.Start();

        gameObject.SetActive(false);
        collision.gameObject.SetActive(false);
    }

    private void OnEnable() {
        GetSetTransform.position = muzzle.position;
    }

    private void OnDisable() {
        isWait = false;
    }
}
