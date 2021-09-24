using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public  enum BULLET_TYPE {
        SHOT,
        THROW,
        HOMING,
        BOMB,
    };

    public  BULLET_TYPE type = BULLET_TYPE.THROW;

    public  GameObject  muzzle;
    public  GameObject  target;
    public  GameObject  collision;
    public  float       speed;
    public  float       flightTime;
    public  float       damageAreaTime;
    public  Vector3     homingLunchVector;

    private bool        wait;
    
    // Unity Function ===============================================

    private void Start  () {

        wait = false;

        this.gameObject.SetActive(false);
    }

    // User  Function ===============================================

    public  void            SetTarget       (GameObject tg) {
        target = tg;
    }
    
    public  void            StartWeponCalc  () {
        
        switch(type) {
            case BULLET_TYPE.SHOT:
                if (!wait) StartCoroutine("ShotWeapon");
                break;
            case BULLET_TYPE.THROW:
                if (!wait) StartCoroutine("ThrowWeapon");
                break;
            case BULLET_TYPE.HOMING:
                if (!wait) StartCoroutine("HomingWeapon");
                break;
            case BULLET_TYPE.BOMB:
                if (!wait) StartCoroutine("BombWeapon");
                break;
        }
    }

    public  void            ActiveCollision (bool enable){
        collision.SetActive(enable);
    }

    public  IEnumerator     ShotWeapon      () {

        wait = true;
        
        Vector3 startPos    = muzzle.transform.position;
        Vector3 endPos      = (target) ? target.transform.position : Vector3.zero;

        var     period      = 1.0f;
        var     speed       = 1.0f / flightTime;

        while (period > 0.0f) {
            transform.position = Vector3.Lerp(startPos, endPos, 1.0f - period);
            period -= speed * Time.deltaTime;

            yield return null;
        }

        transform.position = endPos;

        ActiveCollision(true);

        float count = damageAreaTime;

        while (count > 0.0f) {
            transform.position = endPos;
            count -= Time.deltaTime;
            yield return null;
        }

        ActiveCollision(false);

        transform.position  = Vector3.zero;
        transform.rotation  = Quaternion.identity;
        wait                = false;

        this.gameObject.SetActive(false);

        yield return null;
    }

    public  IEnumerator     ThrowWeapon     () {

        wait = true;

        Vector3 endPos = (target) ? target.transform.position : Vector3.zero;
        
        float   speedRate   = speed;
        float   gravity     = -9.8f;
        var     startPos    = muzzle.transform.position;
        var     diffY       = (endPos - startPos).y;
        var     vn          = (diffY - gravity * 0.5f * flightTime * flightTime) / flightTime;
        Vector3 calcPos     = Vector3.zero;
        
        for (var t = 0f; t < flightTime; t += (Time.deltaTime * speedRate)) {
            
            calcPos   = Vector3.Lerp(startPos, endPos, t/flightTime);
            calcPos.y = startPos.y + vn * t + 0.5f * gravity * t * t;
            transform.position = calcPos;
            
            Debug.Log("called");
            yield return null;
        }


        ActiveCollision(true);
        float count = damageAreaTime;

        while (count > 0.0f) {
            transform.position = calcPos;
            count -= Time.deltaTime;
            yield return null;
        }

        ActiveCollision(false);

        transform.position  = Vector3.zero;
        transform.rotation  = Quaternion.identity;
        wait                = false;

        this.gameObject.SetActive(false);
        
        yield return null;
    }
    
    public  IEnumerator     HomingWeapon    () {

        wait = true;
        
        this.transform.position = muzzle.transform.position;

        Vector3 startPos    = muzzle.transform.position;
        Vector3 velocity    = homingLunchVector;
        float   period      = flightTime;
        
        while (period > 0.0f) {

            Vector3 acc = Vector3.zero;

            Vector3 diff;

            diff = (target) 
                ? target.transform.position - transform.position
                : -transform.position;

            acc         += (diff - velocity * period) * 2f / (period * period);
            
            if (acc.magnitude > 100f) acc = acc.normalized * 100f;
            
            period      -= Time.deltaTime;
            velocity    += acc * Time.deltaTime;

            transform.forward   = velocity.normalized;
            transform.position  = startPos;
            startPos += velocity * Time.deltaTime;

            Debug.Log(velocity);
            yield return null;
        }
        

        ActiveCollision(true);

        float count = damageAreaTime;

        while (count > 0.0f) {
            transform.position = target.transform.position;
            count -= Time.deltaTime;
            yield return null;
        }


        ActiveCollision(false);

        transform.position  = Vector3.zero;
        transform.rotation  = Quaternion.identity;
        this.gameObject.SetActive(false);

        wait                = false;

        yield return null;
    }

    public  IEnumerator     BombWeapon      () {

        wait = true;
        
        ActiveCollision(true);

        float count = damageAreaTime;

        while (count > 0.0f) {
            transform.position = Vector3.zero;
            count -= Time.deltaTime;
            yield return null;
        }

        ActiveCollision(false);

        transform.position  = Vector3.zero;
        transform.rotation  = Quaternion.identity;
        wait                = false;

        this.gameObject.SetActive(false);

        yield return null;
    }
}
