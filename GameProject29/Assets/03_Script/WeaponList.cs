using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour {

    // Show  Property =============================================
    [SerializeField] private List<GameObject> _weaponList;
   
    // User  Method ===============================================
    public  Weapon  GetWeapon   (int index) {
        return _weaponList[index].GetComponent<Weapon>();
    }
    public  int     GetListSize () {
        return _weaponList.Count;
    }
}
