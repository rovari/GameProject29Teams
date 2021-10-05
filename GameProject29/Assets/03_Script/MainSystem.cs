using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour {
    
    // Show  Property =============================================
    public static MainSystem singleton;

    // Unity Method ===============================================
    private void Awake  () {

        CreateManager();
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
