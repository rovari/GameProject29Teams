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
            AudioManager.PlayOneShot(SOUNDTYPE.GAME, "Hit_gse");
        }
        else actor.GetActorState().CalcDamage(hitCollision.damage, ELEMENT.NONE);
    }
    private void ActorEffect    (Actor hitActor) {
        
        if(typeof(Player) == actor.GetActorType()) {

            if (typeof(Enemy)   == hitActor.GetActorType()) {

                actor.effect.PlayHitStop(0.1f);
                actor.effect.PlayEffect (EFFECT.CA, damageEffect);
                actor.effect.PlayEffect (EFFECT.EXPLOSION, damageEffect);

                actor.GetSetHitPos = new Vector2(hitActor.GetSetTransform.position.x, hitActor.GetSetTransform.position.y);

                AudioManager.PlayOneShot(SOUNDTYPE.GAME, "Damage_gse");

                IEnumerator cor = DamegeRim(0.5f, 0.05f);
                StartCoroutine(cor);
            }
            if (typeof(Bullet)  == hitActor.GetActorType()) {
                
                actor.effect.PlayHitStop(0.1f);
                actor.effect.PlayEffect(EFFECT.CA, damageEffect);
                actor.effect.PlayEffect(EFFECT.EXPLOSION, damageEffect);

                actor.GetSetHitPos = new Vector2(hitActor.GetSetTransform.position.x, hitActor.GetSetTransform.position.y);

                AudioManager.PlayOneShot(SOUNDTYPE.GAME, "Damage_gse");

                IEnumerator cor = DamegeRim(0.5f, 0.05f);
                StartCoroutine(cor);
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

                actor.effect.PlayHitStop(0.5f);
                actor.GetSetHitPos = new Vector2(hitActor.GetSetTransform.position.x, hitActor.GetSetTransform.position.y);

                IEnumerator cor = DamegeRim(0.5f, 0.05f);
                StartCoroutine(cor);
            }
            return;
        }
    }
    private IEnumerator DamegeRim(float time, float interval) { 

        float   count   = time / interval;
        bool    sw      = true;

        while (count > 0) {

            foreach (var s in actor.surfaceList) {
                s.SetRimEnable(sw, Color.red);
            }

            count -= 1.0f;
            sw = !sw;

            yield return new WaitForSeconds(interval);
        }

        foreach (var s in actor.surfaceList) {
            s.SetRimEnable(false, Color.white);
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

        if (!other.gameObject.TryGetComponent(out hitActorCollision)) {
            Debug.Log("NC"); return;
        }

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
