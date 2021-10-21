using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collision : FacadeData {
    
    // Show  Property =============================================
    [SerializeField] private float  _damage;
    
    // Unity Method ===============================================
    private void OnTriggerEnter     (Collider other) {
        Debug.Log("Hit " + transform.parent.name + " " + name + " to "+ other.transform.parent.name + " "+ other.name);
        HitCalc(other.gameObject);
        
        if(facade.GetType() != typeof(Bullet)) SetDamageRim(0.5f, 0.05f);
    }

    // User  Method ===============================================
    public  Type        GetFacadeType   () {
        return facade.GetType();
    }
    private void        CalcPlayerHp    (float damage) {
        facade.GetFacade<Player>().GetSetHp -= damage;
    }
    private void        CalcEnemyHp     (float damage) {
        facade.GetFacade<Enemy>().GetSetHp -= damage;
    }
    private void        HitCalc         (GameObject obj) {
        
        if((typeof(Player) == obj.GetComponent<Collision>().GetFacadeType()))   obj.GetComponent<Collision>().CalcPlayerHp  (_damage);
        if((typeof(Enemy ) == obj.GetComponent<Collision>().GetFacadeType()))   obj.GetComponent<Collision>().CalcEnemyHp   (_damage);
    }
    private void        SetDamageRim    (float time, float interval) {

        IEnumerator dr = DamageRim(time, interval);
        StartCoroutine(dr);
    }
    public IEnumerator  DamageRim       (float time, float interval) {

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