using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour {
    
    // Field
	
    // Property

    // Method

	// Signal

    // Unity
	private void Start() {
        Camera.main.depthTextureMode |= DepthTextureMode.Depth;
    }
}
