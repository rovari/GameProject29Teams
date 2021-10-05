using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Facade : MonoBehaviour {
    
    // Hide  Property =============================================
    protected EffectManager effectManager;
    protected Surface       _surface;

    // Show  Property =============================================
    [SerializeField] private string _name;

    // Unity Method ===============================================
    private void Awake      () {

        gameObject.name = _name;
        _surface = new Surface(GetComponent<Renderer>().material);
    }
    private void Start      () {
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

        effectManager =  GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>();
    }
}
