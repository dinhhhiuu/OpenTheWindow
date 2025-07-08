using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour {
    private string itemUniqueId;
    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();

        // Set layer for text
        foreach (Transform child in transform) {
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null) {
                childRenderer.sortingLayerID = spriteRenderer.sortingLayerID;
                childRenderer.sortingOrder = spriteRenderer.sortingOrder + 1;
            }
        }
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item, string itemUniqueId = "") {
        Transform prefab = ItemAssets.Instance.GetPrefabByType(item.itemType);
        Transform transform = Instantiate(prefab, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item, itemUniqueId);
        return itemWorld;
    }

    public void SetItem(Item item, string itemUniqueId = "") {
        this.item = item;
        this.itemUniqueId = itemUniqueId;
        spriteRenderer.sprite = item.GetSprite();
        if (item.amount > 1) {
            textMeshPro.SetText(item.amount.ToString());
        } else {
            textMeshPro.SetText("");
        }
    }

    public Item GetItem() {
        return item;
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }

    public void Collect() {
        // Save state if player collect
        if (!string.IsNullOrEmpty(itemUniqueId) && ItemSaveManager.Instance != null) {
            ItemSaveManager.Instance.CollectItem(itemUniqueId);
        }
        DestroySelf();
    }
}
