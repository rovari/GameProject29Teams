using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour {

    public float    ShakeSpeed      = 1.0f;
    public float    ShakeLevel      = 1.0f;
    public float    ExplosionLevel  = 1.0f;
    public float    ExplosionTime   = 1.0f;
    
    public bool     test = false;

    private void Update() {

        if (test) { StartCoroutine("ExplosionEffect");  }


        CameraShake();
    }

    private void CameraShake() {
        
        float t     = Time.time * ShakeSpeed;
        float nx    = ((Mathf.PerlinNoise(t         , t + 0.5f) + 0.025f) * 2.0f - 1.0f) * ShakeLevel;
        float ny    = ((Mathf.PerlinNoise(t + 1.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * ShakeLevel;
        float nz    = ((Mathf.PerlinNoise(t + 2.0f  , t + 1.5f) + 0.025f) * 2.0f - 1.0f) * ShakeLevel;

        Quaternion noiseRot = Quaternion.Euler( nx, ny, nz );
        transform.rotation  = Quaternion.Slerp(transform.rotation, noiseRot, Time.deltaTime * 5.0f);
    }

    private IEnumerator ExplosionEffect() {

        test = false;

        float explosion = ExplosionLevel;
        float period    = 1.0f;

        float timeInc   = 1.0f          / ExplosionTime;
        
        while(period > 0) {
            
            float nx    = (Random.Range(-1.0f, 1.0f)) * Mathf.Lerp(0.0f, explosion, period);
            float ny    = (Random.Range(-1.0f, 1.0f)) * Mathf.Lerp(0.0f, explosion, period);
            float nz    = (Random.Range(-1.0f, 1.0f)) * Mathf.Lerp(0.0f, explosion, period);

            Quaternion noiseRot = Quaternion.Euler( nx, ny, nz );
            transform.rotation  = Quaternion.Lerp(transform.rotation, noiseRot, Time.deltaTime * 5.0f);

            period      -= timeInc  * Time.deltaTime;

            yield return null;
        }

        
    }

    private IEnumerator FovEffect() {

        test = false;

        Camera  cam         = GetComponent<Camera>();
        float   def         = cam.fieldOfView;
        float   period      = 1.0f;
        float   timeInc     = 1.0f / ExplosionTime;

        while (period > 0) {
            cam.fieldOfView = Mathf.Lerp(150.0f, def, period * period);

            period -= timeInc * Time.deltaTime;

            yield return null;
        }
    }
}