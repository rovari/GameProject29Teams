using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMeasure : MonoBehaviour { 
    
    private bool    _isWork         = false;
    private float   _planeScale     = 1.0f;
    private float   _objectSize     = 0.0f;
    private float   _seekCount      = 0.0f;
    private float   _startDistance  = 0.0f;

    private Vector3 _seekVector;
    
    void Start() {
        transform.localScale = Vector3.one * _planeScale;
        transform.position   = _seekVector * _startDistance;
    }
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Environment")) _seekCount += Time.deltaTime;
    }

    private void OnTriggerExit(Collider other) {
        _isWork     = true;
        _objectSize = _seekCount;
        _seekCount  = 0.0f;
    }

    private IEnumerator Seek() {

        while (!_isWork) {

            transform.position += _seekVector * Time.deltaTime;
            yield return null;
        }
    }
}
