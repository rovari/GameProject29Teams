using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    private State st;
   
    void Start() {
        st = gameObject.GetComponent<State>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.L)) st.StartLoadScenes("Game");
    }
}
