using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    
    // Hide  Field ================================================
    public      enum        UITYPE {
        AIM,
        LOCK,
        RANGE,
    }
    protected   bool        _recast;
    protected   float       _castCount;
    private     IEnumerator _coroutine;

    // Show  Field ================================================
    [SerializeField] protected UITYPE       _uiType;
    [SerializeField] protected float        _recastTime;
    [SerializeField] protected float        _interval;
    [SerializeField] protected List<Bullet> _bulletList;
    [SerializeField] protected GameObject   _target;

    // Unity  Method ===============================================
    private void Start() {
        GetSetRecastTime = 1.0f;
    }
    
    // User  Method ===============================================
    public              void        Lunch           (GameObject target) {

        if (!_recast && target != null) {
            _target = target;
            
            StartCoroutine("Cast");
            StartCoroutine("TimeLine");
        }
    }
    public              UITYPE      GetUIType       () {
        return _uiType;
    }
    public              float       GetSetRecastTime   {
        get; set;
    }
    private             IEnumerator Cast            () {

        GetSetRecastTime = 0.0f;

        float inc = 1.0f / (_recastTime + Mathf.Epsilon);

        while (1.0f > GetSetRecastTime) {
            GetSetRecastTime += inc * Time.deltaTime;
            yield return null;
        }
        
        GetSetRecastTime = 1.0f;
    }
    virtual protected   IEnumerator TimeLine        () {
        yield return null;
    }
}
