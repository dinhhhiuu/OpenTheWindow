using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory {
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();
        AddItem(new Item {itemType = Item.ItemType.KeyBlue, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.KeyWhite, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.KeyBlue, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.KeyBlue, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.KeyBlue, amount = 1});
    }

    public void AddItem(Item item) {
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (Item inventory in itemList) {
                if (inventory.itemType == item.itemType) {
                    inventory.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item) {
        if (item.IsStackable()) {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                itemList.Remove(item);
            }
        } else {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList() {
        return itemList;
    }
}
