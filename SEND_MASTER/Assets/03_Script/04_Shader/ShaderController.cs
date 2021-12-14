using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController {

    // Field
    protected Material material;

    // Property

    // Method
    ~ShaderController() {
        Release();
    }
    
    private void Release() { material = null; }
}
