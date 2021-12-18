using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : ActorData {

    // Field
    [SerializeField] private FireSystem  fireSystem;

    private bool        isSyncLunch;
    private Vector3     aimTarget;

    // Property

    // Method
    private void Lunch              () {
        if (isSyncLunch) {

            isSyncLunch = false;
            if(fireSystem.GetTarget()) fireSystem.Lunch();
        }
    }
	private void SyncLunch          () {
        isSyncLunch = true;
    }

    // Signal

    // Unity
	private void Start () {

        fireSystem.SetOwner(actor.GetSetTransform);

        InputManager.GetGAMEActions().Fire.performed    += _ => SyncLunch();
        InputManager.GetGAMEActions().Index.started     += _ => fireSystem.AddWeaaponIndex();
        InputManager.GetGAMEActions().Aim.started       += _ => fireSystem.AddTargetIndex ();
    }

    // Dependent Update by State
    protected override void GameUpdate   () {
        Lunch();
        
	}
    protected override void MenuUpdate   () { 

	}
    protected override void LoadUpdate   () { 

	}
    protected override void EventUpdate  () { 

	}
}
