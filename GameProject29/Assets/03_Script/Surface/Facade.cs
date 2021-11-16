using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Facade : MonoBehaviour {
    
    // Hide  Field ================================================
    [HideInInspector]   public      Effect      _effect;
    [HideInInspector]   public      Surface     _surface;
                        protected   bool        _isDestory;

    // Show  Field ================================================
    [SerializeField]    private GameObject  model;

    // Unity Method ===============================================
    
    private void Start      () {
        _isDestory  = false;
        _surface    = new Surface(model.GetComponent<MeshRenderer>().material);
        FindManager();
    }
    private void OnDestroy  () {

        _surface = null;
        GC.Collect();
    }

    // User  Method ===============================================
    public  T       GetFacade<T>() where T : Facade {
        return (T)this;
    }
    private void    FindManager () {
        _effect = GameObject.FindGameObjectWithTag("Effect").GetComponent<Effect>();
    }
}
