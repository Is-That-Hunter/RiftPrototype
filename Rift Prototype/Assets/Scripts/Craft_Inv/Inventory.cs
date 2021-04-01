using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public Item item;
    public string inCraft;
    public InventoryItem(Item _item, string _inCraft = "")
    {
        item = _item;
        inCraft = _inCraft;
    }
}

//This is the Inventory Object
//A database of all Item objects currently carried by the player
//NOTE THERE CURRENTLY IS NO LIMIT TO SPACE --- NEEDS TO BE FIXED

public class Inventory
{
    //An event allowing for the inventory to be updated when changed
    public event EventHandler OnItemListChanged;

    //The inventory is kept as a list of custom Item objects (see Item.cs)
    private List<InventoryItem> itemList;

    //Creates a new inventory object
    //called in Global Game Object
    //NOTE ITEMS ARE ADDED FOR TESTING PURPOSES ONLY
    public Inventory()
    {
        itemList = new List<InventoryItem>();
    }

    //Adds Items to Inventory and updates the inventory organization UI
    public void AddItem(Item item)
    {
        itemList.Add(new InventoryItem(item));
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    //Removes Items used in the Craft system
    public void CraftRemoval(InventoryItem item1, InventoryItem item2, InventoryItem item3)
    {
        itemList.Remove(item1);

        itemList.Remove(item2);

        itemList.Remove(item3);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(InventoryItem item)
    {
        itemList.Remove(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    //Returns all Items in the Inventory
    public List<InventoryItem> GetItemList()
    {
        return itemList;
    }

    public bool itemInInventory(string itemName)
    {
        InventoryItem invItem = itemList.FirstOrDefault(i=>i.item.itemName == itemName);
        if(invItem != null)
            return true;
        return false;
    }
}
