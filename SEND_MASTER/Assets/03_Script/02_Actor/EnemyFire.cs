using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : ActorData {

    // Field
    private FireSystem fireSystem;

    // Property

    // Method
    private IEnumerator RefreshList() {

        while (true) {
            fireSystem.RefreshList();
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Signal
    public  void LunchSignal  (int index) {
        fireSystem.weaponIndex = index;
        fireSystem.Lunch();
    }

    // Unity
	private void Start() {

	}

	// Dependent Update by State
    protected override void GameUpdate   () { 

	}
    protected override void MenuUpdate   () { 

	}
    protected override void LoadUpdate   () { 

	}
    protected override void EventUpdate  () { 

	}
}
