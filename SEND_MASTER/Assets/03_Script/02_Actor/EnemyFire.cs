using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : ActorData {

    // Field
    [SerializeField] private FireSystem fireSystem;

    // Property

    // Method

    // Signal
    public  void LunchMarker  (int index) {
        fireSystem.SetWeaponIndex(index);
        fireSystem.Lunch();
    }
    
    // Unity
	private void Start() {
        fireSystem.SetOwner(actor.GetSetTransform);
	}
    
	// Dependent Update by State
    protected override void GameUpdate   () {
        fireSystem.RefreshList();
	}
    protected override void MenuUpdate   () { 

	}
    protected override void LoadUpdate   () { 

	}
    protected override void EventUpdate  () { 

	}
}
