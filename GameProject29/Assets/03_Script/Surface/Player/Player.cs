using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Facade {

    // Hide  Field ================================================
    private float   _defHp;
    private int     _defLife;

    // Show  Field ================================================
    [SerializeField][Range(0.0f, 1.0f)] private float   _hp;
    [SerializeField]                    private int     _life;

    // User  Method ===============================================
    private void Awake      () {
        GetSetPosition = transform.position;
        GetSetRotation = transform.rotation;
        _defHp      = _hp;
        _defLife    = _life;
    }
    private void Update     () {
        CalcLife();
    }
    private void OnDisable  () {
        _hp     = _defHp;
        _life   = _defLife;
    }

    // User  Method ===============================================
    public  void         CalcLife()     {

        _hp     = (_hp   < 0.0f) ? 0.0f : _hp;
        _life   = (_life < 0)    ? 0    : _life;
        _hp     = (_hp   > 1.0f) ? 1.0f : _hp;
    }
    public  float        GetSetHp       {
        get { return _hp;  }
        set { _hp = (!GetSetIsInvin) ? value : _hp; }
    }
    public  int          GetSetLife     {
        get { return _life; }
        set { _life = value;}
    }
    public  float        GetSetHitPos   {
        get; set;
    }
    public  bool         GetSetIsTHEW   {
        get; set;
    } = false;
    public  bool         GetSetIsInvin  {
        get; set;
    } = false;
    public  Vector3      GetSetPosition {
        get { return transform.position; }
        set { transform.position = value; }
    }
    public  Quaternion   GetSetRotation {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }
    public  GameObject   GetSetTarget   { get; set; }
}
