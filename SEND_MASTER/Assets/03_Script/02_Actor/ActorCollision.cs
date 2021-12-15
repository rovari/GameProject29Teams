using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCollision : ActorData {

    // Field
    [SerializeField] private float      damage;
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
    private void ActorEffect    (Type actorType) {
        
        if(typeof(Player) == actor.GetActorType()) {

            if (typeof(Enemy)   == actorType) {

            }
            if (typeof(Bullet)  == actorType) {

            }
            if (typeof(Item)    == actorType) {

            }
            
            return;
        }
        
        if(typeof(Enemy) == actor.GetActorType()) {

            if (typeof(Player)  == actorType) {

            }
            if (typeof(Bullet)  == actorType) {

            }
            if (typeof(Item)    == actorType) {

            }

            return;
        }

        if(typeof(Bullet) == actor.GetActorType()) {

            if (typeof(Player)  == actorType) {

            }
            if (typeof(Enemy )  == actorType) {

            }
            if (typeof(Item)    == actorType) {

            }

            return;
        }
    }

	// Signal

    // Unity
	private void Start          () {

	}
    private void OnTriggerEnter (Collider other) {

        ActorCollision actorCollision;

        if (!other.gameObject.TryGetComponent<ActorCollision>(out actorCollision)) return;

        CalcActorHp(actorCollision);
        ActorEffect(actorCollision.GetActorType());

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
