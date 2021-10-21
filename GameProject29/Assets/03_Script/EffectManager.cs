using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    private static Effect ef;

    private void   Start() {
        ef = GetComponent<Effect>(); 
    }
    
    public  static void  Play       (Effect.EFFECT effect, AnimationCurve curve = null, float time = 0.0f, float level = 0.0f, Color color = default) {
        
        if (level < 0.0f)  level = 0.0f;
        if (time  < 0.0f)  time  = 0.0f;

        ef.PlayEffect(effect, curve, level, time, color);
    }
    public  static void  Play       (Effect.EFFECT effect, AnimationCurve curve = null, float time = 0.0f, Color color = default) {
        
        if (time  < 0.0f)  time  = 0.0f;

        ef.PlayEffect(effect, curve, 0.0f, time, color);
    }
    public  static void  Play       (Effect.EFFECT effect, AnimationCurve curve = null, float time = 0.0f) {
        
        if (time  < 0.0f)  time  = 0.0f;

        ef.PlayEffect(effect, curve, 0.0f, time, default);
    }
    public  static void  Play       (Effect.EFFECT effect, float time = 0.0f) {
        
        if (time  < 0.0f)  time  = 0.0f;

        ef.PlayEffect(effect, null, 0.0f, time, default);
    }
}
