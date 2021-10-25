using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Facade : MonoBehaviour {
    
    // Hide  Property =============================================
    [HideInInspector] public Effect     _effect;
    [HideInInspector] public Surface    _surface;

    // Show  Property =============================================
    [SerializeField] private GameObject model;

    // Unity Method ===============================================
    private void Start      () {
        _surface = new Surface(model.GetComponent<MeshRenderer>().material);
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
        _effect =  GameObject.FindGameObjectWithTag("Effect").GetComponent<Effect>();
    }
}
