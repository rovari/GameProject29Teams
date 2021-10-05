using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : FacadeData {

    // Hide  Property =============================================
    private Vector2 _aimPosition;
    private Vector2 _tgtPosition;

    // Show  Property =============================================
    [SerializeField] private GameObject aim;
    [SerializeField] private GameObject tgt;

    // Unity Method ===============================================
    private void Start  () {

    }
    private void Update () {
        
    }

    // User  Method ===============================================
    public  void AimPositonToWorld() {
        
    }
    private void ScreenAimPosition() {

        _aimPosition.x += /*r stick*/0.0f;
        _aimPosition.y += /*r stick*/0.0f;

        aim.GetComponent<RectTransform>().position = _aimPosition;
    }
    private void ScreenTgtPosition() {

        tgt.GetComponent<RectTransform>().position = _tgtPosition;
    }
}