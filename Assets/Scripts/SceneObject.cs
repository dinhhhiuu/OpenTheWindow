using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject : MonoBehaviour {
    public Item.ItemType requiredItemType;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown() {
        player player = FindObjectOfType<player>();
        Item selectedItem = player.GetSelectedItem();

        if (selectedItem == null) {
            Debug.Log("Chưa chọn vật phẩm");
            return;
        }

        if (selectedItem.itemType == requiredItemType) {
            Debug.Log("Đúng vật phẩm, mở cửa!");
            player.GetInventory().RemoveItem(new Item { itemType = requiredItemType, amount = 1 });
            player.UnSelectItem();
            animator.SetBool("OpenDoor", true);
        } else {
            Debug.Log("Sai vật phẩm!");
            player.UnSelectItem();
        }
    }
}