using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();

        AddItem(new Item {itemType = Item.ItemType.Key1, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.Key2, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.Key3, amount = 1});
            // AddItem(new Item {itemType = Item.ItemType.Key3, amount = 1});
            // AddItem(new Item {itemType = Item.ItemType.Key3, amount = 1});
            // AddItem(new Item {itemType = Item.ItemType.Key3, amount = 1});
    }

    public void AddItem(Item item) {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> getItemList() {
        return itemList;
    } 
}
