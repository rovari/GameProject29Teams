using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysSystem : MonoBehaviour {

    // Field
    [SerializeField] private List<GameObject> enemyList;
    private List<GameObject> currentEnemyList;

    // Property

    // Method

	// Signal
    public void PopMarker        (List<int> indexes) {

        foreach (var i in indexes) {

            if (i > enemyList.Count - 1) continue;
            currentEnemyList.Add(Instantiate(enemyList[i]));
        }
    }
    public void AllDestroySignal () {
        foreach (var e in currentEnemyList) Destroy(e.gameObject);
    }

    // Unity
	private void Start() {
        currentEnemyList = new List<GameObject>();
	}
}
