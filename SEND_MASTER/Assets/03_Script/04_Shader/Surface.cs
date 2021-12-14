using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : ShaderController {

    // Method
    public       Surface(Material mat) {
        material = mat;
    }
    public  void SetDissolve    (float level) {
        material.SetFloat   ("_Ragne", Mathf.Clamp01(level));
    }
    public  void SetRimEnable   (bool active, Color color) {
        material.SetInt     ("_Rim", Convert.ToInt32(active));
        material.SetColor   ("_RimColor", color);
    }
}
