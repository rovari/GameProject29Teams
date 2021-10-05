using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EffectManager : MonoBehaviour {

    // Hide  Property =============================================
    private Output      output;
    private new Camera  camera;

    // Show  Property =============================================
    [SerializeField] private bool _shake;
    [SerializeField] private bool _explosion;
    [SerializeField] private bool _chormaticAberration;
    [SerializeField] private bool _fade;
    [SerializeField] private bool _distorion;
    [SerializeField] private bool _fill;
    
    // Unity Method ===============================================
    private void Awake      () {
        output = new Output(GameObject.FindGameObjectWithTag("Frame").GetComponent<Image>().material);
    }
    private void Start      () {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update     () {
        //if (_shake)                 ;
        //if (_explosion)             ;
        //if (_chormaticAberration)   ;
        //if (_fade)                  ;
        //if (_distorion)             ;
        //if (_fill)                  ;
    }
    private void OnDestroy  () {

        output = null;
        GC.Collect();
    }

    // User  Method ===============================================
}