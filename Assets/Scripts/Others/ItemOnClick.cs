using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnClick : MonoBehaviour {
    private static Dictionary<string, bool> itemStateDict = new Dictionary<string, bool>();

    [SerializeField] private player player;
    private string itemID;

    private void Start() {
        itemID = gameObject.name;
        if (itemStateDict.ContainsKey(itemID) && itemStateDict[itemID]) {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDown() {
        if (itemStateDict.ContainsKey(itemID) && itemStateDict[itemID]) return;

        string tag = gameObject.tag;

        if (tag == "Sword") {
            player.GetInventory().AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        } else if (tag == "Budget") {
            player.GetInventory().AddItem(new Item { itemType = Item.ItemType.Coin, amount = 5 });
        }

        itemStateDict[itemID] = true;
        gameObject.SetActive(false);
    }
}
