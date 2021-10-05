using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : FacadeData {

    // Hide  Property =============================================
    private int _targetIndex;
    private int _weaponIndex;

    // Show  Property =============================================
    [SerializeField] private TargetList  targetList;
    [SerializeField] private WeaponList  weaponList;

    // Unity Method ===============================================
    private void Awake  () {

        _targetIndex = 0;
        _weaponIndex = 0;
    }

    private void Update () {

        ChangeIndex();
        Fire();
    }

    // User  Method ===============================================
    private void Fire       () {

    }
    private void ChangeIndex() {

    }
}
