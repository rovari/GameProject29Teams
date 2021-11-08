using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Facade {

    // Hide  Field ================================================
    public enum ITEMTYPE {
        None,
        Spanner,
        DashBord,
        TurboCharger,
    }

    // Show  Field ================================================
    public ITEMTYPE itemType;


    // Unity Method ===============================================
    private void Start() {
        itemType = ITEMTYPE.None;
    }

    // User  Method ===============================================
    private void OnTriggerEnter(Collider other) {

        switch (itemType) {

            case ITEMTYPE.None:
                break;
            case ITEMTYPE.Spanner:
                break;
            case ITEMTYPE.DashBord:
                break;
            case ITEMTYPE.TurboCharger:
                break;
            default:
                break;
        }
    }
}
