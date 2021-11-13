using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : Facade {

    // Hide  Field ================================================
    private enum SEQUENCE {
        IDLE,
        START,
        ROOP,
        RETURN
    }
    private SEQUENCE            _sequence;
    private float               _defHp;
    private int                 _defLife;
    private float               _activeCount;
    private PlayableDirector    _timeline;

    // Show  Field ================================================
    [SerializeField]                    public  enum GRADE {
        LOWRISK,
        MIDDLERISK,
        HEIGHTRISK,
        BOSS,
        BIGBOSS,W
    }
    [SerializeField]                    private GRADE               _grade;
    [SerializeField]                    private float               _activeTime = 30.0f;
    [SerializeField]                    private PlayableAsset       _startTL;
    [SerializeField]                    private PlayableAsset       _roopTL;
    [SerializeField]                    private PlayableAsset       _returnTL;
    [SerializeField][Range(0.0f, 1.0f)] private float               _hp;
    [SerializeField]                    private int                 _life;
    
    // User  Method ===============================================
    private void Awake      () {
        
        _sequence       = SEQUENCE.IDLE;
        GetSetPosition  = transform.position;
        _defHp          = _hp;
        _defLife        = _life;
    }
    private void Update     () {

        CalcLife();
        TLSequence();
    }
    private void OnDisable  () {
        _hp         = _defHp;
        _life       = _defLife;
    }

    // User  Method ===============================================

    private void        SetSequence () {

        _timeline = GetComponent<PlayableDirector>();
        _timeline.playableAsset = _startTL;

        if (_timeline.playableAsset != null) {
            _sequence = SEQUENCE.START;
            _timeline.Play();
        }
    }
    private void        TLSequence  () {
        
        switch (_sequence) {
            case SEQUENCE.START:

                if (_timeline.time >= _timeline.duration) {

                    _timeline.Stop();
                    _timeline.initialTime   = 0.0f;
                    _timeline.playableAsset = _roopTL;

                    if (_timeline.playableAsset != null) {
                        _sequence = SEQUENCE.ROOP;
                        _timeline.Play();
                    }
                }
                break;

            case SEQUENCE.ROOP:

                if(_activeCount > _activeTime){

                    _activeCount            = 0.0f;
                    _timeline.Stop();
                    _timeline.initialTime   = 0.0f;
                    _timeline.playableAsset = _returnTL;

                    if (_timeline.playableAsset != null) {
                        _sequence = SEQUENCE.RETURN;
                        _timeline.Play();
                    }
                }
                else {
                    _activeCount += Time.deltaTime;

                    if(_timeline.time >= _timeline.duration) {
                        
                        _timeline.Stop();
                        _timeline.initialTime = 0.0f;
                        _timeline.Play();
                    }
                }
                break;

            case SEQUENCE.RETURN:

                if (_timeline.time >= _timeline.duration) {

                    _timeline.Stop();
                    _timeline.initialTime   = 0.0f;
                    _timeline.playableAsset = null;
                    _sequence               = SEQUENCE.IDLE;
                }
                break;
        }
    }
    public  void        CalcLife    () {

        if (_hp <= 0.0f) {

            --_life;

            if (_life < 0) {

                if (_timeline.playableAsset != null) _timeline.Stop();
                _isDestory  = true;
                _life       = _defLife;
                _hp         = _defHp;

            }
        }

        _hp     = (_hp   < 0.0f) ? 0.0f : _hp;
        _life   = (_life < 0)    ? 0    : _life;
    }
    public  GRADE       GetGrade    () {
        return _grade;
    }
    public  bool        GetSetIsDestory{
        get { return _isDestory;  }
        set { _isDestory = value; }
    }
    public  float       GetSetHp       {
        get { return _hp;  }
        set { _hp = value; }
    }
    public  int         GetSetLife     {
        get { return _life; }
        set { _life = value;}
    }
    public  Vector3     GetSetPosition {
        get { return transform.position;  }
        set { transform.position = value; }
    }
    public  GameObject  GetSetTarget   {
        get; set;
    }
}
