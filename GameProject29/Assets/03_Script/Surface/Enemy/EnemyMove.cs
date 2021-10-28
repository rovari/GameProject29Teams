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
        if (facade.GetFacade<Enemy>().GetIsDestory()) {

            Enemy.GRADE grade = facade.GetFacade<Enemy>().GetGrade();

            StartCoroutine("DeadEffect");
            if (grade >= Enemy.GRADE.MIDDLERISK) facade._effect.PlayEffect(Effect.EFFECT.TIMESTOP,  0.01f);
            if (grade >= Enemy.GRADE.HEIGHTRISK) facade._effect.PlayEffect(Effect.EFFECT.EXPLOSION, _deadEffectTime, _deadEffectCurve, 1, 0.025f);
            if (grade >= Enemy.GRADE.BOSS)       facade._effect.PlayEffect(Effect.EFFECT.CA,        _deadEffectTime, _deadEffectCurve, 1, 0.5f);
            if (grade >= Enemy.GRADE.BOSS)       facade._effect.PlayEffect(Effect.EFFECT.FILL,      _deadEffectTime, _deadEffectCurve, 1, 0.0f, Color.yellow);
            if (grade >= Enemy.GRADE.BIGBOSS)    facade._effect.PlayEffect(Effect.EFFECT.SLOWMOTION,_deadEffectTime, _deadEffectCurve, 1);

        }
    }

    private IEnumerator DeadEffect() {
        
        float period    = _deadEffectTime;
        float inc       = 1.0f / (period + Mathf.Epsilon);
        float count     = 0.0f;
        
        transform.Find("Collision").gameObject.SetActive(false);

        tag = "Untagged";
        StateManager.GetSetTakeDown = true;

        while (period > 0) {

            facade._surface.SetDissolve(1.0f - count);

            count += inc * Time.deltaTime;
            period -= Time.deltaTime;
            yield return null;
        }

        facade._surface.SetDissolve(1.0f);

        if (facade.GetFacade<Enemy>().GetGrade() >= Enemy.GRADE.BOSS) StateManager.CallResult();

        Destroy(gameObject);
    }
}

