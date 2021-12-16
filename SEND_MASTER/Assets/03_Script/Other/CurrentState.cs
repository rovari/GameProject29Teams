using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentState : MonoBehaviour {

    // Field
    [SerializeField] Text stateText;
	
    // Property

    // Method

	// Signal

    // Unity
	private void Update() {
        stateText.text = StateManager.GetSetState.ToString();
	}
}
