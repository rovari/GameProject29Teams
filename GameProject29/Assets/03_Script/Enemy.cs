using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Unity Function ===============================================

    private void Start  () {

    }

    private void Update () {

    }
    
   private void OnTriggerEnter(Collider obj) {

        Collision col;

        if (obj.TryGetComponent(out col)) {
            Debug.Log(col.GetDamage());
        }
    }
    // User  Function ===============================================

}
