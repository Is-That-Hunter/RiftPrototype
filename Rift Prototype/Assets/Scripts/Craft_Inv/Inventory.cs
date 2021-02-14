using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the Inventory Object
//A database of all Item objects currently carried by the player
//NOTE THERE CURRENTLY IS NO LIMIT TO SPACE --- NEEDS TO BE FIXED

public class Inventory
{
    //An event allowing for the inventory to be updated when changed
    public event EventHandler OnItemListChanged;

    //The inventory is kept as a list of custom Item objects (see Item.cs)
    private List<Item> itemList;

    //Creates a new inventory object
    //called in Global Game Object
    //NOTE ITEMS ARE ADDED FOR TESTING PURPOSES ONLY
    public Inventory()
    {
        itemList = new List<Item>();

        //Debug.Log("Inventory");

        AddItem(new Item { name = Item.ItemName.SmallMetal, size = Item.ItemSize.Small, type = Item.ItemType.Sharp, material = Item.ItemMaterial.Metal });

        AddItem(new Item { name = Item.ItemName.Battery, size = Item.ItemSize.Small, type = Item.ItemType.Electric, material = Item.ItemMaterial.Metal });

        AddItem(new Item { name = Item.ItemName.Rock, size = Item.ItemSize.Small, type = Item.ItemType.Dull, material = Item.ItemMaterial.Metal });

        AddItem(new Item { name = Item.ItemName.Rock, size = Item.ItemSize.Small, type = Item.ItemType.Dull, material = Item.ItemMaterial.Metal });

        //Debug.Log(itemList.Count);
    }

    //Adds Items to Inventory and updates the inventory organization UI
    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    //Removes Items used in the Craft system
    public void CraftRemoval(Item item1, Item item2, Item item3)
    {
        itemList.Remove(item1);

        itemList.Remove(item2);

        itemList.Remove(item3);
    }

    //Returns all Items in the Inventory
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
