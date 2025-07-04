using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item {
    public enum ItemType {
        KeyBlue,
        KeyWhite,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.KeyBlue: return ItemAssets.Instance.KeyBlueSprite;
            case ItemType.KeyWhite: return ItemAssets.Instance.KeyWhiteSprite;
        }
    }

    public bool IsStackable() {
        switch (itemType) {
            default:
            case ItemType.KeyBlue:
                return true;
            case ItemType.KeyWhite:
                return false;
        }
    }
}
