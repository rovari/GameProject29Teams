using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : FacadeData {

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
    private void Fire() {

        bool dammy = false;

        if(/*r trigger*/dammy) weaponList.GetWeapon(_weaponIndex)                   .Lunch(transform.position, targetList.GetTarget(_targetIndex));
        if(/*r trigger*/dammy) weaponList.GetWeapon(weaponList.GetListSize() - 1)   .Lunch(transform.position ,targetList.GetTarget(_targetIndex));
    }
    private void ChangeIndex() {

        bool dammy = false;

        if (/*l stick*/dammy)       ++_targetIndex;
        if (/*l stick*/dammy)       --_targetIndex;
        if (/*botton east*/dammy)   ++_weaponIndex;
        if (/*botton west*/dammy)   --_weaponIndex;
   
        if (_targetIndex < 0) _targetIndex = targetList.GetListSize() - 1;
        if (_targetIndex > targetList.GetListSize() - 1) _targetIndex = 0;
        if (_weaponIndex < 0) _weaponIndex = weaponList.GetListSize() - 2;
        if (_weaponIndex > weaponList.GetListSize() - 2) _weaponIndex = 0;
    }
    private void AimUIType() {

        switch (_weaponIndex) {
            case 0: break;
            case 1: break;
            case 2: break;
        }
    }
}
