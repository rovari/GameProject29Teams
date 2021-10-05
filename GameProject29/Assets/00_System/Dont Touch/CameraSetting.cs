using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour {

    // Unity Method ===============================================
    private void Start  () {

        CamaraSetting();
    }
    
    // User  Method ===============================================
    private void CamaraSetting() {
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        Application.targetFrameRate = 61;
    }
}