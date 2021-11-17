using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Surface : ShaderController {

    // User Method ===============================================
    public  Surface(Material mat) {
        _material = mat;
    }

    public  void SetDissolve (float level) {
        _material.SetFloat("_Range", Mathf.Clamp01(level));
    }
    public  void SetRimEnable(bool active, Color col) {
        _material.SetInt    ("_Rim", Convert.ToInt32(active));
        _material.SetColor  ("_RimColor", col);
    }

}
