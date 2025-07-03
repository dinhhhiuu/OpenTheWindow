using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public Item item;
    public string itemUniqueId;

    private void Awake() {
        // Check item if player collect it
        if (ItemSaveManager.Instance != null && ItemSaveManager.Instance.IsItemCollected(itemUniqueId)) {
            Destroy(gameObject);
            return;
        }

        ItemWorld.SpawnItemWorld(transform.position, item, itemUniqueId);
        Destroy(gameObject);
    }
}
