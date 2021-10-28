using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : FacadeData {

    // Hide  Property =============================================
    private Vector2 _aimPosition;
    private Vector2 _tgtPosition;
    private Vector2 _calcPosition;

    // Show  Property =============================================
    [SerializeField] private GameObject     aimTarget;
    [SerializeField] private RectTransform  aim;
    [SerializeField] private RectTransform  target;
    [SerializeField] private Transform      muzzle;

    // Unity Method ===============================================
    private void Update () {

        SwitchAimUI         ();
        ScreenAimPosition   ();
        ScreenTargetPosition();
    }

    // User  Method ===============================================

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
        
        var stick       = InputManager.GetGAMEInput.RStick.ReadValue<Vector2>() * 50.0f * Time.deltaTime;
        _calcPosition   += stick;
        
        aimTarget.transform.position = new Vector3(_calcPosition.x , _calcPosition.y, 20.0f); 
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
}