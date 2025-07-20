using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnClick : MonoBehaviour {
    private static Dictionary<string, bool> itemStateDict = new Dictionary<string, bool>();

    private string itemID;

    [SerializeField] private Item.ItemType itemType;
    [SerializeField] private int amount = 1;

    private void Start() {
        itemID = gameObject.name;
        if (itemStateDict.ContainsKey(itemID) && itemStateDict[itemID]) {
            gameObject.SetActive(false);
        }
    }

    public void Interact(player player) {
        if (itemStateDict.ContainsKey(itemID) && itemStateDict[itemID]) return;

        player.GetInventory().AddItem(new Item { itemType = itemType, amount = amount });

        itemStateDict[itemID] = true;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && itemType == Item.ItemType.Apple) {
            player player = collision.GetComponent<player>();
            if (player != null) {
                player.GetInventory().AddItem(new Item { itemType = Item.ItemType.Apple, amount = 1 });
                itemStateDict[itemID] = true;
                gameObject.SetActive(false);
            }
        }
    }
}
