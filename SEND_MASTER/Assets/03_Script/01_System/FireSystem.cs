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

    [SerializeField]private int         targetIndex;
    [SerializeField]private int         weaponIndex;

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
        
        if(Vector3.Dot(owner.forward, targetList[targetIndex].transform.position - owner.position) < 0.0f) {
            return;
        }

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
    public  void AddWeaponIndex     () {

        ++weaponIndex;
        WrapIndex();

        if (weaponList[weaponIndex].GetLockType() == LOCKTYPE.LOCK) {
            RefreshList();
        }
    }
    public  void AddTargetIndex     () {
        ++targetIndex;
        WrapIndex();
    }
        
    public  GameObject      GetTarget    () {
        return (targetList.Count > 0) ? targetList[targetIndex] : null;
    }
    public  WeaponSystem    GetWeapon    () {
        return (weaponList.Count > 0) ? weaponList[weaponIndex] : null;
    }
    
    private void WrapIndex          () {

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
        
        foreach(var i in GameObject.FindGameObjectsWithTag(searchTagName)) {

            if (i.transform.position.z < 10.0f
                && Vector3.Dot(owner.forward, i.transform.position - owner.position) > 0.0f) {

                targetList.Add(i);
            }
        }
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
        
    }
}
