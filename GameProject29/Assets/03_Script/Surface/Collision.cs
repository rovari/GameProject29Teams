using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collision : FacadeData {
    
    // Show  Field  ===============================================
    [SerializeField] private float          _damage;
    [SerializeField] private AnimationCurve _damageCurve;

    // Unity Method ===============================================
    private void OnTriggerEnter     (Collider other) {
        Debug.Log("<< HIT >> " + transform.parent.name + " to "+ other.transform.parent.name);
        HitTypeCheck(other.gameObject);
        
        if (    facade.GetType()                                != typeof(Bullet) 
            &&  other.GetComponent<Collision>().GetFacadeType() != typeof(Enemy)
            ) SetDamageRim(0.5f, 0.05f);
    }

    // User  Method ===============================================
    public  Type        GetFacadeType       () {
        return facade.GetType();
    }
    private void        CalcPlayerHp        (float damage, float posX) {
        facade.GetFacade<Player>().GetSetHp -= damage;
        facade.GetFacade<Player>().GetSetHitPos = posX;

        facade._effect.PlayEffect(Effect.EFFECT.CA,        0.5f, _damageCurve, 0, 0.1f);
        facade._effect.PlayEffect(Effect.EFFECT.EXPLOSION, 0.5f, _damageCurve, 0, 0.25f);
    }
    private void        CalcEnemyHp         (float damage) {

        facade.GetFacade<Enemy>().GetSetHp -= damage;
        facade._effect.PlayEffect(Effect.EFFECT.TIMESTOP,  0.05f);
        facade._effect.PlayEffect(Effect.EFFECT.EXPLOSION, 0.5f, _damageCurve, 0, 0.25f);
    }
    private void        CalcEnvironmentHp   (float damage) {
        
        facade.GetFacade<Environment>().GetSetHp -= damage;
    }
    private void        HitTypeCheck        (GameObject obj) {

        if ((typeof(Player)      == obj.GetComponent<Collision>().GetFacadeType())) {
            obj.GetComponent<Collision>().CalcPlayerHp(_damage, obj.transform.position.x);
        }

        if ((typeof(Enemy)       == obj.GetComponent<Collision>().GetFacadeType())) {
            if(facade.GetType() != typeof(Enemy)) obj.GetComponent<Collision>().CalcEnemyHp(_damage);
        }

        if ((typeof(Environment) == obj.GetComponent<Collision>().GetFacadeType())) {
            obj.GetComponent<Collision>().CalcEnvironmentHp(_damage);
        }
    }
    private void        SetDamageRim        (float time, float interval) {

        IEnumerator dr = DamageRim(time, interval);
        StartCoroutine(dr);
    }
    private IEnumerator DamageRim           (float time, float interval) {

        float   count   = time / interval;
        bool    sw      = true;

        while (count > 0) {
            facade._surface.SetRimEnable(sw);
            count   -=  1.0f;
            sw      =   !sw;

            yield return new WaitForSeconds(interval);
        }

        facade._surface.SetRimEnable(false);
    }
}