using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : FacadeData {

    // Hide  Property =============================================
    
    // Show  Property =============================================
    [SerializeField] private TargetList  targetList;
    [SerializeField] private WeaponList  weaponList;

    // Unity Method ===============================================
    private void Start  () {
        StartCoroutine("SearchPlayer");
    }
    
    // User  Method ===============================================
    public void Lunch       (int num) {

        Debug.Log("Lunch to " + targetList.GetTarget(0).name);

        //weaponList.GetWeapon(num).Lunch(targetList.GetTarget(0));
    }
    
    private IEnumerator SearchPlayer() {

        while (true) {
            targetList.RefreshList();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
