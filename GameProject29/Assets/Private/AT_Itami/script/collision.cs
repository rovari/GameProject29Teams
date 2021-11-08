using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    GameObject ScoreObject;

    // Start is called before the first frame update
    void Start()
    {
        ScoreObject = GameObject.Find("GameObject");
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<ScoreScript>().AddScoreE();

        }

        if (collision.gameObject.tag == "WeakEnemy")
        {
            FindObjectOfType<ScoreScript>().AddScoreWE();

        }

        if (collision.gameObject.tag == "MBossEnemy")
        {
            FindObjectOfType<ScoreScript>().AddScoreMBE();

        }

        if (collision.gameObject.tag == "BossEnemy")
        {
            FindObjectOfType<ScoreScript>().AddScoreBE();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
