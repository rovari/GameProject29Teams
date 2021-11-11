using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour {
    
    // Show  Field ================================================
    public static MainSystem singleton;

    // Unity Method ===============================================
    private void Awake  () {

        CreateManager();
    }
    private void Start  () {
        
        //LoadScene.Load(0);
    }

    // User  Method ===============================================
    private void CreateManager() {

        if (singleton == null) {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }

        else {
            Destroy(gameObject);
        }
    }
}
