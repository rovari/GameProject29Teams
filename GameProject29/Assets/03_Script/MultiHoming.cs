using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiHoming : Weapon {

    // User  Method =============================================== 
    public override IEnumerator TimeLine(Vector3 muzzle, GameObject target) {

        foreach(var b in _bulletList) {
            b.StartBullet(muzzle, target);
            yield return new WaitForSeconds(_interval);
        }
    }
}
