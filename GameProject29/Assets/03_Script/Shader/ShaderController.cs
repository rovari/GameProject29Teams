using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController {

    // Hide  Field ================================================
    protected Material _material;

    // User  Method ===============================================
    ~ShaderController() {
        Release();
    }
    private void Release() { _material = null;}
}
