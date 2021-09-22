using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCameraSetting : MonoBehaviour {

    // Unity Function ===============================================

    private void Start  () {

        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        Application.targetFrameRate = 61;
    }

    // User  Function ===============================================
}