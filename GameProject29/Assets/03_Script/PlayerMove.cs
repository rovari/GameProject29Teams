using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : FacadeData {
    
    // Hide  Property =============================================
    private float   _velocity;
    private float   _sceneCount;
    private bool    _isJump;

    // Show  Property =============================================
    [SerializeField] private AnimationCurve _frictionCurve;
    [SerializeField] private AnimationCurve _blowCurve;
    [SerializeField] private float          _moveSpeed;
    [SerializeField] private float          _maxSpeed;

    // Unity Method ===============================================
    private void Awake  () {

        _velocity = 0.0f;
        
        InputManager.GetGAMEInput.LButton.started += _ => StartCoroutine("Jump");
    }
    private void Update () {

        CalculationStability();
        Move();    
    }

    // User  Method ===============================================
    private void Move   () {

        _sceneCount += Time.deltaTime;
        _velocity   += Mathf.Lerp(-_moveSpeed, _moveSpeed, (InputManager.GetGAMEInput.LStick.ReadValue<Vector2>().x + 1.0f) * 0.5f) * Time.deltaTime;
        _velocity   =  Mathf.Clamp(_velocity, -_maxSpeed, _maxSpeed);

        
        facade.GetFacade<Player>().GetSetPosition += new Vector3(_velocity * Time.deltaTime, Mathf.Sin(_sceneCount) * 1e-1f * Time.deltaTime); 
    }
    private void CalculationStability() {

        float e = Mathf.Epsilon;
        float f = _frictionCurve.Evaluate(facade.GetFacade<Player>().GetSetHp) * Time.deltaTime;

        if (Mathf.Abs(_velocity) > 0.0f) _velocity += (_velocity > 0.0f) ? -f : f;

        _velocity = (Mathf.Abs(_velocity) < f + e) ? 0.0f : _velocity;
    }

    private IEnumerator Jump() {

        if (!_isJump)
        {
            _isJump = true;

            float defHeight = facade.GetFacade<Player>().GetSetPosition.y;
            float jampPow = 5.0f;

            while (defHeight <= facade.GetFacade<Player>().GetSetPosition.y)
            {

                facade.GetFacade<Player>().GetSetPosition += new Vector3(0.0f, jampPow * Time.deltaTime, 0.0f);
                jampPow -= 9.8f * Time.deltaTime;
                yield return null;
            }

            facade.GetFacade<Player>().GetSetPosition = new Vector3(facade.GetFacade<Player>().GetSetPosition.x, defHeight, facade.GetFacade<Player>().GetSetPosition.z);
            _isJump = false;
        }
    }
}
