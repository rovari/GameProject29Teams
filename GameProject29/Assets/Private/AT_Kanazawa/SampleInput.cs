using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleInput : MonoBehaviour
{

    TestAction actions;

    bool check;

    private void Awake()
    {
        actions = new TestAction();

        actions.Player.Push.started += context => { check = true; };
        actions.Player.Push.canceled += context => { check = false; };

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var stickcontrol = actions.TestInput.stick.ReadValue<Vector2>();

        if (check)
        {
            SceneManager.LoadScene("NextTestScene");
        }
        // Debug.Log(stickcontrol);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
