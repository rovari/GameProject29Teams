using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : FacadeData {

    // Hide  Property =============================================
    private Vector3 _defaultPos;
    private float   _velocity;
    private float   _sceneCount;
    private bool    _isJump;

    // Show  Property =============================================
    [SerializeField] private AnimationCurve _frictionCurve;
    [SerializeField] private AnimationCurve _blowCurve;
    [SerializeField] private float          _moveSpeed;
    [SerializeField] private float          _maxSpeed;
    [SerializeField] private float          _blow;
    [SerializeField] private float          _jumpPow;
    
    // Unity Method ===============================================
    private void Start  () {

        _defaultPos = facade.GetFacade<Player>().GetSetPosition;
        _velocity   = 0.0f;
        
        InputManager.GetGAMEInput.LButton.started += _ => StartCoroutine("Jump");
    }
    private void Update () {

        CalculationStability();
        Move();    
    }

    // User  Method ===============================================
    private void Move                   () {

        _sceneCount += Time.deltaTime;
        _velocity   += Mathf.Lerp(-_moveSpeed, _moveSpeed, (InputManager.GetGAMEInput.LStick.ReadValue<Vector2>().x + 1.0f) * 0.5f) * Time.deltaTime;
        _velocity   =  Mathf.Clamp(_velocity, -_maxSpeed, _maxSpeed);

        float rot = 1.0f - Vector3.Dot(Vector3.up, Vector3.Normalize(new Vector3(_velocity, 1.0f, 0.0f)));
        rot = (_velocity < 0.0f) ? rot : -rot;
        
        facade.GetFacade<Player>().GetSetPosition += new Vector3(_velocity * Time.deltaTime, 0.0f);
        facade.GetFacade<Player>().GetSetRotation = Quaternion.Euler(0.0f, 0.0f, rot * (180.0f / Mathf.PI) * 0.5f);

    }
    private void CalculationStability   () {

        float e = Mathf.Epsilon;
        float f = _frictionCurve.Evaluate(facade.GetFacade<Player>().GetSetHp) * Time.deltaTime;

        if (Mathf.Abs(_velocity) > 0.0f) _velocity += (_velocity > 0.0f) ? -f : f;

        _velocity = (Mathf.Abs(_velocity) < f + e) ? 0.0f : _velocity;
    }
    private void DamageBlow             (float collisionPosX, float damage) {

        float blow = Mathf.Clamp((_blowCurve.Evaluate(facade.GetFacade<Player>().GetSetHp) * (damage * 10.0f)) * 10.0f, 1.0f, 1000.0f);     
        blow = (collisionPosX > facade.GetFacade<Player>().GetSetPosition.x) ? blow : -blow;

        _velocity += blow;
    }

    private IEnumerator Jump() {

        float jumpPow = _jumpPow;

        if (!_isJump) {

            _isJump = true;
            
            while (_defaultPos.y <= facade.GetFacade<Player>().GetSetPosition.y) {

                facade.GetFacade<Player>().GetSetPosition += new Vector3(0.0f, jumpPow * Time.deltaTime, 0.0f);
                jumpPow -= 9.8f * Time.deltaTime;
                yield return null;
            }

            facade.GetFacade<Player>().GetSetPosition = new Vector3(facade.GetFacade<Player>().GetSetPosition.x, _defaultPos.y, facade.GetFacade<Player>().GetSetPosition.z);
            _isJump = false;
        }
    }
}
