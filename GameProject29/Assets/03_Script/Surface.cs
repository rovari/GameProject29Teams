using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour {

    private Material    material;
    private IEnumerator coroutine;
    
    private void Start() { material = this.GetComponent<Renderer>().material; }

    private void OnDestroy() { if (material != null) Destroy(material); }

    public void SetColor            (Color col) {
        material.SetColor("_Color", col);
    }
    public void SetSubColor         (Color col) {
        material.SetColor("_SubColor", col);
    }
    public void SetNormalLevel      (float level) {
        material.SetFloat("_Height", level);
    }
    public void SetGradationUv      (Vector2 uv) {
        material.SetFloat("_GV_X", uv.x);
        material.SetFloat("_GV_Y", uv.y);
    }
    public void SetGradationHeight  (float top, float bottom) {
        material.SetFloat("_GH_TOP", top);
        material.SetFloat("_GH_BOTTOM", bottom);
    }
    public void SetUvScroll         (Vector2 uv) {
        material.SetFloat("_Scr_X", uv.x);
        material.SetFloat("_Scr_Y", uv.y);
    }
    public void EnableDissolveRevers(int enable) {
        material.SetInt("_Revers", enable);
    }
    public void StartDissolve       (float sec , bool appear) {
        coroutine = Dissolve(sec, appear);
        StartCoroutine(coroutine);
    }

    IEnumerator Dissolve(float sec, bool appear) {
        
        sec = sec * Time.deltaTime;

        for (float l = 0.0f; l <= 1.0f; ++sec) {
            material.SetFloat("_Range", (appear) ? l : 1.0f - l);
            yield return null;
        }
    }
}
