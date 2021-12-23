using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Actor {

    // Field
    [SerializeField] private float      boxBitween;
    [SerializeField] private Vector3    boxLocalPos;
    [SerializeField] private GameObject LifeBoxObject;
    [SerializeField] private FireSystem fireSystem;

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

    public  ref FireSystem  GetFireSystem   ()  {
        return ref fireSystem;
    }

    private void        CreateBox   () {

        LifeBoxList = new List<GameObject>();

        for(int i = 0; i < GetActorState().life; ++i) {
            
            GameObject box = Instantiate(LifeBoxObject);

            box.transform.position = 
                GetSetTransform.position + new Vector3(boxLocalPos.x, boxLocalPos.y + boxBitween * i, boxLocalPos.z);

            box.transform.parent = GetSetTransform;
            box.name = "LifeBox_s" + (i + 1).ToString();

            LifeBoxList.Add(box);
        }
    }
    private void        UpdateBox   () {

        for (int i = 0; i < LifeBoxList.Count; ++i) {

            if (i < GetActorState().life) {
                LifeBoxList[i].SetActive(true);
            }
            else {
                LifeBoxList[i].SetActive(false);
            }
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
	private new void Start  () {

        base.Start();

        CreateBox();
	}

    private new void Update () {
        
        base.Update();

        GetActorState   ().isPlayer = true;
        UpdateBox       ();
    }
}