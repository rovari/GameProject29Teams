using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Facade {

    // Show  Property =============================================
    [SerializeField][Range(0.0f, 1.0f)] private float   _hp;
    [SerializeField]                    private int     _life;

    // User  Method ===============================================
    private void Awake  () {
        GetSetPosition = transform.position;
        GetSetRotation = transform.rotation;
    }
    private void Update () {
        _hp     = (_hp   < 0.0f) ? 0.0f : _hp;
        _life   = (_life < 0)    ? 0    : _life;
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
        get { return transform.position; }
        set { transform.position = value; }
    }
    public  Quaternion   GetSetRotation  {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }
    public  GameObject   GetSetTarget    { get; set; }
}
