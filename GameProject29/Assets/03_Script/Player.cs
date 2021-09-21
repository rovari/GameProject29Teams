using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public  float   Damage      = 0.0f;
    [SerializeField]
    private float   velocity    = 0.0f;

    public  bool    pow         = false;
    public  float   powIndex    = 1.0f;
    public  float   maxFriction = 0.0f;
    public  float   minFriction = 0.0f;
    public  float   moveSpeed   = 0.0f;
    public  float   maxSpeed    = 5.0f;
    public  float   atkInertia  = 2.5f;

    public  GameObject       model;
    public  List<GameObject> bullets;
    
    void CalculateFriction() {

        float e = 0.00001f;
        float d = Mathf.Clamp(Damage, e, 1.0f);
        float f = Mathf.Lerp(minFriction, maxFriction,1.0f - Damage);

        if (pow) f = Mathf.Pow(f, powIndex);

        f *= Time.deltaTime;
        
        if (Mathf.Abs(velocity) > 0) velocity += (velocity > 0) ? -f : f;
        velocity = (Mathf.Abs(velocity) < f + e) ? 0.0f : velocity;
    }

    void PlayerLost() {

        if (!model.GetComponent<Renderer>().isVisible) {

            this.GetComponent<Transform>().position 
                = new Vector3( 0.0f, this.GetComponent<Transform>().position.y + Mathf.Sin(Time.time * 2.0f) * 0.001f, this.GetComponent<Transform>().position.z);

            velocity = 0.0f;
        }
    }

    void PlayerMove() {
        velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed);
        this.GetComponent<Transform>().position += new Vector3(velocity * Time.deltaTime, Mathf.Sin(Time.time * 2.0f) * 0.001f, 0.0f);
    }

    void Update() {

        PlayerLost();
        CalculateFriction(); 
        
        //if (Input.GetKey(KeyCode.A))            velocity -= moveSpeed * Time.deltaTime;
        //if (Input.GetKey(KeyCode.D))            velocity += moveSpeed * Time.deltaTime;
        //if (Input.GetKey(KeyCode.LeftArrow))    velocity -= atkInertia;
        //if (Input.GetKey(KeyCode.RightArrow))   velocity += atkInertia;

        //if (Input.GetKey(KeyCode.Space)) {
        //    bullets[0].SetActive(true);
        //    bullets[0].GetComponent<Bullet>().StartWeponCalc();
        //}

        PlayerMove();
    }
}
