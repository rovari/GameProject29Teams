using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Effect : MonoBehaviour {

    public enum EFFECT {
        EXPLOSION,
        FILL,
        VIGNETTE,
        CA,
        FOV,
        TIMESTOP,
        SLOWMOTION,
    }
    
    // Hide  Property =============================================
    private Output          output;
    private AnimationCurve  _curve;
    private new GameObject  camera;

    // Show  Property =============================================
    
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
    [SerializeField] private float          _vignetteLevel;
    [SerializeField] private AnimationCurve _vignetteCurve;

    [Header("<< Chromatic Aberration >>")][Space(5)]
    [SerializeField] private bool           _ca;
    [SerializeField] private float          _chormaticAberrationTime;
    [SerializeField] private float          _chormaticAberrationLevel;
    [SerializeField] private AnimationCurve _chormaticAberrationCurve;

    [Header("<< FOV >>")][Space(5)]
    [SerializeField] private bool           _fov;
    [SerializeField] private float          _fovTime;
    [SerializeField] private float          _fovLevel;
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
    public void         PlayEffect (EFFECT effect, float time = 0.0f, AnimationCurve curve = null, float level = 0.0f, Color color = default) {

        IEnumerator c = null;

        switch (effect) {

            case EFFECT.EXPLOSION:
                _explosionTime      = time ;
                _explosionLevel     = level;
                _curve              = curve;
                c = Explosion();
                break;

            case EFFECT.FILL:
                _fillTime           = time;
                _curve              = curve;
                c = Fill();
                break;
                
            case EFFECT.VIGNETTE:
                _vignetteTime       = time;
                _vignetteLevel      = level;
                _curve              = curve;
                c = Vignette();
                break;

            case EFFECT.CA:
                _chormaticAberrationTime    = time;
                _chormaticAberrationLevel   = level;
                _curve                      = curve;
                c = CA();
                break;

            case EFFECT.FOV:
                _fovTime            = time;
                _fovLevel           = level; 
                _curve              = curve;
                c = FOV();
                break;

            case EFFECT.TIMESTOP:
                _waitTime           = time;
                c = TimeStop();
                break;

            case EFFECT.SLOWMOTION:
                _slowMotionTime     = time;
                _curve              = curve;
                c = SlowMotion();
                break;
        }

        if (c != null) StartCoroutine(c);
    }
    
    [ContextMenu("DebugEffect")]
    public  void         DebugEffect         () {
        DebugEffectPlayer();
    }
    public  void         DebugEffectPlayer   (AnimationCurve curve = null){

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

    private void         CameraShake () {
        
        float t     = Time.time * _shakeSpeed;
        float nx    = ((Mathf.PerlinNoise(t         , t + 0.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;
        float ny    = ((Mathf.PerlinNoise(t + 1.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;
        float nz    = ((Mathf.PerlinNoise(t + 2.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;

        Quaternion noiseRot         = Quaternion.Euler( nx, ny, nz );
        camera.transform.rotation   = Quaternion.Slerp(camera.transform.rotation, noiseRot, Time.time * 5.0f);
    }  
    private IEnumerator  Explosion   () {
        
        float period    = _explosionTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve c = _curve;
        if (c == null) c = _explosionCurve;

        while(period > 0) {
            
            float nx    = (UnityEngine.Random.Range(-1.0f, 1.0f)) * c.Evaluate(count) * _explosionLevel;
            float ny    = (UnityEngine.Random.Range(-1.0f, 1.0f)) * c.Evaluate(count) * _explosionLevel;
            float nz    = (UnityEngine.Random.Range(-1.0f, 1.0f)) * c.Evaluate(count) * _explosionLevel;

            Quaternion noiseRot = Quaternion.Euler( nx, ny, nz );
            camera.transform.rotation  = Quaternion.Slerp(camera.transform.rotation, camera.transform.rotation * noiseRot, Time.time * 5.0f);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;;
            yield return null;
        }
    }
    private IEnumerator  Fill        () {
        
        float period    = _fillTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve c = _curve;
        if (c == null) c = _fillCurve;

        while (period > 0) {
            output.SetFill(true, _fillColor, c.Evaluate(count));

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        output.SetFill(false, _fillColor, 0.0f);
    }
    private IEnumerator  Fade        () {
        
        float period    = _fadeTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve c = _curve;
        if (c == null) c = _fadeCurve;

        while (period > 0) {
            output.SetFade( 
                _fadeInvers,
                Color.Lerp(_fadeStartColor, _fadeEndColor, count),
                c.Evaluate(count)
                );
            
            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator  Vignette    () {

        float period    = _vignetteTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve c = _curve;
        if (c == null) c = _vignetteCurve;

        while (period > 0) {
            output.SetViggnet(
                true,
                _vignetteColor,
                c.Evaluate(count),
                _vignetteLevel
                );
            
            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        output.SetViggnet(false, _vignetteColor, 0.0f, 0.0f);
    }
    private IEnumerator  CA          () {

        float period    = _chormaticAberrationTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve c = _curve;
        if (c == null) c = _chormaticAberrationCurve;

        while (period > 0) {

            output.SetChromaticAberrtion(
                true,
                c.Evaluate(count) * _chormaticAberrationLevel
            );

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        output.SetChromaticAberrtion( false, 0.0f);
    }
    private IEnumerator  FOV         () {

        float period    = _fovTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        float defFov    = camera.GetComponent<Camera>().fieldOfView;
        float diff      = _fovLevel - defFov;

        AnimationCurve c = _curve;
        if (c == null) c = _fovCurve;

        while (period > 0) {

            camera.GetComponent<Camera>().fieldOfView = defFov + (diff * c.Evaluate(count));

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator  TimeStop    () {
        
        Time.timeScale = 0.0f;

        yield return new WaitForSecondsRealtime(_waitTime);

        Time.timeScale = 1.0f;
    }
    private IEnumerator  SlowMotion  () {


        float period    = _slowMotionTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        
        AnimationCurve c = _curve;
        if (c == null) c = _slowMotionCurve;

        while (period > 0) {
            
            Time.timeScale = Mathf.Lerp(1.0f, 0.01f, c.Evaluate(count));

            count   += inc * Time.unscaledDeltaTime;
            period  -= Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = 1.0f;
    }
}