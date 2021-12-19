using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : ActorData {
    
    // Field
    [SerializeField] private Transform  aimTarget;

    [SerializeField] private Text       weaponText;

    [SerializeField] private Slider     weaponSlider;
    [SerializeField] private Slider     stabilitySlider;
    [SerializeField] private Slider     progressSlider;
    [SerializeField] private Slider     rewardSlider;
    
    // Property

    // Method
    void SetSliderValue() {
        
        weaponText.text         = ((Player)actor).GetFireSystem().GetWeapon().gameObject.name;
        weaponSlider.value      = ((Player)actor).GetFireSystem().GetWeapon().GetRecastNormalize();

        if (StateManager.GetTimeLine().duration > 0.0 && StateManager.GetTimeLine().time > 0.0) {
            progressSlider.value  = (float)(1.0 / StateManager.GetTimeLine().duration * StateManager.GetTimeLine().time);
        }
        else progressSlider.value = 0.0f;

        rewardSlider.value = 1.0f / 100000.0f * StateManager.GetSetScore;

        if (actor.GetActorState().hp > 0.0f) {
            stabilitySlider.value = 1.0f / actor.GetActorState().defHp * actor.GetActorState().hp;
        }
        else stabilitySlider.value = 0.0f;
    }

	// Signal

    // Unity
	private void Start() {
        
	}

	// Dependent Update by State
    protected override void GameUpdate   () {
        SetSliderValue();
	}
    protected override void MenuUpdate   () { 

	}
    protected override void LoadUpdate   () { 

	}
    protected override void EventUpdate  () { 

	}
}
