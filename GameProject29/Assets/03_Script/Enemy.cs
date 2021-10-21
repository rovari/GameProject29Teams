using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Facade {

    // Hide  Property ==========================================================================================
    private float   _defHp;
    private int     _defLife;

    // Show  Property =============================================
    [SerializeField][Range(0.0f, 1.0f)] private float   _hp;
    [SerializeField]                    private int     _life;
    
    // User  Method ===============================================
    private void Awake  () {
        GetSetPosition = transform.position;
        _defHp      = _hp;
        _defLife    = _life;
    }

    private void OnDisable() {
        _hp         = _defHp;
        _life       = _defLife;
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
