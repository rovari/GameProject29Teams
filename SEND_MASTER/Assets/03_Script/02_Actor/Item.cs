using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM {
    NONE,
    TURBO, 
    SPANNER,
    INVNCIBLE,
    LIFEBOX,
    MAX
}

[Serializable]
public struct ItemData {
    
    public  ITEM    item;
    public  float   power;
}

public class Item : Actor {

    // Field
    [SerializeField] private ItemData itemData;

    // Property

    // Method
    public ItemData GetItemData() {
        return itemData;
    }
    
	// Signal

    // Unity
	private void Start() {

	}
}
