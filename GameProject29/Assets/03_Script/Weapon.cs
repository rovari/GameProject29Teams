using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    
    // Hide  Property =============================================
    protected   bool _recast;
    public      enum UITYPE {
        AIM,
        LOCK,
    }

    // Show  Property =============================================
    [SerializeField] protected UITYPE       _uiType;
    [SerializeField] protected float        _recastTime;
    [SerializeField] protected float        _interval;
    [SerializeField] protected List<Bullet> _bulletList;
    [SerializeField] protected Vector3      _muzzle;
    [SerializeField] protected GameObject   _target;
    
    // User  Method ===============================================
    public  void    Lunch       (Vector3 muzzle, GameObject target) {
        
        if (!_recast) {

            _muzzle = muzzle;
            _target = target;

            StartCoroutine("TimeLine");
        }
    }
    public  UITYPE  GetUIType   () {
        return _uiType;
    }
    virtual public IEnumerator TimeLine() {

        _recast = true;

        _bulletList[0].GetComponent<Bullet>().StartBullet(_muzzle ,_target);

        yield return new WaitForSeconds(_recastTime);
        _recast = false;
    }
}
