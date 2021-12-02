using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : FacadeData {

    // Hide  Field ================================================
    private Vector2     _aimPosition;
    private Vector2     _tgtPosition;
    private Vector2     _calcPosition;
    private List<int>   _indexes;
    
    // Show  Field ================================================
    [SerializeField] private Slider         hpSlider;
    [SerializeField] private GameObject     aimTarget;
    [SerializeField] private RectTransform  aim;
    [SerializeField] private RectTransform  target;
    [SerializeField] private Transform      muzzle;
    [SerializeField] private WeaponList     weaponList;
    [SerializeField] private Slider         mainWeaponSlider;
    [SerializeField] private List<Slider>   subWeaponSlider;

    // Unity Method ===============================================
    private void Update () {

        HpSlider            ();
        SwitchAimUI         ();
        ScreenAimPosition   ();
        ScreenTargetPosition();
        RecastUI            ();
    }

    // User  Method ===============================================
    private void HpSlider               () {
        hpSlider.value = 1.0f - facade.GetFacade<Player>().GetSetHp;
    }
    private void SwitchAimUI            () {

        GameObject tgt = facade.GetFacade<Player>().GetSetTarget;

        if (tgt != null && tgt.name == aimTarget.name) {
            aim     .gameObject.SetActive(true);
            target  .gameObject.SetActive(false);

        }
        else {
            aim     .gameObject.SetActive(false);
            target  .gameObject.SetActive(true);

            _calcPosition = Vector3.zero;
        }
    }
    private void ScreenAimPosition      () {
        
        var stick       = InputManager.GetPlayerInput().currentActionMap["Lockon"].ReadValue<Vector2>() * 50.0f * Time.deltaTime;
        _calcPosition   += stick;

        var oldPos  = aimTarget.transform.position;

        aimTarget.transform.position = new Vector3(_calcPosition.x , _calcPosition.y, 20.0f);
        
        RaycastHit  hit;
        Vector3     vector      = Camera.main.transform.position;
        Vector3     direction   = Vector3.Normalize(aimTarget.transform.position - vector);
        
        if(Physics.Raycast(vector, direction, out hit, 100)) {
            if (hit.transform.parent.CompareTag("Enemy")) {
                aimTarget.transform.position = hit.point;
            }
        }
        
        aim.GetComponent<RectTransform>().position = RectTransformUtility.WorldToScreenPoint(Camera.main, aimTarget.transform.position);
    }
    private void ScreenTargetPosition   () {

        var tgt = facade.GetFacade<Player>().GetSetTarget;

        if (tgt != null) {
            target.GetComponent<RectTransform>().position
                = RectTransformUtility.WorldToScreenPoint(Camera.main, tgt.transform.position);
        }
        else {
            target.gameObject.SetActive(false);
        }
    }
    private void RecastUI               () {

        int count = 0;

        foreach (var s in subWeaponSlider) {
            s.value = 1.0f - weaponList.GetWeapon(count).GetSetRecastTime;
            ++count;
        }
    }
}