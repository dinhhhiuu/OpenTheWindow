using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item {
    public enum ItemType {
        Key1,
        Key2,
        Key3
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.Key1: return ItemAssets.Instance.Key1;
            case ItemType.Key2: return ItemAssets.Instance.Key2;
            case ItemType.Key3: return ItemAssets.Instance.Key3;
        }
    }
}
