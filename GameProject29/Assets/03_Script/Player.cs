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
    public  GameObject          aim;

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
    public  int                 targetIndex;
    private Vector3             aimTarget;
    private GameObject          targetList;
    private GameObject          nowTarget;

    private Vector2             leftStick;
    private Vector2             rightStick;
    private InputActionPhase    weaponIndexAdd;
    private InputActionPhase    weaponIndexSub;
    private InputActionPhase    targetIndexIn;
    private bool                fire;
    private bool                special;

    // Unity Function ===============================================

    private void Start  (){
        
        targetList  = gameObject.transform.Find("TargetList").gameObject;
        weaponIndex = 0;
        targetIndex = 0;

        StartCoroutine("ChengeIndex");
    }

    private void Update () {

        PlayerLost          ();
        CalculateFriction   ();
        PlayerFire          ();
        PlayerMove          ();
    }

    
    private void OnTriggerEnter(Collider obj) {

        Collision col;

        if (obj.TryGetComponent(out col)) {
            Debug.Log(col.GetDamage());
        }
    }

    // User  Function ===============================================

    public  GameObject      GetAim      () {
        return aim;
    }

    public  GameObject      GetNowTarget() {
        return nowTarget;
    }

    public  void    OnMove              (InputAction.CallbackContext context) {
        leftStick = context.ReadValue<Vector2>();
    }

    public  void    OnFire              (InputAction.CallbackContext context) {
        fire = context.ReadValueAsButton();
    } 
    
    public  void    OnSpecial           (InputAction.CallbackContext context) {
        special     = context.ReadValueAsButton();
    }

    public  void    OnWeaponIndexAdd    (InputAction.CallbackContext context) {
        weaponIndexAdd    = context.phase;
    }

    public  void    OnWeaponIndexSub    (InputAction.CallbackContext context) {
        weaponIndexSub    = context.phase;
    }

    public  void    OnTargetIndex       (InputAction.CallbackContext context) {
        targetIndexIn       = context.phase;
        rightStick          = context.ReadValue<Vector2>();
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

        ChengeIndex();

        nowTarget = targetList.GetComponent<TargetList>().GetTarget(targetIndex);
        
        switch (weaponIndex) {
            case 0:
                aim         .SetActive(true);
                targetList  .SetActive(false);

                if (!special && fire) LaunchWeapon((int)WEAPON.SHOT, aim);
                break;
            case 1:
                aim         .SetActive(false);
                targetList  .SetActive(true);

                if (!special && fire && nowTarget) LaunchWeapon((int)WEAPON.THROW, nowTarget);
                break;
            case 2:
                aim         .SetActive(false);
                targetList  .SetActive(true);

                if (!special && fire && nowTarget) StartCoroutine("HomingSugoino", nowTarget);
                break;
        }

        if( special && fire) {
            LaunchWeapon((int)WEAPON.BOMB, nowTarget);
        }
    }

    private void    PlayerMove          () {

        velocity += Mathf.Lerp(-moveSpeed, moveSpeed, (leftStick.x + 1.0f) * 0.5f) * Time.deltaTime;

        velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed);
        transform.position += new Vector3(velocity * Time.deltaTime, Mathf.Sin(Time.time * 2.0f) * 0.001f, 0.0f);
    }

    private void    ChengeIndex         () {

        if (weaponIndexAdd == InputActionPhase.Performed) {

            ++weaponIndex;

            targetIndex     = 0;
            weaponIndexAdd  = InputActionPhase.Canceled;
            aim         .SetActive(false);
            targetList  .SetActive(false);

            if (weaponIndex > 2) weaponIndex = 0;
        }
        
        if (weaponIndexSub == InputActionPhase.Performed) {

            --weaponIndex;

            targetIndex     = 0;
            weaponIndexSub  = InputActionPhase.Canceled;
            aim         .SetActive(false);
            targetList  .SetActive(false);

            if (weaponIndex < 0) weaponIndex = 2;
        }

        if (rightStick.x >  0.9f && targetIndexIn == InputActionPhase.Performed) {
            ++targetIndex;
            targetIndexIn = InputActionPhase.Canceled;
            if (targetIndex > targetList.GetComponent<TargetList>().GetListSize() - 1) targetIndex = 0;
        }
                             
        if (rightStick.x < -0.9f && targetIndexIn == InputActionPhase.Performed) {
            --targetIndex;
            targetIndexIn = InputActionPhase.Canceled;
            if (targetIndex < 0) targetIndex = targetList.GetComponent<TargetList>().GetListSize() - 1;
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
