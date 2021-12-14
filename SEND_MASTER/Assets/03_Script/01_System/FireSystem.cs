using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour {

    // Field
    public int targetIndex;
    public int weaponIndex;

    [SerializeField] private Transform          owner;
    [SerializeField] private string             searchTagName;
    [SerializeField] private List<GameObject>   targetList;
    [SerializeField] private List<WeaponSystem> weaponList;
    
    // Property
    
    // Method
    public  void RefreshList        () {
        FindTargetWithTag   ();
        SortListByDistance  ();
    }
    public  void Lunch              () {

        if (targetList[targetIndex] == null) return;

        weaponList[weaponIndex].Lunch(targetList[targetIndex].gameObject);
    }
    public  void ClampIndex         () {

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
