using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public float laserSpeed;
    GameObject scoreObject;

    void Start()
    {
        scoreObject = GameObject.Find("GameObject");
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            FindObjectOfType<ScoreScript>().AddScore();

            Destroy(this.gameObject);
        }
    }


    void Update()
    {
        Vector3 position = transform.position;
        position.y += laserSpeed * Time.deltaTime;
        transform.position = position;

        if (transform.position.y > 7.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
