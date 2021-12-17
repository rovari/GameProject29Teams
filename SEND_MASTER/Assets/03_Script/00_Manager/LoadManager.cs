using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour {

    // Field
    static private LoadSystem loadSystem;
    
    // Property
    
    // Method
    static public void Load     (int sceneNumber = -1) {
        loadSystem.LoadScene(sceneNumber);
    }
    static public void ReLoad   () {
        loadSystem.ReLoadScene();
    }

    static public ref bool  GetIsPreLoad    () {
        return ref loadSystem.isPreLoad;
    }
    static public int       GetSequenceNum  () {
        return loadSystem.sequensNum;
    }

    // Unity
	private void Start() {
        loadSystem = GetComponent<LoadSystem>();
	}
}
