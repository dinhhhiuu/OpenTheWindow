using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {
    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public Transform[] itemPrefabs;
    public Sprite[] itemSprites;

    public Transform GetPrefabByType(Item.ItemType itemType) {
        int idx = (int)itemType;
        if (idx >= 0 && idx < itemPrefabs.Length) {
            return itemPrefabs[idx];
        }
        return null;
    }

    public Sprite GetSpriteByType(Item.ItemType itemType) {
        int idx = (int)itemType;
        if (idx >= 0 && idx < itemSprites.Length) {
            return itemSprites[idx];
        }
        return null;
    }
}
