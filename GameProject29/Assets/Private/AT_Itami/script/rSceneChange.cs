using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class rSceneChange : MonoBehaviour
{
    float totalTime = 60;
    int retime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        retime = (int)totalTime;
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    SceneManager.LoadScene("result2");
        //}
    }
}
