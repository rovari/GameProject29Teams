using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

        InputManager.GetGAMEInput.TriggerR      .started += _ => Fire();
        InputManager.GetGAMEInput.EastButtonB   .started += _ => AddWeaponIndex();
        InputManager.GetGAMEInput.WestButtonX   .started += _ => SubWeaponIndex();
    }

    // User  Method ===============================================
    private void Fire           () {

        if (InputManager.GetGAMEInput.TriggerL.phase == InputActionPhase.Started) {
            weaponList.GetWeapon(_weaponIndex).Lunch(transform.position, targetList.GetTarget(_targetIndex));
        }
        else {
            weaponList.GetWeapon(weaponList.GetListSize() - 1).Lunch(transform.position, targetList.GetTarget(_targetIndex));
        }
    }
    private void AddTargetIndex () {
        _targetIndex = (_targetIndex > targetList.GetListSize() - 1) ? 0 : ++_targetIndex;
    }
    private void SubTargetIndex () {
        _targetIndex = (_targetIndex < 0) ? targetList.GetListSize() - 1 : --_targetIndex;
    }
    private void AddWeaponIndex () {
        _weaponIndex = (_weaponIndex > weaponList.GetListSize() - 2) ? 0 : ++_weaponIndex;
    }
    private void SubWeaponIndex () {
        _weaponIndex = (_weaponIndex < 0) ? weaponList.GetListSize() - 2 : --_weaponIndex;
    }
    private void AimUIType      () {

        switch (_weaponIndex) {
            case 0: break;
            case 1: break;
            case 2: break;
        }
    }
}
