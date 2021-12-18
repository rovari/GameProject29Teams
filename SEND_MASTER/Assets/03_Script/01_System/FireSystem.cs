using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour {

    // Field

    [SerializeField] private string             searchTagName;
    [SerializeField] private List<GameObject>   targetList;
    [SerializeField] private List<WeaponSystem> weaponList;
    
    private Transform   owner;
    private GameObject  aim;

    private int         targetIndex;
    private int         weaponIndex;

    // Property
    
    // Method
    public  void SetOwner           (Transform inOnwer) {
        owner = inOnwer;
    }
    public  void SetWeaponIndex     (int index) {
        weaponIndex = index;
    }
    public  void RefreshList        () {
        FindTargetWithTag   ();
        SortListByDistance  ();
    }
    public  void Lunch              () {
        
        WeaponSystem weapon = weaponList[weaponIndex];

        switch (weapon.GetLockType()) {

            case LOCKTYPE.AIM:
                weaponList[weaponIndex].Lunch(aim);
                break;

            case LOCKTYPE.LOCK:

                if (targetList.Count == 0 || targetList[targetIndex] == null) return;
                weaponList[weaponIndex].Lunch(targetList[targetIndex].gameObject);

                break;

            default: break;
        }
    }
    public  void AddWeaaponIndex    () {
        ++weaponIndex;

        if (weaponList[weaponIndex].GetLockType() == LOCKTYPE.LOCK) {
            RefreshList();
        }
    }
    public  void AddTargetIndex     () {
        ++targetIndex;
    }

    public  GameObject      GetTarget    () {
        return (targetList.Count > 0) ? targetList[targetIndex] : null;
    }
    public  WeaponSystem    GetWeapon    () {
        return (weaponList.Count > 0) ? weaponList[weaponIndex] : null;
    }
    
    private void ClampIndex         () {

        targetIndex 
            = (targetIndex >= targetList.Count)
            ? 0 
            : (targetIndex < 0 && targetList.Count > 0)
            ? targetList.Count - 1 
            : targetIndex;

        weaponIndex
            = (weaponIndex >= weaponList.Count)
            ? 0
            : (weaponIndex < 0 && weaponList.Count > 0)
            ? weaponList.Count - 1
            : weaponIndex;
    }
    private void FindTargetWithTag  () {
        targetList.Clear    ();
        targetList.AddRange (GameObject.FindGameObjectsWithTag(searchTagName));
    }
    private void SortListByDistance () {
        if(targetList.Count > 0) {

            targetList.Sort((a, b) =>
                Vector3.Distance(a.transform.position, owner.position).CompareTo(
                Vector3.Distance(b.transform.position, owner.position)));
        }
    }

    // Unity
    private void Start  () {

	}
    private void Update () {
        ClampIndex();
    }
}
