using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Output : ShaderController{

    // User  Method ===============================================
    public  Output(Material mat) {
        _material = mat;
    }

    public  void SetLaplacian           (Color color) {

        _material.SetColor  ("_Color"   , color);
    }
    public  void SetFade                (bool reverse, Color color, float level) {
        
        _material.SetInt    ("_Reverse" , Convert.ToInt32(reverse));
        _material.SetColor  ("_FdCol"   , color);
        _material.SetFloat  ("_FdRange" , Mathf.Clamp01(level));
    }
    
    public  void SetChromaticAberrtion  (bool active) {
        _material.SetInt    ("_CA"      , Convert.ToInt32(active));
    }
    public  void SetChromaticAberrtion  (bool active, float level) {

        _material.SetInt    ("_CA"      , Convert.ToInt32(active));
        _material.SetFloat  ("_CALv"    , Mathf.Clamp01(level));
    }

    public  void SetFill                (bool active) {
   
        _material.SetInt("_Fill", Convert.ToInt32(active));
    }
    public  void SetFill                (bool active, Color color, float level) {

        _material.SetInt    ("_Fill"    , Convert.ToInt32(active));
        _material.SetColor  ("_FiCol"   , color);
        _material.SetFloat  ("_FiLv"    , Mathf.Clamp01(level));
    }
    
    public  void SetViggnet             (bool active) {

        _material.SetInt("_Vigg", Convert.ToInt32(active));
    }
    public  void SetViggnet             (bool active, Color color, float level, float range) {
        
        _material.SetInt    ("_Vig"     , Convert.ToInt32(active));
        _material.SetColor  ("_ViCol"   , color);
        _material.SetFloat  ("_ViLv"    , Mathf.Clamp01(level));
        _material.SetFloat  ("_ViRg"    , Mathf.Clamp01(range));
    }
}

