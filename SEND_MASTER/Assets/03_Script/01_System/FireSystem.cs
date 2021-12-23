using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour {

    // Field

    [SerializeField] private string             searchTagName;
    [SerializeField] private List<GameObject>   targetList;
    [SerializeField] private List<WeaponSystem> weaponList;
    [SerializeField] private GameObject         aim;
    
    private Transform   owner;

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
        
        switch (weapon.GetLockType()) {

            case LOCKTYPE.AIM:
                weaponList[weaponIndex].Lunch(aim);
                break;

            case LOCKTYPE.LOCK:
                
                if (targetList.Count <= 0 || targetList[targetIndex] == null) return;
                if (Vector3.Dot(owner.forward, targetList[targetIndex].transform.position - owner.position) < 0.0f) {
                    return;
                }   

                weaponList[weaponIndex].Lunch(targetList[targetIndex].gameObject);

                break;

            default: break;
        }
    }
    public  void AddWeaponIndex     () {

        ++weaponIndex;
        WrapIndex(weaponList, ref weaponIndex);

        if (weaponList[weaponIndex].GetLockType() == LOCKTYPE.LOCK) {
            RefreshList();
        }
    }
    public  void AddTargetIndex     () {
        ++targetIndex;
        WrapIndex(targetList, ref targetIndex);
    }
    public  void SubTargetIndex     () {
        --targetIndex;
        WrapIndex(targetList, ref targetIndex);
    }
        
    public  GameObject      GetTarget    () {
        return (targetList.Count > 0) ? targetList[targetIndex] : null;
    }
    public  WeaponSystem    GetWeapon    () {
        return (weaponList.Count > 0) ? weaponList[weaponIndex] : null;
    }
    
    private void WrapIndex<T>          (List<T> list, ref int index) {

        if (list.Count == 0) {
            index = 0;
            return;
        }

        index = (index < 0) ? list.Count - 1 : index;
        index = (index > list.Count - 1) ? 0 : index;
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
