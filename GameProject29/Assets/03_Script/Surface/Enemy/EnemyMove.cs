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
        if (facade.GetFacade<Enemy>().GetSetIsDestory) { StartCoroutine("DeadEffect"); }
    }

    private IEnumerator DeadEffect() {

        facade.GetFacade<Enemy>().GetSetIsDestory = false;

        float   period  = _deadEffectTime;
        float   inc     = 1.0f / (period + Mathf.Epsilon);
        float   count   = 0.0f;
        Vector3 drop    = new Vector3((Random.value * 2.0f - 1.0f) * 0.05f, -0.5f , (Random.value * 2.0f -1.0f) * 0.05f);

        Enemy.GRADE grade = facade.GetFacade<Enemy>().GetGrade();

        if (grade >= Enemy.GRADE.MIDDLERISK) facade._effect.PlayEffect(Effect.EFFECT.TIMESTOP,  0.01f);
        if (grade >= Enemy.GRADE.HEIGHTRISK) facade._effect.PlayEffect(Effect.EFFECT.EXPLOSION, _deadEffectTime, _deadEffectCurve, 1, 0.5f);
        if (grade >= Enemy.GRADE.BOSS)       facade._effect.PlayEffect(Effect.EFFECT.CA,        _deadEffectTime, _deadEffectCurve, 1, 0.5f);
        if (grade >= Enemy.GRADE.BOSS)       facade._effect.PlayEffect(Effect.EFFECT.FILL,      _deadEffectTime, _deadEffectCurve, 1, 0.0f, Color.yellow);
        if (grade >= Enemy.GRADE.BIGBOSS)    facade._effect.PlayEffect(Effect.EFFECT.SLOWMOTION,_deadEffectTime, _deadEffectCurve, 1);

        transform.Find("Collision").gameObject.SetActive(false);

        tag = "Untagged";
        StateManager.GetSetTakeDown = true;

        while (period > 0) {

            facade._surface.SetDissolve(1.0f - count);
            transform.position += drop * Time.deltaTime;

            count += inc * Time.deltaTime;
            period -= Time.deltaTime;
            yield return null;
        }

        facade._surface.SetDissolve(1.0f);

        if (facade.GetFacade<Enemy>().GetGrade() >= Enemy.GRADE.BOSS) StateManager.CallResult();

        Destroy(gameObject);
    }
}

