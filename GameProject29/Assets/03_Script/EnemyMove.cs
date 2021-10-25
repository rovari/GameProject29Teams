using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : FacadeData {

    // Hide  Property =============================================

    // Show  Property =============================================
    [SerializeField] private float          _deadEffectTime;
    [SerializeField] private AnimationCurve _deadEffectCurve;

    // Unity Method ===============================================
    private void Update() {
        Dead();
    }

    // User  Method ===============================================
    private void Dead() {
        if (facade.GetFacade<Enemy>().GetSetHp <= 0.0f) {

            StartCoroutine("DeadEffect");
            facade._effect.PlayEffect(Effect.EFFECT.EXPLOSION,  _deadEffectTime, _deadEffectCurve, 0.05f);
            facade._effect.PlayEffect(Effect.EFFECT.FILL,       _deadEffectTime, _deadEffectCurve, 0.0f, Color.yellow);
        }
    }

    private IEnumerator DeadEffect() {

        float period    = _deadEffectTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;

        //C³—\’è
        transform.root.Find("Collision").gameObject.SetActive(false);
        
        while (period > 0) {

            facade._surface.SetDissolve(1.0f - count);

            count += inc * Time.deltaTime;
            period -= Time.deltaTime;
            yield return null;
        }

        facade._surface.SetDissolve(1.0f);
 
        Destroy(gameObject);
    }
}

