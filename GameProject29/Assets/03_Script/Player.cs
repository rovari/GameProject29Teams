using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public  float   damage      = 0.0f;
    [SerializeField]
    private float   velocity    = 0.0f;

    public  bool    pow         = false;
    public  float   powIndex    = 1.0f;
    public  float   maxFriction = 1.0f;
    public  float   minFriction = 0.0f;
    public  float   moveSpeed   = 5.0f;
    public  float   maxSpeed    = 5.0f;

    public  GameObject          model;
    public  List<GameObject>    bullets;
    private Vector3             stickPos;
    
    public void OnMove(InputAction.CallbackContext context) {
        stickPos = context.ReadValue<Vector2>();
    }
    
    void CalculateFriction() {

        float e = 0.00001f;
        float d = Mathf.Clamp(damage, e, 1.0f);
        float f = Mathf.Lerp(minFriction, maxFriction,1.0f - damage);

        if (pow) f = Mathf.Pow(f, powIndex);

        f *= Time.deltaTime;
        
        if (Mathf.Abs(velocity) > 0) velocity += (velocity > 0) ? -f : f;
        velocity = (Mathf.Abs(velocity) < f + e) ? 0.0f : velocity;
    }

    void PlayerLost() {

        if (!model.GetComponent<Renderer>().isVisible) {

            this.GetComponent<Transform>().position 
                = new Vector3( 0.0f, transform.position.y + Mathf.Sin(Time.time * 2.0f) * 0.001f, transform.position.z);

            velocity = 0.0f;
        }
    }

    void PlayerMove() {
        velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed);
        transform.position += new Vector3(velocity * Time.deltaTime, Mathf.Sin(Time.time * 2.0f) * 0.001f, 0.0f);
    }

    void Update() {

        PlayerLost();
        CalculateFriction();

        float st = (stickPos.x + 1.0f) * 0.5f;
    
        velocity += Mathf.Lerp(-moveSpeed, moveSpeed,st) * Time.deltaTime;

        //if (Input.GetKey(KeyCode.Space)) {
        //    bullets[0].SetActive(true);
        //    bullets[0].GetComponent<Bullet>().StartWeponCalc();
        //}

        PlayerMove();
    }
}
