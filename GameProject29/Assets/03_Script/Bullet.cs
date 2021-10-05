using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Hide  Property =============================================
    private enum ORBIT {
        SHOT,
        THROW,
        HOMING,
        BOMB,
    }

    private GameObject  target;
    private Vector3     _muzzle;
    private bool        _wait;

    // Show  Property =============================================
    [SerializeField] private ORBIT   _orbit;
    [SerializeField] private float   _flightTime;
    [SerializeField] private float   _damageTime;
    [SerializeField] private Vector3 _lunchVector;

    // User  Method ===============================================
    public void StartBullet(Vector3 muzzle, GameObject target) {

        if (!_wait) { 
            _muzzle = muzzle;

            IEnumerator bullet = null;

            switch (_orbit) {
                case ORBIT.SHOT:    bullet = Shot();    break;
                case ORBIT.THROW:   bullet = Throw();   break;
                case ORBIT.HOMING:  bullet = Homing();  break;
                case ORBIT.BOMB:    bullet = Bomb();    break;
            }

            StartCoroutine(bullet);
        }
    }
    
    public IEnumerator Shot  () {

        _wait = true;

        yield return null;
        _wait = false;
    }
    public IEnumerator Throw () {

        _wait = true;

        yield return null;
        _wait = false;
    }
    public IEnumerator Homing() {

        _wait = true;

        yield return null;
        _wait = false;
    }
    public IEnumerator Bomb  () {

        _wait = true;

        yield return null;
        _wait = false;
    }
}
