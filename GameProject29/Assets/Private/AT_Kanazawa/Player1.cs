using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    Vector3 wheel;
    Vector3 move;
    public float Speed;
    float trigger;
    int select;
    bool CK = false;

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
    
    public void OnPush(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            //Debug.Log("On");
            CK = !CK;
        }
    }


    public void OnMause(InputAction.CallbackContext context)
    {
        wheel = context.ReadValue<Vector2>();
    }

    public void OntriggerV(InputAction.CallbackContext context)
    {
       
    }

    public void OnselectL(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if(select<4)
            {
                select += 1;
            }
            else
            {
                select = 0;
            }
            Debug.Log(select);
        }
        
    }
    public void OnSelectR(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (select > 0)
            {
                select -= 1;
            }
            else
            {
                select = 4;
            }
            Debug.Log(select);
        }
    }

    void Update()
    {
       // const float Speed = 1f;
        transform.Translate(move * Speed * Time.deltaTime);
        //Debug.Log(wheel);
       // Debug.Log(move);
       // if(CK)
       // Gamepad.current.SetMotorSpeeds(0.5f, 1f);
    }
}
