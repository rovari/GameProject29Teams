using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponList : MonoBehaviour {

    // Hide  Field ================================================ 
    
    // Show  Field ================================================
    [SerializeField] private List<GameObject>   _weaponList;

    // Unity Method ===============================================
        
    // User  Method ===============================================
    public  Weapon  GetWeapon       (int index) {
        return (_weaponList.Count > 0) ? _weaponList[index].GetComponent<Weapon>() : null;
    }
    public  int     GetListSize     () {
        return _weaponList.Count;
    }

}
