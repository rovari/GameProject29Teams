using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour {

    // Field
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject menuUI;

    // Property

    // Method
    private void UISwitcher() {

        if (StateManager.GetSetState == STATE.GAME) { 
             gameUI.SetActive(true);
        }
        else gameUI.SetActive(false);

        if(StateManager.GetSetState == STATE.MENU)  {
             menuUI.SetActive(true);
        }
        else menuUI.SetActive(false);



    }

	// Signal

    // Unity
	private void Start() {

	}

    private void Update() {
        UISwitcher();
    }
}
