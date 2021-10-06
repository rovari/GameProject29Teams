using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EffectManager : MonoBehaviour {

    // Hide  Property =============================================
    private Output      output;
    private GameObject  camera;

    // Show  Property =============================================

    [Header("<< Camera Shake >>")][Space(5)]
    [SerializeField] private bool           _shake;
    [SerializeField] private float          _shakeSpeed;
    [SerializeField] private float          _shakeLevel;

    [Header("<< Explosion >>")][Space(5)]
    [SerializeField] private bool           _explosion;
    [SerializeField] private float          _explosionTime;
    [SerializeField] private float          _explosionSpeed;
    [SerializeField] private AnimationCurve _explosionCurve;
    
    [Header("<< Fade >>")][Space(5)]
    [SerializeField] private bool           _fade;
    [SerializeField] private bool           _fadeInvers;
    [SerializeField] private float          _fadeTime;
    [SerializeField] private AnimationCurve _FadeCurve;
    
    [Header("<< Fill >>")][Space(5)]
    [SerializeField] private bool           _fill;
    [SerializeField] private Color          _fillColor;
    [SerializeField] private float          _fillTime;
    [SerializeField] private AnimationCurve _fillCurve;

    [Header("<< Vignnet >>")][Space(5)]
    [SerializeField] private bool           _vignnet;
    [SerializeField] private Color          _vignnetColor;
    [SerializeField] private float          _vignnetTime;
    [SerializeField] private AnimationCurve _vignnetCurve;

    [Header("<< Chromatic Aberration >>")][Space(5)]
    [SerializeField] private bool           _chormaticAberration;
    [SerializeField] private float          _chormaticAberrationTime;
    [SerializeField] private AnimationCurve _chormaticAberrationCurve;

    [Header("<< Distorion >>")][Space(5)]
    [SerializeField] private bool           _distorion;
    [SerializeField] private float          _distorionTime;
    [SerializeField] private AnimationCurve _distorionCurve;

    [Header("<< Gauss Blur >>")][Space(5)]
    [SerializeField] private bool           _gauss;
    [SerializeField] private float          _gaussTime;
    [SerializeField] private AnimationCurve _gaussCurve;

    [Header("<< Radial Blur >>")][Space(5)]
    [SerializeField] private bool           _radial;
    [SerializeField] private float          _radialTime;
    [SerializeField] private AnimationCurve _radialCurve;

    // Unity Method ===============================================
    private void Awake      () {

        output = new Output(GameObject.FindGameObjectWithTag("Frame").GetComponent<Image>().material);
        camera = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
    }
    private void Start      () {

    }
    private void Update     () {
        if (_shake)                 CameraShake(_shakeSpeed, _shakeLevel, true);
        //if (_explosion)             ;
        //if (_chormaticAberration)   ;
        //if (_fade)                  ;
        //if (_distorion)             ;
        //if (_fill)                  ;
    }

    // User  Method ===============================================
    public void CameraShake(float speed, float level, bool enable) {

        _shake = enable;

        float t     = Time.time * speed;
        float nx    = ((Mathf.PerlinNoise(t         , t + 0.5f) + 0.025f) * 2.0f - 1.0f) * level;
        float ny    = ((Mathf.PerlinNoise(t + 1.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * level;
        float nz    = ((Mathf.PerlinNoise(t + 2.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * level;

        Quaternion noiseRot         = Quaternion.Euler( nx, ny, nz );
        camera.transform.rotation   = Quaternion.Slerp(transform.rotation, noiseRot, Time.time);
    }
}