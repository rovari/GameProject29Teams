using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : ShaderController {

    // Method
    public Output(Material mat) {
        material = mat;
    }

    public  void SetLaplacian           (Color color) {

        material.SetColor  ("_Color"   , color);
    }
    public  void SetFade                (bool reverse, Color color, float level) {
        
        material.SetInt    ("_Reverse" , Convert.ToInt32(reverse));
        material.SetColor  ("_FdCol"   , color);
        material.SetFloat  ("_FdRange" , Mathf.Clamp01(level));
    }
    
    public  void SetChromaticAberrtion  (bool active) {
        material.SetInt    ("_CA"      , Convert.ToInt32(active));
    }
    public  void SetChromaticAberrtion  (bool active, float level) {

        material.SetInt    ("_CA"      , Convert.ToInt32(active));
        material.SetFloat  ("_CALv"    , Mathf.Clamp01(level));
    }

    public  void SetFill                (bool active) {
   
        material.SetInt("_Fill", Convert.ToInt32(active));
    }
    public  void SetFill                (bool active, Color color, float level) {

        material.SetInt    ("_Fill"    , Convert.ToInt32(active));
        material.SetColor  ("_FiCol"   , color);
        material.SetFloat  ("_FiLv"    , Mathf.Clamp01(level));
    }

    public  void SetVignette            (bool active) {

        material.SetInt("_Vigg", Convert.ToInt32(active));
    }
    public  void SetVignette            (bool active, Color color, float level)  {

        material.SetInt     ("_Vig", Convert.ToInt32(active));
        material.SetColor   ("_ViCol", color);
        material.SetFloat   ("_ViLv", Mathf.Clamp01(level));
    }
}
