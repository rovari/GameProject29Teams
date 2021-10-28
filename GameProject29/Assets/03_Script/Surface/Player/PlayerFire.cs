using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : FacadeData {

    // Hide  Property =============================================
    [SerializeField] private int _targetIndex;
    [SerializeField] private int _weaponIndex;
    private bool lockIndex;

    // Show  Property =============================================
    [SerializeField] private TargetList  targetList;
    [SerializeField] private WeaponList  weaponList;
    [SerializeField] private GameObject  aimObject;
    
    // Unity Method ===============================================
    private void Start  () {

        _targetIndex = 0;
        _weaponIndex = 0;

        InputManager.GetGAMEInput.TriggerR      .performed  += _ => Fire();
        InputManager.GetGAMEInput.EastButtonB   .started    += _ => AddWeaponIndex();
        InputManager.GetGAMEInput.WestButtonX   .started    += _ => SubWeaponIndex();

        targetList.RefreshList();
    }
    private void Update () {

        CalcTargetIndex ();
        SetTargetType   ();
    }

    // User  Method ===============================================
    private void Fire               () {
        
        if (InputManager.GetGAMEInput.TriggerL.phase == InputActionPhase.Started) {
            Weapon weapon = weaponList.GetWeapon(weaponList.GetListSize() - 1);
            if (weapon != null) weapon.Lunch(facade.GetFacade<Player>().GetSetTarget);
        }
        else {
            Weapon weapon = weaponList.GetWeapon(_weaponIndex);
            if (weapon != null) weapon.Lunch(facade.GetFacade<Player>().GetSetTarget);
        }
    }
    private void CalcTargetIndex    () {

        if (StateManager.GetSetTakeDown) {

            targetList.RefreshList();
            _targetIndex = (_targetIndex > targetList.GetListSize() - 1) ? targetList.GetListSize() - 1 : _targetIndex;

            StateManager.GetSetTakeDown = false;
        }
        if (weaponList.GetWeapon(_weaponIndex).GetUIType() == Weapon.UITYPE.AIM) return;
        if (Mathf.Abs(InputManager.GetGAMEInput.RStick.ReadValue<Vector2>().x) > 0.7f && !lockIndex) StartCoroutine("TargetIndex");
    }
    private void AddWeaponIndex     () {
        targetList.RefreshList();
        _weaponIndex = (_weaponIndex >= weaponList.GetListSize() - 2) ? 0 : ++_weaponIndex;
    }
    private void SubWeaponIndex     () {
        targetList.RefreshList();
        _weaponIndex = (_weaponIndex <= 0) ? weaponList.GetListSize() - 2 : --_weaponIndex;
    }   
    private void SetTargetType      () {

        Weapon weapon = weaponList.GetWeapon(_weaponIndex);

        facade.GetFacade<Player>().GetSetTarget = null;
        facade.GetFacade<Player>().GetSetTarget = (weapon.GetUIType() == Weapon.UITYPE.AIM)
                ? aimObject
                : targetList.GetTarget(_targetIndex);
    }
    private IEnumerator TargetIndex () {

        lockIndex = true;

        while (true) {

            if (Mathf.Abs(InputManager.GetGAMEInput.RStick.ReadValue<Vector2>().x) < 0.3f) break;

            if (InputManager.GetGAMEInput.RStick.ReadValue<Vector2>().x > 0.7f) {
                _targetIndex = (_targetIndex >= targetList.GetListSize() - 1) ? 0 : ++_targetIndex;
            }

            if (InputManager.GetGAMEInput.RStick.ReadValue<Vector2>().x < -0.7f) {
                _targetIndex = (_targetIndex <= 0) ? targetList.GetListSize() - 1 : --_targetIndex;
            }

            yield return new WaitForSeconds(0.5f);
        }

        lockIndex = false;
    }
}
