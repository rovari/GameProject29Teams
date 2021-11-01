using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : Facade {

    // Hide  Property =============================================
    [SerializeField] public  enum GRADE {
        LOWRISK,
        MIDDLERISK,
        HEIGHTRISK,
        BOSS,
        BIGBOSS,
    }
    [SerializeField] private GRADE   _grade;
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

        CalcLife();
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
    public  void         CalcLife    () {

        if (_hp <= 0.0f) {

            --_life;

            if (_life < 0) {

                _isDestory  = true;
                _life       = _defLife;
                _hp         = _defHp;

            }
        }

        _hp     = (_hp   < 0.0f) ? 0.0f : _hp;
        _life   = (_life < 0)    ? 0    : _life;
    }
    public  GRADE        GetGrade    () {
        return _grade;
    }
    public  bool         GetSetIsDestory {
        get { return _isDestory;  }
        set { _isDestory = value; }
    }
    public  float        GetSetHp       {
        get { return _hp;  }
        set { _hp = value; }
    }
    public  int          GetSetLife     {
        get { return _life; }
        set { _life = value;}
    }
    public  Vector3      GetSetPosition {
        get { return transform.position;  }
        set { transform.position = value; }
    }
    public  GameObject   GetSetTarget   { get; set; }
}
