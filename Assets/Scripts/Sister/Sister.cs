using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister : MonoBehaviour {
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown() {
        player player = FindObjectOfType<player>();
        Item selectedItem = player.GetSelectedItem();

        if (selectedItem == null) {
            Debug.Log("Chưa chọn vật phẩm");
        }

        if (selectedItem.itemType.ToString() == "Coin" && selectedItem.amount == 23) {
            Debug.Log("Đủ coin");
            player.GetInventory().RemoveItem(new Item { itemType = selectedItem.itemType, amount = 23 });
            player.UnSelectItem();
            player.GetInventory().AddItem(new Item { itemType = Item.ItemType.KeyBlue, amount = 1 });
            animator.SetBool("isFullCoin", true);
        } else {
            Debug.Log("Sai vật phẩm");
            player.UnSelectItem();
        }
    }
}
