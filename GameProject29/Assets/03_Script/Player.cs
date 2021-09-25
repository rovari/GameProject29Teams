using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    
    [Range(0.0f, 1.0f)]
    public  float   damage      = 0.0f;
    private float   velocity    = 0.0f;

    public  bool    pow         = false;
    public  float   powIndex    = 1.0f;
    public  float   maxFriction = 1.0f;
    public  float   minFriction = 0.0f;
    public  float   moveSpeed   = 5.0f;
    public  float   maxSpeed    = 5.0f;
    
    public  GameObject          model;

    public  enum    WEAPON {
        SHOT    = 0,
        THROW,
        HOMING0,
        HOMING1,
        HOMING2,
        HOMING3,
        HOMING4,
        HOMING5,
        HOMING6,
        BOMB 
    }
    public  List<GameObject>    bullets;
    public  int                 weaponIndex;

    private GameObject          targetList;
    private Vector2             leftStick;
    private bool                fire;
    private bool                special;
    private InputActionPhase    indexAdd;
    private InputActionPhase    indexSub;

    // Unity Function ===============================================

    private void Start  (){
        targetList  = gameObject.transform.Find("TargetList").gameObject;
        weaponIndex = 0;
    }

    private void Update () {

        PlayerLost          ();
        CalculateFriction   ();
        PlayerFire          ();
        PlayerMove          ();
    }

    // User  Function ===============================================
    
    public  void    OnMove              (InputAction.CallbackContext context) {
        leftStick = context.ReadValue<Vector2>();
    }

    public  void    OnFire              (InputAction.CallbackContext context) {
        fire = context.ReadValueAsButton();
    } 
    
    public  void    OnSpecial           (InputAction.CallbackContext context) {
        special = context.ReadValueAsButton();
    }

    public  void    OnWeaponIndexAdd    (InputAction.CallbackContext context) {
        indexAdd    = context.phase;
    }

    public  void    OnWeaponIndexSub    (InputAction.CallbackContext context) {
        indexSub    = context.phase;
    }

    private void    CalculateFriction   () {

        float e = 0.00001f;
        float d = Mathf.Clamp(damage, e, 1.0f);
        float f = Mathf.Lerp(minFriction, maxFriction,1.0f - damage);

        if (pow) f = Mathf.Pow(f, powIndex);

        f *= Time.deltaTime;
        
        if (Mathf.Abs(velocity) > 0) velocity += (velocity > 0) ? -f : f;
        velocity = (Mathf.Abs(velocity) < f + e) ? 0.0f : velocity;
    }

    private void    PlayerLost          () {

        if (!model.GetComponent<Renderer>().isVisible) {

            this.GetComponent<Transform>().position 
                = new Vector3( 0.0f, transform.position.y + Mathf.Sin(Time.time * 2.0f) * 0.001f, transform.position.z);

            velocity = 0.0f;
        }
    }

    private void    PlayerFire          () {

        ChengeWeaponIndex();

        GameObject target = targetList.GetComponent<TargetList>().GetTarget(0);

        switch (weaponIndex) {
            case 0:
                targetList.SetActive(false);
                if (!special && fire) LaunchWeapon((int)WEAPON.SHOT, target);
                break;
            case 1:
                targetList.SetActive(true);
                if (!special && fire) LaunchWeapon((int)WEAPON.THROW, target);
                break;
            case 2:
                targetList.SetActive(true);
                if (!special && fire && target) StartCoroutine("HomingSugoino", target);
                break;
        }

        if( special && fire) {
            LaunchWeapon((int)WEAPON.BOMB, target);
        }
    }

    private void    PlayerMove          () {

        velocity += Mathf.Lerp(-moveSpeed, moveSpeed, (leftStick.x + 1.0f) * 0.5f) * Time.deltaTime;

        velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed);
        transform.position += new Vector3(velocity * Time.deltaTime, Mathf.Sin(Time.time * 2.0f) * 0.001f, 0.0f);
    }
    
    private void    ChengeWeaponIndex   () {

        if (InputActionPhase.Started == indexAdd) {
            ++weaponIndex;
            targetList.SetActive(false);

            if (weaponIndex > 2) weaponIndex = 0;
        }

        if (InputActionPhase.Started == indexSub) {
            --weaponIndex;
            targetList.SetActive(false);

            if (weaponIndex < 0) weaponIndex = 2;
        }
    }

    private void    LaunchWeapon        (int number, GameObject target) {
        bullets[number].SetActive(true);
        bullets[number].GetComponent<Bullet>().SetTarget(target);
        bullets[number].GetComponent<Bullet>().StartWeponCalc();
    }

    IEnumerator HomingSugoino(GameObject target) {
        
        LaunchWeapon((int)WEAPON.HOMING0, target);
        yield return new WaitForSeconds(0.1f);
        LaunchWeapon((int)WEAPON.HOMING1, target);
        yield return new WaitForSeconds(0.1f);
        LaunchWeapon((int)WEAPON.HOMING2, target);
        yield return new WaitForSeconds(0.1f);
        LaunchWeapon((int)WEAPON.HOMING3, target);
        yield return new WaitForSeconds(0.1f);
        LaunchWeapon((int)WEAPON.HOMING4, target);
        yield return new WaitForSeconds(0.1f);
        LaunchWeapon((int)WEAPON.HOMING5, target);
        yield return new WaitForSeconds(0.1f);
        LaunchWeapon((int)WEAPON.HOMING6, target);
    }
}
