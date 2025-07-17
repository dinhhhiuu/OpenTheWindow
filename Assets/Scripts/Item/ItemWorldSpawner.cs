using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour {
    public Item item;
    private string itemUniqueId;

    private void Awake() {
        // If player collected this item, don't spawn
        itemUniqueId = gameObject.name;
        if (ItemSaveManager.Instance != null && ItemSaveManager.Instance.IsItemCollected(itemUniqueId)) {
            Destroy(gameObject);
            return;
        }

        // Spawn
        ItemWorld.SpawnItemWorld(transform.position, item, itemUniqueId);
        Destroy(gameObject);
    }
}
