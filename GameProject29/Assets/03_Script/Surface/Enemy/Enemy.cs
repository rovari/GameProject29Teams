using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : Facade {

    // Hide  Field  ===============================================
    private enum SEQUENCE {
        START,
        ROOP,
        RETURN
    }
    private SEQUENCE    _sequence;
    private float       _defHp;
    private int         _defLife;
    private float       _activeCount;

    // Show  Field ================================================
    [SerializeField]                    public  enum GRADE {
        LOWRISK,
        MIDDLERISK,
        HEIGHTRISK,
        BOSS,
        BIGBOSS,W
    }
    [SerializeField]                    private GRADE               _grade;
    [SerializeField]                    private float               _activeTime;
    [SerializeField]                    private PlayableDirector    startTL;
    [SerializeField]                    private PlayableDirector    roopTL;
    [SerializeField]                    private PlayableDirector    returnTL;
    [SerializeField][Range(0.0f, 1.0f)] private float               _hp;
    [SerializeField]                    private int                 _life;
    
    // User  Method ===============================================
    private void Awake      () {
        GetSetPosition = transform.position;
        _defHp      = _hp;
        _defLife    = _life;
    }
    private void Update     () {

        CalcLife();
        TLSequence();
    }
    private void OnEnable   () {
        if(roopTL != null) startTL.Play();
    }
    private void OnDisable  () {
        _hp         = _defHp;
        _life       = _defLife;
    }

    // User  Method ===============================================

    private void         TLSequence() {

        switch (_sequence) {
            case SEQUENCE.START:

                if(startTL.time >= startTL.duration) {
                    startTL.Stop();
                    startTL.initialTime = 0.0f;
                    if(roopTL != null) roopTL.Play();
                    _sequence = SEQUENCE.ROOP;
                }

                break;

            case SEQUENCE.ROOP:

                _activeCount += Time.deltaTime;

                if(_activeCount >= _activeTime) {
                    roopTL.Stop();
                    roopTL.initialTime = 0.0f;
                    if(returnTL != null) returnTL.Play();
                    _sequence = SEQUENCE.RETURN;
                }

                break;

            case SEQUENCE.RETURN:

                if(returnTL.time >= returnTL.duration) {
                    returnTL.Stop();
                    returnTL.initialTime = 0.0f;
                    _sequence = SEQUENCE.START;
                }
                
                break;
        }   
    }
    
    public  void         CalcLife    () {

        if (_hp <= 0.0f) {

            --_life;

            if (_life < 0) {

                roopTL.Stop();
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
