using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioEffect : MonoBehaviour
{
    private const float LOWPASS_CUTOFF = (1.0f / 22000.0f);
    private const float DEF_LOWPASS_LEVEL = (1.0f / 22000.0f * 5000.0f);

    [SerializeField] private AudioMixer mix;

    public  void FadeEffect         (float time, float endVol, bool fadeIn) {
        IEnumerator cor = (fadeIn) ? FadeIn(time, endVol) :FadeOut(time, endVol);
        StartCoroutine(cor);
    }
    public  void LowPassEffect      (float time, float level = 1.0f) {
        IEnumerator cor = LowPass(time, level);
        StartCoroutine(cor);
    }
    public  void CrossFadeEffect    () {
        IEnumerator cor = CrossFade();
        StartCoroutine(cor);
    }

    private IEnumerator FadeIn      (float time, float endVol) {

        if (endVol > 1.0f || endVol < 0.0f|| time == 0.0f ) yield break;

        float inc       = 1.0f / time;
        float startVol  = 0.0f;
        float setLevel  = 0.0f;
        float count     = 0.0f;

        mix.GetFloat("MS_VL", out startVol);

        if (startVol > endVol) yield break;
        
        while (count > 0.0f) {
            
            count    -= inc * Time.deltaTime;
            setLevel =  Mathf.Lerp(startVol, endVol, Mathf.Cos((Mathf.PI * 0.5f) * count));

            mix.SetFloat("MS_VL", setLevel);

            yield return null;
        }

        mix.SetFloat("MS_VL", endVol);
    }
    private IEnumerator FadeOut     (float time, float endVol) {

        if (endVol > 1.0f || endVol < 0.0f|| time == 0.0f ) yield break;

        float inc       = 1.0f / time;
        float startVol  = 0.0f;
        float setLevel  = 0.0f;
        float count     = 0.0f;

        mix.GetFloat("MS_VL", out startVol);

        if (startVol < endVol) yield break;
        
        while (count > 0.0f) {
            
            count    -= inc * Time.deltaTime;
            setLevel =  Mathf.Lerp(startVol, endVol, Mathf.Sin((Mathf.PI * 0.5f) * count));

            mix.SetFloat("MS_VL", setLevel);

            yield return null;
        }

        mix.SetFloat("MS_VL", endVol);
    }
    private IEnumerator LowPass     (float time, float level)  {

        if (level > 1.0f || level < 0.0f|| time == 0.0f ) yield break;

        float inc           = 1.0f / time;
        float startLevel    = 0.0f;
        float setLevel      = level;
        float count         = 0.0f;

        mix.GetFloat("MS_LP", out startLevel);
        
        while (count > 0.0f) {
            
            count    -= inc * Time.deltaTime;
            setLevel =  Mathf.Lerp(startLevel, level, count);

            mix.SetFloat("MS_LP", setLevel * LOWPASS_CUTOFF);

            yield return null;
        }

        mix.SetFloat("MS_LP", level * LOWPASS_CUTOFF);
    }
    private IEnumerator HighPass    (float time, float level)  {

        if (level > 1.0f || level < 0.0f|| time == 0.0f ) yield break;

        float inc           = 1.0f / time;
        float startLevel    = 0.0f;
        float setLevel      = level;
        float count         = 0.0f;

        mix.GetFloat("MS_HP", out startLevel);
        
        while (count > 0.0f) {
            
            count    -= inc * Time.deltaTime;
            setLevel =  Mathf.Lerp(startLevel, level, count);

            mix.SetFloat("MS_HP", setLevel * LOWPASS_CUTOFF);

            yield return null;
        }

        mix.SetFloat("MS_HP", level * LOWPASS_CUTOFF);
    }
    private IEnumerator Distortion  (float time, float level) {
        yield return null;
    }
    private IEnumerator CrossFade   () {
        yield return null;
    }
}
