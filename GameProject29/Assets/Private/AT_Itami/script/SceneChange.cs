using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChange : MonoBehaviour
{
    float totalTime = 60;
    int retime;

    public void On(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("result");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        retime = (int)totalTime;

    }
}
