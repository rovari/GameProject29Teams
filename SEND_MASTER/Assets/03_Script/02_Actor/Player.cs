using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Actor {

    // Field
    [SerializeField] private GameObject LifeBoxObject;
    [SerializeField] private Vector3    boxPosition;
    [SerializeField] private float      boxBitween;

    private bool                isHoldItem;
    private bool                isEffect;
    private List<GameObject>    LifeBoxList;
    private ItemData            itemData;
    
    // Property

    // Method
    public  void        SetItem     (ItemData setItem) {

         isHoldItem  = true;
         itemData    = setItem;
    }
    public  void        UseItem     () {

        if (!isHoldItem || isEffect) return;

        switch (itemData.item) { 
            case ITEM.TURBO:
                StartCoroutine("Turbo");
                break;

            case ITEM.SPANNER:
                StartCoroutine("Spanner");
                break;

            case ITEM.INVNCIBLE:
                StartCoroutine("Invncible");
                break;

            case ITEM.LIFEBOX:
                StartCoroutine("LifeBox");
                break;

            default: break;
        }
    }

    private void        CreateBox   () { 

        for(int i = 0; i <= GetActorState().life; ++i) {
            
            LifeBoxList.Add(Instantiate(LifeBoxObject));

            Vector3 boxPos = new Vector3(boxPosition.x, boxPosition.y, boxPosition.z + (boxBitween * (i + 1)));

            LifeBoxList[i].transform.position = boxPos;
        }
    }

    // Item Calc
    private IEnumerator Turbo       () {
        
        isEffect    = true;

        GetActorState().isTurbo = true;
        yield return null;
        
        isHoldItem  = false;
        isEffect    = false;
    }
    private IEnumerator Spanner     () {

        isEffect    = true;

        GetActorState().hp += itemData.power;
        yield return null;
        
        isHoldItem  = false;
        isEffect    = false;
    }
    private IEnumerator Invncible   () {
        
        isEffect    = true;

        GetActorState().isInvincible = true;

        yield return new WaitForSeconds(itemData.power);

        GetActorState().isInvincible = false;
        
        isHoldItem  = false;
        isEffect    = false;
    }

    // Unity
	private void Start() {

	}
}