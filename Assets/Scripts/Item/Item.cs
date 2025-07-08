using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item {
    public enum ItemType {
        KeyBlue,
        KeyWhite,
        KeyRed,
        KeyYellow,
        KeyBlack,
        Coin,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() {
        return ItemAssets.Instance.GetSpriteByType(itemType);
    }

    public bool IsStackable() {
        switch (itemType) {
            default:
            case ItemType.Coin:
                return true;
            case ItemType.KeyWhite:
            case ItemType.KeyBlue:
            case ItemType.KeyRed:
            case ItemType.KeyYellow:
            case ItemType.KeyBlack:
                return false;
        }
    }
}
