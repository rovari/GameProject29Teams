using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleInput : MonoBehaviour
{

    GameInput actions;

    private void Awake()
    {
        actions = new GameInput();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var stickcontrol = actions.TestInput.stick.ReadValue<Vector2>();
        Debug.Log(stickcontrol);
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
