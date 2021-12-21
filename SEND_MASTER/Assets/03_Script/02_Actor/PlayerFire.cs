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
            fireSystem.Lunch();
        }
    }
	private void SyncLunch          () {
        isSyncLunch = true;
    }

    private void AddWeaponIndex     () {

        if (StateManager.GetSetState != STATE.GAME) return;

        AudioManager.PlayOneShot(SOUNDTYPE.GAME, "Weapon_Change_gse");
        fireSystem.AddWeaponIndex();
    }
    private void AddTargetIndex     () {

        if (StateManager.GetSetState != STATE.GAME) return;
        fireSystem.AddTargetIndex();
    }
    
    private void IsEnemyDownUpdate() {
        if (StateManager.GetSetEnemyDown) {
            StateManager.GetSetEnemyDown = false;
            fireSystem.RefreshList();
        }
    }
    
    // Unity
	private void Start () {

        fireSystem.SetOwner(actor.GetSetTransform);

        InputManager.GetGAMEActions().Fire.performed    += _ => SyncLunch();
        InputManager.GetGAMEActions().Index.started     += _ => AddWeaponIndex();
        InputManager.GetGAMEActions().Aim.started       += _ => AddTargetIndex();
    }

    // Dependent Update by State
    protected override void GameUpdate   () {
        IsEnemyDownUpdate();
        Lunch();
	}
    protected override void MenuUpdate   () { 

	}
    protected override void LoadUpdate   () { 

	}
    protected override void EventUpdate  () { 

	}
}
