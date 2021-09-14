using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  

    TestAction testInputActions;

    void Awake()
    {
        DontDestroyOnLoad(this);
        testInputActions = new TestAction();
        testInputActions.Enable();
        testInputActions.Player.Fire.performed += context => Debug.Log("Fire");
    }

    void Update()
    {
        const float Speed = 1f;

        var direction = testInputActions.Player.Move.ReadValue<Vector2>();
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
