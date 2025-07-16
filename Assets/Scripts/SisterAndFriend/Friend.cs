using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour {
    [SerializeField] public SpeechBubbleController speechBubble;

    private static bool isFullApple = false;

    private void Update() {
        if (isFullApple) {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnMouseDown() {
        player player = FindObjectOfType<player>();
        Item selectedItem = player.GetSelectedItem();

        if (selectedItem == null) {
            speechBubble.Show("Đói quá bạn ei!");
        } else if (selectedItem.itemType.ToString() != "Apple") {
            speechBubble.Show("Này ăn được hả!");
            player.UnSelectItem();
        } else if (selectedItem.itemType.ToString() == "Apple") {
            speechBubble.Show("Hehe! Ngon đó!!");
            player.GetInventory().RemoveItem(new Item { itemType = selectedItem.itemType, amount = 1 });
            player.GetInventory().AddItem(new Item { itemType = Item.ItemType.KeyBlack, amount = 1 });
            player.UnSelectItem();
            isFullApple = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            speechBubble.Show("Kiếm gì ăn đi rồi trả chìa khóa cho :)");
        }
    }
}
