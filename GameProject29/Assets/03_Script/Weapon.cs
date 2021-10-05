using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    // Hide  Property =============================================
    protected bool _recast;

    // Show  Property =============================================
    [SerializeField] protected float        _recastTime;
    [SerializeField] protected float        _interval;
    [SerializeField] protected List<Bullet> _bulletList;
    
    // User  Method ===============================================
    public  void Lunch(Vector3 muzzle, GameObject target) {

        IEnumerator timeline = TimeLine(muzzle, target);

        if(!_recast) StartCoroutine(timeline);
    }
    virtual public IEnumerator TimeLine(Vector3 muzzle, GameObject target) {

        _recast = true;

        _bulletList[0].GetComponent<Bullet>().StartBullet(muzzle ,target);

        yield return new WaitForSeconds(_recastTime);
        _recast = false;
    }
}
