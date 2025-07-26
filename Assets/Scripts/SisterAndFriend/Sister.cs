using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister : MonoBehaviour {
    public static Sister Instance { get; private set; }
   
    private bool isFullCoin = false;
    [SerializeField] private SpeechBubbleController speechBubble;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
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
            Debug.Log("Chưa chọn vật phẩm");
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
            Debug.Log("Chưa đủ coin");
            speechBubble.Show("Keo thế! Kiếm thêm " + (23 - selectedItem.amount) + " đồng xu nữa đi!");
            player.UnSelectItem();
        } else {
            Debug.Log("Sai vật phẩm");
            speechBubble.Show("Đồng xu đâuuuu!!!");
            player.UnSelectItem();
        }
    }
}
