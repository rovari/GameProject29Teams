using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Facade {

    // Hide  Property =============================================
    private enum ORBIT {
        SHOT,
        THROW,
        HOMING,
        BLADE,
        BOMB,
    }
    private GameObject  col;
    private GameObject  target;
    private bool        _wait;

    // Show  Property =============================================
    [SerializeField] private Transform  muzzle;
    [SerializeField] private ORBIT      _orbit;
    [SerializeField] private float      _flightTime;
    [SerializeField] private float      _damageTime;
    [SerializeField] private Vector3    _lunchVector;

    // Unity Method ===============================================
    private void Start      () {
        col = transform.Find("Collision").gameObject;
        transform.position = muzzle.position;

        gameObject.SetActive(false);
        ActiveCollision     (false);

    }
    private void OnDisable  () {
        _wait = false;
    }
    
    // User  Method ===============================================

    private void ActiveCollision    (bool enable) {
        col.SetActive(enable);
    }
    public  void StartBullet        (GameObject tgt) {

        target = tgt;

        if (!_wait && target != null) { 
            
            IEnumerator bullet = null;

            switch (_orbit) {
                case ORBIT.SHOT:    bullet = Shot();    break;
                case ORBIT.THROW:   bullet = Throw();   break;
                case ORBIT.HOMING:  bullet = Homing();  break;
                case ORBIT.BOMB:    bullet = Bomb();    break;
                case ORBIT.BLADE:   bullet = Blade();   break;
            }

            gameObject.SetActive(true);
            StartCoroutine(bullet);
        }
    }

    private IEnumerator Shot  () {
        
        _wait = true;
        
        var startPos    = muzzle.position;
        var endPos      = (target) ? target.transform.position : Vector3.zero;
        var speed       = 30.0f;
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
    private IEnumerator Blade () {

        _wait = true;
        
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
    private IEnumerator Throw () {

        _wait = true;

        var gravity     = -9.8f;
        var startPos    = muzzle.position;
        var endPos      = (target) ? target.transform.position : Vector3.zero;
        var diffY       = (endPos - startPos).y;
        var vn          = (diffY - gravity * 0.5f * _flightTime * _flightTime) / _flightTime;
        var calcPos     = Vector3.zero;
        
        for (var t = 0.0f ; t < _flightTime; t += Time.deltaTime) {
            
            calcPos             = Vector3.Lerp(startPos, endPos, t/_flightTime);
            calcPos.y           = startPos.y + vn * t + 0.5f * gravity * t * t;
            transform.position  = calcPos;
        
            yield return null;
        }
        
        ActiveCollision(true);
        float count = _damageTime;

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
    private IEnumerator Homing() {

        _wait = true;
        
        transform.position = muzzle.position;
        
        var calcPos     = muzzle.position;
        var velocity    = _lunchVector;
        var period      = _flightTime;
        
        while (period > 0.0f) {

            Vector3 acc = Vector3.zero;

            Vector3 diff;

            diff = (target) 
                ? target.transform.position - transform.position
                : -transform.position;

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

        float   count   = _damageTime;
        
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
    private IEnumerator Bomb  () {

        _wait = true;
        
        ActiveCollision(true);

        float count = _damageTime;

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
}
