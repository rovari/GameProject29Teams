using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleErace : MonoBehaviour {

    // Field
	[SerializeField] private float time;

    private Surface surface;
    private float   count;
    // Property

    // Method
    private IEnumerator Dissolve() {

        float period    = time;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        
        while (period > 0) {
            
            surface.SetDissolve(count);

            count   += inc * Time.deltaTime;
            period  -= Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
        surface.SetDissolve(0.0f);
    }
    public void StartDissolve() {
        StartCoroutine("Dissolve");
    }

	// Signal
    
    // Unity
	private void Start() {
        surface = new Surface(GetComponent<Image>().material);
	}
}
