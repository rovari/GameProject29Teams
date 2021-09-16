using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector3 move;
    public float Speed;
    float trigger;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        
       if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Fire");
        }
    }
    public void OntriggerV(InputAction.CallbackContext context)
    {
       
    }

    void Update()
    {
       // const float Speed = 1f;
        transform.Translate(move * Speed * Time.deltaTime);

       
    }
}
