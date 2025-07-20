using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister : MonoBehaviour {
    private Animator animator;
    [SerializeField] public SpeechBubbleController speechBubble;

    private static bool isFullCoin = false;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (isFullCoin) {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void OnMouseDown() {
        player player = FindObjectOfType<player>();
        Item selectedItem = player.GetSelectedItem();

        if (selectedItem == null) {
            speechBubble.Show("Đưa em 23 đồng xu thì trả chìa khóa cho!!!");
        }

        if (selectedItem.itemType.ToString() == "Coin" && selectedItem.amount == 23) {
            Debug.Log("Đủ coin");
            player.GetInventory().RemoveItem(new Item { itemType = selectedItem.itemType, amount = 23 });
            player.UnSelectItem();
            player.GetInventory().AddItem(new Item { itemType = Item.ItemType.KeyBlue, amount = 1 });
            isFullCoin = true;
            speechBubble.Show("Đúng là anh trai của em!!");
        } else if (selectedItem.itemType.ToString() == "Coin" && selectedItem.amount != 23) {
            speechBubble.Show("Keo thế kiếm thêm" + (23 - selectedItem.amount) + " đồng xu nữa đi!");
            player.UnSelectItem();
        } else {
            Debug.Log("Sai vật phẩm");
            speechBubble.Show("Đưa em 23 đồng xu thì trả chìa khóa cho!!!");
            player.UnSelectItem();
        }
    }
}
