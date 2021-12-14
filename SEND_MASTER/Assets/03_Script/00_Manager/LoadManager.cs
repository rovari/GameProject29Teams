using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour {

    // Field
    static private LoadSystem loadSystem;
    
    // Property
    
    // Method
    static public void Load (int sceneNumber = -1) {
        loadSystem.LoadScene(sceneNumber);
    }
    
    // Unity
	private void Start() {

	}
}
