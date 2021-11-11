using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Effect : MonoBehaviour {
    
    // Hide  Field ================================================
    private Output          output;
    private AnimationCurve  _curve;
    private int            _explosionHierarchy           = -1;
    private int            _fillHierarchy                = -1;
    private int            _vignetteHierarchy            = -1; 
    private int            _chormaticAberrationHierarchy = -1; 

    private Dictionary<string, IEnumerator> coroutine;
    
    // Show  Field ================================================

    public enum EFFECT {
        EXPLOSION,
        FILL,
        VIGNETTE,
        CA,
        FOV,
        TIMESTOP,
        SLOWMOTION,
    }

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

        CreateDictionaly();
    }
    private void Update     () {
        if (_shake)     CameraShake();
    }


    // User  Method ===============================================
    public void         PlayEffect (
        EFFECT          effect,
        float           time        = 0.0f,
        AnimationCurve  curve       = null,
        int             hierarchy   = 0,
        float           level       = 0.0f,
        Color           color       = default
    ) {
        bool    skip    = false;
        string  name    = "";

        switch (effect) {

            case EFFECT.EXPLOSION:

                if (_explosionHierarchy <= hierarchy) {

                    name = "Explosion";

                    if (coroutine[name] != null) {
                        StopCoroutine(coroutine[name]);
                        coroutine[name] = null;
                    }

                    _explosionHierarchy = hierarchy;
                    _explosionTime      = time ;
                    _explosionLevel     = level;
                    _curve              = curve;

                    coroutine[name] = Explosion();
                }
                else skip = true;

                break;

            case EFFECT.FILL:
                if (_fillHierarchy <= hierarchy) {

                    name = "Fill";

                    if (coroutine[name] != null) {
                        StopCoroutine(coroutine[name]);
                        coroutine[name] = null;
                    }

                    _fillHierarchy      = hierarchy;
                    _fillTime           = time;
                    _curve              = curve;

                    coroutine[name] = Fill();
                }
                else skip = true;

                break;
                
            case EFFECT.VIGNETTE:
                if(_vignetteHierarchy <= hierarchy) {

                    name = "Vignette";

                    if (coroutine[name] != null) {
                        StopCoroutine(coroutine[name]);
                        coroutine[name] = null;
                    }

                    _vignetteHierarchy  = hierarchy;
                    _vignetteTime       = time;
                    _vignetteLevel      = level;
                    _curve              = curve;

                    coroutine[name] = Vignette();
                }
                else skip = true;

                break;

            case EFFECT.CA:
                if(_chormaticAberrationHierarchy <= hierarchy) {

                    name = "CA";

                    if (coroutine[name] != null) {
                        StopCoroutine(coroutine[name]);
                        coroutine[name] = null;
                    }

                    _chormaticAberrationHierarchy   = hierarchy;
                    _chormaticAberrationTime        = time;
                    _chormaticAberrationLevel       = level;
                    _curve                          = curve;
                    
                    coroutine[name] = CA();
                }
                else skip = true;

                break;

            case EFFECT.FOV:

                name = "FOV";

                _fovTime            = time;
                _fovLevel           = level; 
                _curve              = curve;

                coroutine[name] = FOV();
                break;

            case EFFECT.TIMESTOP:

                name = "TimeStop";

                _waitTime           = time;
                
                coroutine[name] = TimeStop();
                break;

            case EFFECT.SLOWMOTION:

                name = "SlowMotion";

                _slowMotionTime     = time;
                _curve              = curve;

                coroutine[name] = SlowMotion();
                break;
        }

        if (!skip && coroutine[name] != null) StartCoroutine(coroutine[name]);
    }
    
    [ContextMenu("DebugEffect")]
    public  void         DebugEffect        () {
        DebugEffectPlayer();
    }
    public  void         DebugEffectPlayer  (AnimationCurve curve = null){

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

    private void         CreateDictionaly   () {

        coroutine = new Dictionary<string, IEnumerator>();

        coroutine.Add("Explosion"   , null);
        coroutine.Add("Fill"        , null);
        coroutine.Add("Vignette"    , null);
        coroutine.Add("CA"          , null);
        coroutine.Add("FOV"         , null);
        coroutine.Add("TimeStop"    , null);
        coroutine.Add("SlowMotion"  , null);
    }
    private void         CameraShake        () {
        
        float t     = Time.time * _shakeSpeed;
        float nx    = ((Mathf.PerlinNoise(t         , t + 0.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;
        float ny    = ((Mathf.PerlinNoise(t + 1.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;
        float nz    = ((Mathf.PerlinNoise(t + 2.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * _shakeLevel;

        Quaternion noiseRot         = Quaternion.Euler( nx, ny, nz );
        Camera.main.transform.rotation   = Quaternion.Slerp(Camera.main.transform.rotation, noiseRot, Time.time * 5.0f);
    }  
    private IEnumerator  Explosion          () {
        
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
            Camera.main.transform.rotation  = Quaternion.Slerp(Camera.main.transform.rotation, Camera.main.transform.rotation * noiseRot, Time.time * 5.0f);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;;
            yield return null;
        }

        _explosionHierarchy = -1;
    }
    private IEnumerator  Fill               () {
        
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
        _fillHierarchy = -1;
    }
    private IEnumerator  Fade               () {
        
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
    private IEnumerator  Vignette           () {

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
        _vignetteHierarchy = -1;
    }
    private IEnumerator  CA                 () {

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
        _chormaticAberrationHierarchy = -1;
    }
    private IEnumerator  FOV                () {

        float period    = _fovTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        float defFov    = Camera.main.GetComponent<Camera>().fieldOfView;
        float diff      = _fovLevel - defFov;

        AnimationCurve c = _curve;
        if (c == null) c = _fovCurve;

        while (period > 0) {

            Camera.main.GetComponent<Camera>().fieldOfView = defFov + (diff * c.Evaluate(count));

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator  TimeStop           () {
        
        Time.timeScale = 0.0f;

        yield return new WaitForSecondsRealtime(_waitTime);

        Time.timeScale = 1.0f;
    }
    private IEnumerator  SlowMotion         () {


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