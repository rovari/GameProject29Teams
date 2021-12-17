using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysSystem : MonoBehaviour {

    // Field
    [SerializeField] private List<GameObject> enemyList; 

    // Property

    // Method

	// Signal
    public void PopMarker        (List<int> indexes) {
        foreach(var i in indexes) GameObject.Instantiate(enemyList[i]);
    }
    public void AllDestroySignal () {
        foreach (var e in enemyList) Destroy(e);
    }

    // Unity
	private void Start() {
	}
}
