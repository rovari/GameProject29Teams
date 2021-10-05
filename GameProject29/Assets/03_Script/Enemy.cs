using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Facade {
    
    // Show  Property =============================================
    [SerializeField][Range(0.0f, 1.0f)] private float   _hp;
    [SerializeField]                    private int     _life;
    
    // User  Method ===============================================
    private void Awake  () {
        GetSetPosition = transform.position;   
    }
    private void Update () {
        transform.position = GetSetPosition;
    }

    // User  Method ===============================================
    public float        GetSetHp        {
        get { return _hp;  }
        set { _hp = value; }
    }
    public int          GetSetLife      {
        get { return _life; }
        set { _life = value;}
    }
    public Vector3      GetSetPosition  { get; set; }
    public GameObject   GetSetTarget    { get; set; }
}
