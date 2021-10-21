using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : Facade {

    // Hide  Property =============================================
    private float   _defHp;
    private int     _defLife;

    // Show  Property =============================================
    [SerializeField]                    private PlayableDirector _timeline;
    [SerializeField][Range(0.0f, 1.0f)] private float   _hp;
    [SerializeField]                    private int     _life;
    
    // User  Method ===============================================
    private void Awake      () {
        GetSetPosition = transform.position;
        _defHp      = _hp;
        _defLife    = _life;
    }
    private void Update     () {
        _hp     = (_hp   < 0.0f) ? 0.0f : _hp;
        _life   = (_life < 0)    ? 0    : _life;
    }
    private void OnEnable   () {
        if(_timeline != null) _timeline.Play();
    }
    private void OnDisable  () {
        _hp         = _defHp;
        _life       = _defLife;

        if (_timeline != null) _timeline.initialTime = 0.0;
    }

    // User  Method ===============================================
    public  float        GetSetHp        {
        get { return _hp;  }
        set { _hp = value; }
    }
    public  int          GetSetLife      {
        get { return _life; }
        set { _life = value;}
    }
    public  Vector3      GetSetPosition  {
        get { return transform.position;  }
        set { transform.position = value; }
    }
    public  GameObject   GetSetTarget    { get; set; }
}
