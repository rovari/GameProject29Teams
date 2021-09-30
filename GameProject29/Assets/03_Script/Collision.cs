using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public bool     ShowCollisionArea;
    public float    damage = 0.0f;

    // Unity Function ===============================================
    
    // User  Function ===============================================

    public float GetDamage() {
           return damage;
    }
}
