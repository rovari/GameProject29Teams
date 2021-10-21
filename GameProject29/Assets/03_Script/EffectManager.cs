using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EffectManager : MonoBehaviour {

    // Hide  Property =============================================
    private Output          output;
    private new GameObject  camera;

    // Show  Property =============================================
    public enum FADE_TYPE {
        COLOR,
        MASK,
        COLORMASK
    }
    
    private AnimationCurve _curve;
    
    [Header("<< Camera Shake >>")][Space(5)]
    [SerializeField] private bool           _shake;
    [SerializeField] private float          _shakeSpeed;
    [SerializeField] private float          _shakeLevel;

    [Header("<< Explosion >>")][Space(5)]
    [SerializeField] private bool           _explosion;
    [SerializeField] private float          _explosionTime;
    [SerializeField] private float          _explosionLevel;
    [SerializeField] private AnimationCurve _explosionCurve;
    
    [Header("<< Fade >>")][Space(5)]
    [SerializeField] private bool           _fade;
    [SerializeField] private bool           _fadeInvers;
    [SerializeField] private Color          _fadeStartColor;
    [SerializeField] private Color          _fadeEndColor;
    [SerializeField] private float          _fadeTime;
    [SerializeField] private AnimationCurve _fadeCurve;
    
    [Header("<< Fill >>")][Space(5)]
    [SerializeField] private bool           _fill;
    [SerializeField] private Color          _fillColor;
    [SerializeField] private float          _fillTime;
    [SerializeField] private AnimationCurve _fillCurve;

    [Header("<< Vignette >>")][Space(5)]
    [SerializeField] private bool           _vignette;
    [SerializeField] private Color          _vignetteColor;
    [SerializeField] private float          _vignetteTime;
    [SerializeField] private float          _vignetteRange;
    [SerializeField] private AnimationCurve _vignetteCurve;

    [Header("<< Chromatic Aberration >>")][Space(5)]
    [SerializeField] private bool           _ca;
    [SerializeField] private float          _chormaticAberrationTime;
    [SerializeField] private AnimationCurve _chormaticAberrationCurve;

    [Header("<< FOV >>")][Space(5)]
    [SerializeField] private bool           _fov;
    [SerializeField] private float          _fovTime;
    [SerializeField] private float          _fovMax;
    [SerializeField] private AnimationCurve _fovCurve;

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

    [Header("<< Time Stop >>")][Space(5)]
    [SerializeField] private bool           _timeStop;
    [SerializeField] private float          _waitTime;

    [Header("<< Slow Motion >>")][Space(5)]
    [SerializeField] private bool           _slowMotion;
    [SerializeField] private float          _slowMotionTime;
    [SerializeField] private AnimationCurve _slowMotionCurve;
    
    // Unity Method ===============================================
    private void Start      () {
        
        _curve      = null;
        output      = new Output(GameObject.FindGameObjectWithTag("Frame").GetComponent<Image>().material);
        camera      = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
    }
    private void Update     () {
        if (_shake)     CameraShake();
    }

    // User  Method ===============================================
    [ContextMenu("DebugEffect")]
    public void         DebugEffect         () {
        DebugEffectPlayer();
    }
    public void         DebugEffectPlayer   (AnimationCurve curve = null){

        _curve = curve;
        
        if (_explosion) StartCoroutine("Explosion");
        if (_fill)      StartCoroutine("Fill");
        if (_fade)      StartCoroutine("Fade");
        if (_vignette)  StartCoroutine("Vignette");
        if (_ca)        StartCoroutine("CA");
        if (_fov)       StartCoroutine("FOV");
        if (_timeStop)  StartCoroutine("TimeStop");
        if (_slowMotion)StartCoroutine("SlowMotion");
    }

    public void         CameraShake () {
        
        float t     = Time.time * _shakeSpeed;
        float nx    = ((Mathf.PerlinNoise(t         , t + 0.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;
        float ny    = ((Mathf.PerlinNoise(t + 1.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;
        float nz    = ((Mathf.PerlinNoise(t + 2.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;

        Quaternion noiseRot         = Quaternion.Euler( nx, ny, nz );
        camera.transform.rotation   = Quaternion.Slerp(transform.rotation, noiseRot, Time.time * 5.0f);
    }  
    public IEnumerator  Explosion   () {
        
        float period    = _explosionTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        if (_curve == null) _curve = _explosionCurve;

        while(period > 0) {
            
            float nx    = (UnityEngine.Random.Range(-1.0f, 1.0f)) * _curve.Evaluate(count) * _explosionLevel;
            float ny    = (UnityEngine.Random.Range(-1.0f, 1.0f)) * _curve.Evaluate(count) * _explosionLevel;
            float nz    = (UnityEngine.Random.Range(-1.0f, 1.0f)) * _curve.Evaluate(count) * _explosionLevel;

            Quaternion noiseRot = Quaternion.Euler( nx, ny, nz );
            camera.transform.rotation  = Quaternion.Lerp(transform.rotation, noiseRot, Time.time * 5.0f);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;;
            yield return null;
        }
    }
    public IEnumerator  Fill        () {
        
        float period    = _fillTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        if (_curve == null) _curve = _fillCurve;

        while (period > 0) {
            output.SetFill(true, _fillColor, _curve.Evaluate(count));

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        output.SetFill(false, _fillColor, 0.0f);
    }
    public IEnumerator  Fade        () {
        
        float period    = _fadeTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        if (_curve == null) _curve = _fadeCurve;

        while (period > 0) {
            output.SetFade( 
                (float)FADE_TYPE.COLOR,
                _fadeInvers,
                Color.Lerp(_fadeStartColor, _fadeEndColor, count),
                _curve.Evaluate(count)
                );
            
            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator  Vignette    () {

        float period    = _vignetteTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        if (_curve == null) _curve = _vignetteCurve;

        while (period > 0) {
            output.SetViggnet(
                true,
                _vignetteColor,
                _curve.Evaluate(count),
                _vignetteRange
                );
            
            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        output.SetViggnet(false, _vignetteColor, 0.0f, 0.0f);
    }
    public IEnumerator  CA          () {

        float period    = _chormaticAberrationTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        if (_curve == null) _curve = _chormaticAberrationCurve;

        while (period > 0) {

            output.SetChromaticAberrtion(
                true,
                _curve.Evaluate(count)
            );

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        output.SetChromaticAberrtion( false, 0.0f);
    }
    public IEnumerator  FOV         () {

        float period    = _fovTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        float defFov    = camera.GetComponent<Camera>().fieldOfView;
        float diff      = _fovMax - defFov;

        if (_curve == null) _curve = _fovCurve;

        while (period > 0) {

            camera.GetComponent<Camera>().fieldOfView = defFov + (diff * _curve.Evaluate(count));

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator  TimeStop    () {
        
        Time.timeScale = 0.0f;

        yield return new WaitForSecondsRealtime(_waitTime);

        Time.timeScale = 1.0f;
    }
    public IEnumerator  SlowMotion  () {

        float period    = _slowMotionTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        
        if (_curve == null) _curve = _slowMotionCurve;

        while (period > 0) {
            
            Time.timeScale = Mathf.Lerp(1.0f, 0.01f,_curve.Evaluate(count));

            count   += inc * Time.unscaledDeltaTime;
            period  -= Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = 1.0f;
    }
}