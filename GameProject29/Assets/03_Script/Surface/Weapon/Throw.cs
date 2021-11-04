using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : Weapon {

    // User  Method =============================================== 
    override protected IEnumerator TimeLine() {

        _recast = true;

        foreach(var b in _bulletList) {
            b.StartBullet(_target);
            yield return new WaitForSeconds(_interval);
        }

        yield return new WaitForSeconds(_recastTime);
        _recast = false;
    }
}
