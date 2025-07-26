using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour {
    public static Friend Instance { get; private set; }

    private bool isFullApple = false;
    [SerializeField] private SpeechBubbleController speechBubble;
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (isFullApple) {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public void OnMouseDown() {
        player player = FindObjectOfType<player>();
        Item selectedItem = player.GetSelectedItem();

        if (selectedItem == null) {
            Debug.Log("Chưa chọn vật phẩm");
            speechBubble.Show("Đói quá bạn ei!");
        } else if (selectedItem.itemType.ToString() == "Apple") {
            speechBubble.Show("Hehe! Ngon đó!!");
            player.GetInventory().RemoveItem(new Item { itemType = selectedItem.itemType, amount = 1 });
            player.GetInventory().AddItem(new Item { itemType = Item.ItemType.KeyBlack, amount = 1 });
            player.UnSelectItem();
            isFullApple = true;
        }
        else {
            speechBubble.Show("Này ăn được hả!");
            player.UnSelectItem();
        }
    }
}
