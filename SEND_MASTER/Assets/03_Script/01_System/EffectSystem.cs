using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private float      cameraShakeSpeed;
    [SerializeField] private float      cameraShakeLevel;
    [SerializeField] private EffectData fadeIn;
    [SerializeField] private EffectData fadeOut;

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
    public  void PlayHitStop        (float time) {

        timeStop.time = time;
        IEnumerator cor = TimeStop();
    }

    // Graphic
    
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

        coroutine.Add(Explosion ().ToString(), Explosion());
        coroutine.Add(Fill      ().ToString(), Fill());
        coroutine.Add(Vignette  ().ToString(), Vignette());
        coroutine.Add(CA        ().ToString(), CA());
        coroutine.Add(FOV       ().ToString(), FOV());
        coroutine.Add(TimeStop  ().ToString(), TimeStop());
        coroutine.Add(SlowMotion().ToString(), SlowMotion());
    }

    private void        CameraShake () {
        float t     = Time.time * cameraShakeSpeed;
        float nx    = ((Mathf.PerlinNoise(t         , t + 0.5f) + 0.025f) * 2.0f - 1.0f) * cameraShakeLevel;
        float ny    = ((Mathf.PerlinNoise(t + 1.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * cameraShakeLevel;
        float nz    = ((Mathf.PerlinNoise(t + 2.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * cameraShakeLevel;

        Quaternion noiseRot         = Quaternion.Euler( nx, ny, nz );
        Camera.main.transform.rotation   = Quaternion.Slerp(Camera.main.transform.rotation, noiseRot, Time.time * 5.0f);
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

        output.SetFill(false, fill.color, 0.0f);

        fill.hierarchy = 0;
    }
    private IEnumerator Fade        () {

        float period    = fade.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve curve = fade.curve;
        if (curve == null) yield break;

        while(period > 0) {

            output.SetFade(
                fade.isEnable,
                Color.Lerp(fade.subColor, fade.color, curve.Evaluate(count)),
                curve.Evaluate(count)
            );

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

            output.SetVignette(vignette.isEnable, vignette.color, curve.Evaluate(count) * vignette.level);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        output.SetVignette(vignette.isEnable, vignette.color, 0.0f);

        vignette.hierarchy = 0;
    }
    private IEnumerator CA          () {
        
        float period    = chromaticAberration.time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        AnimationCurve curve = chromaticAberration.curve;
        if (curve == null) yield break;

        while(period > 0) {

            output.SetChromaticAberrtion(chromaticAberration.isEnable, curve.Evaluate(count) * chromaticAberration.level);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        output.SetChromaticAberrtion(false, 0.0f);

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

    // Sound
    public void SoundLowPassEffect  (bool bgmOnly, bool lowpassIn, float time) {
        IEnumerator cor = LowPass(bgmOnly, lowpassIn, time);
        StartCoroutine(cor);
    }
    public void SoundFadeEffect     (bool bgmOnly, float time, float volume) {
        IEnumerator cor = SoundFade(bgmOnly, time, volume);
        StartCoroutine(cor);
    }
    public void SwapBgmEffect       (float time, string nextBgmName) {
        IEnumerator cor = SwapSound(time, nextBgmName);
        StartCoroutine(cor);
    }

    private IEnumerator LowPass     (bool bgmOnly, bool lowpassIn, float time) {

        const float passMax = 22000.0f;
        const float passMin = 1000.0f;

        float period    = time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        string target   = (!bgmOnly) ? "MS_LP": "BG_LP";

        
        while(period > 0) {

            if (!lowpassIn) AudioManager.GetMixer().SetFloat(target, Mathf.Lerp(passMin, passMax, count));
            else AudioManager.GetMixer().SetFloat(target, Mathf.Lerp(passMax, passMin, count));

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        if (lowpassIn) AudioManager.GetMixer().SetFloat(target, passMin);
        else AudioManager.GetMixer().SetFloat(target, passMax);
    }
    private IEnumerator SoundFade   (bool bgmOnly, float time, float volume) {

        float period    = time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        string  target      = (!bgmOnly) ? "MS_VL" : "BG_VL";

        float current;
        AudioManager.GetMixer().GetFloat(target, out current);
        
        while (period > 0) {
            
            AudioManager.GetMixer().SetFloat(target, Mathf.Lerp(current, volume, Mathf.Sin((Mathf.PI * 0.5f) * count)));

            count += inc * Time.deltaTime;
            period -= Time.deltaTime;
            yield return null;
        }

        AudioManager.GetMixer().SetFloat(target, volume);
    }
    private IEnumerator SwapSound   (float time, string nextBgmName) {

        bool    isChange    = false;
        float   period      = time;
        float   inc         = 1.0f / (period + Mathf.Epsilon);
        float   count       = 0.0f;
        string  target      = "BG_VL";

        float current;
        AudioManager.GetMixer().GetFloat(target, out current);

        while (period > 0) {

            if (period < 0.5f && !isChange) {
                isChange = true;

                period = 0.5f;
                AudioManager.Volume (SOUNDTYPE.BGM, 0.0f);
                AudioManager.Stop   (SOUNDTYPE.BGM);
                AudioManager.Play   (SOUNDTYPE.BGM, nextBgmName);
            }
            
            if (period > 0.5f) AudioManager.GetMixer().SetFloat(target, Mathf.Lerp(current, -80.0f, Mathf.Sin((Mathf.PI * 0.5f) * count * 2.0f)));
            if (period < 0.5f) AudioManager.GetMixer().SetFloat(target, Mathf.Lerp(-80.0f, current, Mathf.Sin((Mathf.PI * 0.5f) * count * 2.0f - 0.5f)));

            count += inc * Time.deltaTime;
            period -= Time.deltaTime;
            yield return null;
        }

        AudioManager.GetMixer().SetFloat(target, current);
    }
    
    // Signal
    public void FadeSignal(bool outFade) {

        fade = (!outFade) ? fadeIn : fadeOut;
        StartCoroutine("Fade");
    }

    // Unity
	private void Start  () {

        output = new Output(GameObject.FindGameObjectWithTag("Frame").GetComponent<Image>().material);
        CreateDictionary();
	}

    private void Update () {

        CameraShake();
    }
}
