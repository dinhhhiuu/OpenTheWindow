using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowWorld : MonoBehaviour {
    private string itemUniqueId;
    private WindowItem windowItem;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        animator = GetComponent<Animator>();
        if (!string.IsNullOrEmpty(itemUniqueId) && WindowSaveManager.Instance != null && WindowSaveManager.Instance.IsWindowCollected(itemUniqueId)) {
            animator.SetBool("OpenDoor", true);
        }
    }

    public static WindowWorld SpawnWindowWorld(Vector3 position, WindowItem windowItem, string itemUniqueId = "") {
        Transform prefab = WindowAssets.Instance.GetPrefabByType(windowItem.windowType);
        Transform transform = Instantiate(prefab, position, Quaternion.identity);
        WindowWorld windowWorld = transform.GetComponent<WindowWorld>();
        windowWorld.SetWindow(windowItem, itemUniqueId);
        return windowWorld;
    }

    public void SetWindow(WindowItem windowItem, string itemUniqueId = "") {
        this.windowItem = windowItem;
        this.itemUniqueId = itemUniqueId;
        spriteRenderer.sprite = windowItem.GetSprite();
    }

    public WindowItem GetWindow() {
        return windowItem;
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }

    public void Collect() {
        // Save state if player collect
        if (!string.IsNullOrEmpty(itemUniqueId) && WindowSaveManager.Instance != null) {
            WindowSaveManager.Instance.CollectedWindow(itemUniqueId);
        }
        DestroySelf();
    }

    private void OnMouseDown() {
        player player = FindObjectOfType<player>();
        Item selectedItem = player.GetSelectedItem();

        if (selectedItem == null) {
            Debug.Log("Chưa chọn vật phẩm");
        }

        if (selectedItem.itemType.ToString() == windowItem.windowType.ToString()) {
            Debug.Log("Đúng vật phẩm, mở cửa!");
            player.GetInventory().RemoveItem(new Item { itemType = selectedItem.itemType, amount = 1 });
            player.UnSelectItem();
            animator.SetBool("OpenDoor", true);
            if (!string.IsNullOrEmpty(itemUniqueId) && WindowSaveManager.Instance != null) {
                WindowSaveManager.Instance.CollectedWindow(itemUniqueId);
            }
        } else {
            Debug.Log("Sai vật phẩm!");
            player.UnSelectItem();
        }
    }
}
