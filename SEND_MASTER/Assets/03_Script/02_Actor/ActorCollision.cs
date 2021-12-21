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
    public  ref Actor   GetActor   () {
        return ref actor;
    }
    public  Type    GetActorType   () {
        return actor.GetActorType();
    }

    private void CalcActorHp    (ActorCollision hitCollision) {
        
        if(typeof(Bullet) == hitCollision.actor.GetActorType()) {
            actor.GetActorState().CalcDamage(hitCollision.damage, ((Bullet)hitCollision.actor).GetElement());
        }
        else actor.GetActorState().CalcDamage(hitCollision.damage, ELEMENT.NONE);
    }
    private void ActorEffect    (Actor hitActor) {
        
        if(typeof(Player) == actor.GetActorType()) {

            if (typeof(Enemy)   == hitActor.GetActorType()) {

                actor.effect.PlayHitStop(0.1f);
                actor.effect.PlayEffect (EFFECT.CA, damageEffect);
                actor.effect.PlayEffect (EFFECT.EXPLOSION, damageEffect);
            }
            if (typeof(Bullet)  == hitActor.GetActorType()) {
                
                actor.effect.PlayHitStop(0.1f);
                actor.effect.PlayEffect(EFFECT.CA, damageEffect);
                actor.effect.PlayEffect(EFFECT.EXPLOSION, damageEffect);
            }
            if (typeof(Item)    == hitActor.GetActorType()) {
                
                //((Item)hitActor)
            }
            
            return;
        }
        
        if(typeof(Enemy) == actor.GetActorType()) {

            if (typeof(Player)  == hitActor.GetActorType()) {

            }
            if (typeof(Bullet)  == hitActor.GetActorType()) {
                actor.effect.PlayHitStop(0.1f);
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

        Debug.Log("HiT " + actor.name + " -> " + other.GetComponent<ActorCollision>().GetActor().gameObject.name);

        CalcActorHp(hitActorCollision);
        ActorEffect(hitActorCollision.GetActor());
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
