using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour {
    public Item item;
    public string itemUniqueId;

    private void Awake() {
        // If player collected this item, don't spawn
        if (ItemSaveManager.Instance != null && ItemSaveManager.Instance.IsItemCollected(itemUniqueId)) {
            Destroy(gameObject);
            return;
        }

        // Spawn
        ItemWorld.SpawnItemWorld(transform.position, item, itemUniqueId);
        Destroy(gameObject);
    }
}
