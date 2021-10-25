using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : FacadeData {

    // Hide  Property =============================================
    [SerializeField] private int _targetIndex;
    [SerializeField] private int _weaponIndex;

    // Show  Property =============================================
    [SerializeField] private TargetList  targetList;
    [SerializeField] private WeaponList  weaponList;

    // Unity Method ===============================================
    private void Start  () {

        _targetIndex = 0;
        _weaponIndex = 0;

        InputManager.GetGAMEInput.TriggerR      .performed  += _ => Fire();
        InputManager.GetGAMEInput.EastButtonB   .started    += _ => AddWeaponIndex();
        InputManager.GetGAMEInput.WestButtonX   .started    += _ => SubWeaponIndex();
    }

    // User  Method ===============================================
    private void Fire           () {

        if (InputManager.GetGAMEInput.TriggerL.phase == InputActionPhase.Started) {

            Weapon weapon = weaponList.GetWeapon(_weaponIndex);
            if(weapon != null) weapon.Lunch(targetList.GetTarget(_targetIndex));
        }
        else {
            Weapon weapon = weaponList.GetWeapon(_weaponIndex);
            if(weapon != null) weapon.Lunch(targetList.GetTarget(_targetIndex));
        }
    }
    private void AddTargetIndex () {
        _targetIndex = (_targetIndex > targetList.GetListSize() - 1) ? 0 : ++_targetIndex;
    }
    private void SubTargetIndex () {
        _targetIndex = (_targetIndex < 0) ? targetList.GetListSize() - 1 : --_targetIndex;
    }
    private void AddWeaponIndex () {
        targetList.RefreshList();
        _weaponIndex = (_weaponIndex > weaponList.GetListSize() - 2) ? 0 : ++_weaponIndex;
    }
    private void SubWeaponIndex () {
        targetList.RefreshList();
        _weaponIndex = (_weaponIndex < 0) ? weaponList.GetListSize() - 2 : --_weaponIndex;
    }
    private void AimUIType      () {
        
        switch (weaponList.GetWeapon(_weaponIndex).GetUIType()) {
            case Weapon.UITYPE.AIM:  break;
            case Weapon.UITYPE.LOCK: break;
        }
    }
}
