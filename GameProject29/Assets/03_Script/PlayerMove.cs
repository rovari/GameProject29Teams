using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : FacadeData {
    
    // Hide  Property =============================================
    private float   _velocity;

    // Show  Property =============================================
    [SerializeField] private AnimationCurve _frictionCurve;
    [SerializeField] private AnimationCurve _blowCurve;
    [SerializeField] private float          _moveSpeed;
    [SerializeField] private float          _maxSpeed;

    // Unity Method ===============================================
    private void Awake  () {

        _velocity = 0.0f;
    }
    private void Update () {

        CalculationStability();
        Move();    
    }

    // User  Method ===============================================
    private void Move() {

        _velocity += Mathf.Lerp(-_moveSpeed, _moveSpeed, (/*stick*/0.0f + 1.0f) * 0.5f) * Time.deltaTime;
        _velocity =  Mathf.Clamp(_velocity, -_maxSpeed, _maxSpeed);
        
        facade.GetFacade<Player>().GetSetPosition += new Vector3(_velocity * Time.deltaTime, Mathf.Sin(Time.time * 2.0f) * Time.deltaTime); ;
    }
    private void CalculationStability() {

        float e = Mathf.Epsilon;
        float f = _frictionCurve.Evaluate(facade.GetFacade<Player>().GetSetHp) * Time.deltaTime;

        if (Mathf.Abs(_velocity) > 0.0f) _velocity += (_velocity > 0.0f) ? -f : f;

        _velocity = (Mathf.Abs(_velocity) < f + e) ? 0.0f : _velocity;
    }
}
