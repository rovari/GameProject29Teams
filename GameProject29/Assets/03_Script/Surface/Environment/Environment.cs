using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : Facade {

    private float _defHp;
    [SerializeField] [Range(0.0f, 1.0f)] private float _hp;

    private void Awake      () {
        GetSetPosition = transform.position;
        _defHp      = _hp;
    }
    private void Update     () {
        CalcHp();
    }
    public  void         CalcHp    () {

        if (_hp <= 0.0f) {
            
            _isDestory  = true;
            _hp         = _defHp;
        }

        _hp     = (_hp   < 0.0f) ? 0.0f : _hp;
    }
    public  bool         GetSetIsDestory{
        get { return _isDestory;  }
        set { _isDestory = value; }
    }
    public  float        GetSetHp       {
        get { return _hp;  }
        set { _hp = value; }
    }
    public  Vector3      GetSetPosition {
        get { return transform.position;  }
        set { transform.position = value; }
    }
}
