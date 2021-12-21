using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCollision : ActorData {

    // Field
    [SerializeField] private float      damage;
    [SerializeField] private bool       isUseParticle;
    [SerializeField] private GameObject particle;
	[SerializeField] private EffectData damageEffect;
    
    // Property

    // Method
    public  Type GetActorType   () {
        return actor.GetActorType();
    }
    private void CalcActorHp    (ActorCollision hitCollision) {
        
        if(typeof(Bullet) == hitCollision.actor.GetActorType()) {
            actor.GetActorState().CalcDamage(hitCollision.damage, ((Bullet)hitCollision.actor).GetElement());
        }
        else actor.GetActorState().CalcDamage(hitCollision.damage, ELEMENT.NONE);
    }
    private void ActorEffect    (Type hitActorType) {
        
        if(typeof(Player) == actor.GetActorType()) {

            if (typeof(Enemy)   == hitActorType) {
                actor.effect.PlayEffect(EFFECT.CA, damageEffect);
                actor.effect.PlayEffect(EFFECT.EXPLOSION, damageEffect);

            }
            if (typeof(Bullet)  == hitActorType) {

            }
            if (typeof(Item)    == hitActorType) {

            }
            
            return;
        }
        
        if(typeof(Enemy) == actor.GetActorType()) {

            if (typeof(Player)  == hitActorType) {

            }
            if (typeof(Bullet)  == hitActorType) {

            }
            return;
        }
    }

	// Signal

    // Unity
	private void Start          () {

        particle.SetActive(isUseParticle);
	}
    private void OnTriggerEnter (Collider other) {

        if (StateManager.GetSetState != STATE.GAME) return;

        ActorCollision hitActorCollision;

        if (!other.gameObject.TryGetComponent(out hitActorCollision)) return;

        Debug.Log("HiT " + actor.name + " -> " + other.gameObject.name);

        CalcActorHp(hitActorCollision);
        ActorEffect(hitActorCollision.GetActorType());
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
