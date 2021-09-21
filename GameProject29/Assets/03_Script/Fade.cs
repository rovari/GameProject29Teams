using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    private Material    material;
    private IEnumerator coroutine;
    public bool tests = false;

    private void Start()    { material = this.GetComponent<Image>().material; }
    
    private void Update() {

        if (tests) StartFade(2.0f, true);
        tests = false;
    }

    public void SetColor        (Color col) {
        material.SetColor("_Color", col);
    }
    public void SetSubColor     (Color col) {
        material.SetColor("_SubCol", col);
    }
    public void EnableColorLink (int enable) {
        material.SetInt("_Link", enable);
    }
    public void EnableMaskRevers(int enable) {
        material.SetInt("_Revers", enable);
    }
    public void StartFade   (float sec, bool appear) {
        coroutine = FadeON(sec, appear);
        StartCoroutine  (coroutine);
    }

    IEnumerator FadeON (float sec, bool appear) {

        float count = 1.0f;
       
        while (count > 0 && sec > 0.0f) {
            material.SetFloat("_Range", (appear) ? count : 1.0f - count);
            count -= 1.0f / sec * Time.deltaTime;
                
            yield return null;
        }

        material.SetFloat("_Range", (appear) ? 0.0f : 1.0f);
    }
}