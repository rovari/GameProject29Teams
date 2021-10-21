using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collision : FacadeData {

    // Show  Property =============================================
    [SerializeField] private float  _damage;
    
    // Unity Method ===============================================
    private void OnTriggerEnter     (Collider other) {
        Debug.Log("Hit" + transform.parent.name + " " + name + " to "+ other.transform.parent.name + " "+ other.name);
        HitCalc(other.gameObject);
    }

    // User  Method ===============================================
    public  Type    GetFacadeType   () {
        return facade.GetType();
    }
    public  void    CalcHp          (float damage) {
        facade.GetFacade<Player>().GetSetHp -= damage;
    }
    private void    HitCalc         (GameObject obj) {
        
        if((typeof(Player) == obj.GetComponent<Collision>().GetFacadeType()))   obj.GetComponent<Collision>().CalcHp(_damage);
        if((typeof(Enemy ) == obj.GetComponent<Collision>().GetFacadeType()))   obj.GetComponent<Collision>().CalcHp(_damage);
    }
}