using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EFFECT {
    EXPLOSION,
    FILL,
    VIGNETTE,
    CA,
    FOV,
    TIMESTOP,
    SLOWMOTION
}

[Serializable]
public struct EffectData {

    public bool            isEnable;
    public int             hierarchy;
    public float           time;
    public float           level;
    public AnimationCurve  curve;
    public Color           color;
    public Color           subColor;
}

public class EffectSystem : MonoBehaviour {

    // Field
    private Output      output;
    private EffectData  explosion;
    private EffectData  fade;
    private EffectData  fill;
    private EffectData  vignette;
    private EffectData  chromaticAberration;
    private EffectData  fov;
    private EffectData  timeStop;
    private EffectData  timeScale;

    private Dictionary<string, IEnumerator> coroutine;

    // Property

    // Method
    public  void PlayEffect         (EFFECT effect, EffectData data) {
        
        switch (effect) {

            case EFFECT.EXPLOSION:
                PlayHierarchyCheck(ref explosion, data, Explosion());
                break;

            case EFFECT.FILL:
                PlayHierarchyCheck(ref fill, data, Fill());
                break;

            case EFFECT.VIGNETTE:
                PlayHierarchyCheck(ref vignette, data, Vignette());
                break;

            case EFFECT.CA:
                PlayHierarchyCheck(ref chromaticAberration, data, CA());
                break;

            case EFFECT.FOV:
                PlayHierarchyCheck(ref fov, data, FOV());
                break;

            case EFFECT.TIMESTOP:
                PlayHierarchyCheck(ref timeStop, data, TimeStop());
                break;

            case EFFECT.SLOWMOTION:
                PlayHierarchyCheck(ref timeScale, data, SlowMotion());
                break;

            default: break;
        }
    }
    
    private void PlayHierarchyCheck (ref EffectData runData, EffectData newData, IEnumerator newCoroutine) {
        
        if (runData.hierarchy <= newData.hierarchy) {

            string corName = newCoroutine.ToString();

            StopCoroutine(coroutine[corName]);
            runData             = newData; 
            coroutine[corName]  = newCoroutine;

            if (coroutine[corName] != null) StartCoroutine(coroutine[corName]);
        }
    }
    private void CreateDictionary   () {

        coroutine = new Dictionary<string, IEnumerator>();

        coroutine.Add(Explosion ().ToString(), null);
        coroutine.Add(Fill      ().ToString(), null);
        coroutine.Add(Vignette  ().ToString(), null);
        coroutine.Add(CA        ().ToString(), null);
        coroutine.Add(FOV       ().ToString(), null);
        coroutine.Add(TimeStop  ().ToString(), null);
        coroutine.Add(SlowMotion().ToString(), null);
    }

    private IEnumerator Explosion   () {

        float period    = explosion.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve curve = explosion.curve;
        if (curve == null) yield break;

        while(period > 0) {
            float nx = UnityEngine.Random.Range(-1.0f, 1.0f) * curve.Evaluate(count) * explosion.level;
            float ny = UnityEngine.Random.Range(-1.0f, 1.0f) * curve.Evaluate(count) * explosion.level;
            float nz = UnityEngine.Random.Range(-1.0f, 1.0f) * curve.Evaluate(count) * explosion.level;

            Quaternion noiseRot = Quaternion.Euler(nx, ny, nz);

            Camera.main.transform.rotation = Quaternion.Slerp(
                Camera.main.transform.rotation,
                Camera.main.transform.rotation * noiseRot,
                Time.time * 5.0f);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        explosion.hierarchy = 0;
    }
    private IEnumerator Fill        () {

        float period    = fill.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve curve = fill.curve;
        if (curve == null) yield break;

        while(period > 0) {

            output.SetFill(true, fill.color, curve.Evaluate(count));

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        fill.hierarchy = 0;
    }
    private IEnumerator Fade        () {

        float period    = fade.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve curve = fade.curve;
        if (curve == null) yield break;

        while(period > 0) {

            output.SetFade(fade.isEnable, fade.color, curve.Evaluate(count));
            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        fade.hierarchy = 0;
    }
    private IEnumerator Vignette    () {

        float period    = vignette.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve curve = vignette.curve;
        if (curve == null) yield break;

        while (period > 0) {

            output.SetVignette(vignette.isEnable, vignette.color, vignette.level);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        vignette.hierarchy = 0;
    }
    private IEnumerator CA          () {
        
        float period    = chromaticAberration.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve curve = chromaticAberration.curve;
        if (curve == null) yield break;

        while(period > 0) {

            output.SetChromaticAberrtion(chromaticAberration.isEnable, chromaticAberration.level);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        chromaticAberration.hierarchy = 0;
    }
    private IEnumerator FOV         () {

        float period    = fov.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        float defFov    = Camera.main.fieldOfView;
        float diff      = fov.level - defFov;

        AnimationCurve curve = fov.curve;
        if (curve == null) yield break;

        while(period > 0) {

            Camera.main.fieldOfView = defFov + (diff * curve.Evaluate(count));

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        Camera.main.fieldOfView = defFov;
        fov.hierarchy = 0;
    }
    private IEnumerator TimeStop    () {

        float defScale = Time.timeScale;

        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(timeStop.time);
        Time.timeScale = defScale;
        timeStop.hierarchy = 0;
    }
    private IEnumerator SlowMotion  () {
        
        float defScale  = Time.timeScale;
        float period    = fov.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve curve = timeScale.curve;
        if (curve == null) yield break;

        while(period > 0) {

            Time.timeScale = Mathf.Lerp(defScale, 0.01f, curve.Evaluate(count));

            count   += inc * Time.unscaledDeltaTime;
            period  -= Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = defScale;
        timeScale.hierarchy = 0;
    }

	// Signal
    private void FadeSignal         (EffectData data) {
        fade = data;
        StartCoroutine("Fade");
    }

    // Unity
	private void Start() {

        CreateDictionary();
	}
}
