using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : ActorData {
    
    // Field
    [SerializeField] private Transform  aimTarget;
    [SerializeField] private Transform  lockTarget;

    [SerializeField] private Text       weaponText;

    [SerializeField] private Slider     weaponSlider;
    [SerializeField] private Slider     stabilitySlider;
    [SerializeField] private Slider     progressSlider;
    [SerializeField] private Slider     rewardSlider;

    private Vector2 calcPosition;
    private float   length;
    private Vector3 aimBaseScale;
    private Vector3 lockBaseScale;

    // Property

    // Method
    private void  SetSliderValue    () {
        
        weaponText.text         = ((Player)actor).GetFireSystem().GetWeapon().gameObject.name;
        weaponSlider.value      = ((Player)actor).GetFireSystem().GetWeapon().GetRecastNormalize();

        if (StateManager.GetTimeLine().duration > 0.0 && StateManager.GetTimeLine().time > 0.0) {
            progressSlider.value  = (float)(1.0 / StateManager.GetTimeLine().duration * StateManager.GetTimeLine().time);
        }
        else progressSlider.value = 0.0f;

        rewardSlider.value = 1.0f / 100000.0f * StateManager.GetSetScore;

        if (actor.GetActorState().hp > 0.0f) {
            stabilitySlider.value = 1.0f / actor.GetActorState().defHp * actor.GetActorState().hp;
        }
        else stabilitySlider.value = 0.0f;
    }
    private void  SwitchTargetUI    () {
        
        switch (((Player)actor).GetFireSystem().GetWeapon().GetLockType()) {

            case LOCKTYPE.AIM:

                aimTarget   .gameObject.SetActive(true);
                lockTarget  .gameObject.SetActive(false);
                break;

            case LOCKTYPE.LOCK:
                aimTarget   .gameObject.SetActive(false);

                if(((Player)actor).GetFireSystem().GetTarget() != null)
                lockTarget  .gameObject.SetActive(true);
                break;

            default: break;
        }
    }
    private void  AimPosition       () {
        
        var stick   = InputManager.GetPlayerInput().currentActionMap["Aim"].ReadValue<Vector2>() * 25.0f * actor.GetActorDeltaTime();
        var oldCalc = calcPosition;

        calcPosition += stick;

        aimTarget.transform.position = Camera.main.transform.position + new Vector3(calcPosition.x , calcPosition.y, length);

        RaycastHit hit;
        Vector3 vector = Camera.main.transform.position;
        Vector3 direction = Vector3.Normalize(aimTarget.position - vector);

        if (Physics.Raycast(vector, direction, out hit, length)) {

            if (hit.transform.parent.CompareTag("Enemy") || hit.transform.CompareTag("Field")) {

                Vector3 point = hit.point;

                if (Vector3.Dot(actor.GetSetTransform.forward, point - actor.GetSetTransform.position) < 0.0f) {

                    point.z = actor.GetSetTransform.position.z;
                    calcPosition = oldCalc;
                }

                aimTarget.position = point;
            }
        }
    }
    private void  LockPosition      () {

        if (((Player)actor).GetFireSystem().GetTarget() == null) {

            lockTarget.gameObject.SetActive(false);
            return;
        }

        lockTarget.position =
            ((Player)actor).GetFireSystem().GetTarget().transform.position;

        Quaternion rot = new Quaternion(
                Mathf.PerlinNoise(actor.GetActorDeltaTime(), actor.GetActorDeltaTime()) * actor.GetActorDeltaTime(),
                Mathf.PerlinNoise(actor.GetActorDeltaTime(), actor.GetActorDeltaTime()) * actor.GetActorDeltaTime(),
                Mathf.PerlinNoise(actor.GetActorDeltaTime(), actor.GetActorDeltaTime()) * actor.GetActorDeltaTime(),
                1.0f
            );

        lockTarget.localRotation *= rot;
    }
    private void  AimObjectScale    () {

        aimTarget .localScale = aimBaseScale  * GetDistance(aimTarget .position);
        lockTarget.localScale = lockBaseScale * GetDistance(lockTarget.position);
    }
    private float GetDistance       (Vector3 position) {
        return (position - new Vector3(position.x, position.y, Camera.main.transform.position.z)).magnitude;
    }

	// Signal

    // Unity
	private void Start() {

        length = 20.0f;
        calcPosition = Camera.main.transform.forward * length;
        aimBaseScale    = aimTarget .localScale / GetDistance(aimTarget .position);
        lockBaseScale   = lockTarget.localScale / GetDistance(lockTarget.position);
    }

	// Dependent Update by State
    protected override void GameUpdate   () {

        AimPosition     ();
        LockPosition    ();
        SetSliderValue  ();
        SwitchTargetUI  ();
        AimObjectScale  ();
	}
    protected override void MenuUpdate   () {

        aimTarget   .gameObject.SetActive(false);
        lockTarget  .gameObject.SetActive(false);
    }
    protected override void LoadUpdate   () { 

        aimTarget   .gameObject.SetActive(false);
        lockTarget  .gameObject.SetActive(false);
    }
    protected override void EventUpdate  () { 

        aimTarget   .gameObject.SetActive(false);
        lockTarget  .gameObject.SetActive(false);
    }
}
