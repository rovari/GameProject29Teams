using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    public enum BULLET_TYPE {
        SHOT,
        THROW,
        HOMING,
        BOMB,
    };

    public BULLET_TYPE type = BULLET_TYPE.THROW;

    public  GameObject  mazzle;
    public  GameObject  target;
    public  GameObject  collision;
    public  float       speed;
    public  float       flightTime;
    public  float       damageAreaTime;

    private bool wait;
    private bool swLR;
    
    private void Start() {
        this.gameObject.SetActive(false);
        wait = false;
        swLR = false;
    }

    public  BULLET_TYPE ReceiveType     () { return type; }
    public  void        StartWeponCalc  () {
        
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
        }
    }

    public  void        ActiveCollision (bool enable){
        collision.SetActive(enable);
    }

    public IEnumerator ShotWeapon() {

        wait = true;

        var     velocity    = target.transform.position - mazzle.transform.position;
        Vector3 startPos    = mazzle.transform.position;
        var     period      = flightTime;

        velocity = velocity.normalized * 10.0f;
        
        while (period > 0.0f) {
            
            startPos += speed * velocity * Time.deltaTime;
            this.transform.position = startPos;

            period -= Time.deltaTime;

            yield return null;
        }

        ActiveCollision(true);

        float count = damageAreaTime;

        while (count > 0.0f)
        {
            transform.position = startPos;
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

    public IEnumerator ThrowWeapon() {

        wait = true;
        
        Vector3 endPos      = target.transform.position;  
        float   speedRate   = speed;
        float   gravity     = -9.8f;
        var     startPos    = mazzle.transform.position;
        var     diffY       = (endPos - startPos).y;
        var     vn          = (diffY - gravity * 0.5f * flightTime * flightTime) / flightTime;
        Vector3 calcPos     = new Vector3(0.0f, 0.0f, 0.0f);
            
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
    
    public IEnumerator HomingWeapon() {

        wait = true;
        
        this.transform.position = mazzle.transform.position;

        Vector3 startPos    = mazzle.transform.position;
        Vector3 velocity    = new Vector3(20.0f, 0.0f, 0.0f);
        float   period      = flightTime;
        
        if (!swLR) velocity *= -1.0f;
        swLR = !swLR;

        while (period > 0.0f) {

            Vector3 acc = Vector3.zero;
            
            var diff    = target.transform.position - transform.position;
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
            transform.position = startPos;
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
}
