using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCameraSetting : MonoBehaviour
{
    void Start() {
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        Application.targetFrameRate = 60;
    }
}