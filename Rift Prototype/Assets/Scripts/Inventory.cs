using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        Debug.Log("Inventory");

        AddItem(new Item { name = Item.ItemName.SmallMetal, size = Item.ItemSize.Small, type = Item.ItemType.sharp, material = Item.ItemMaterial.Metal });

        AddItem(new Item { name = Item.ItemName.Battery, size = Item.ItemSize.Small, type = Item.ItemType.sharp, material = Item.ItemMaterial.Metal });

        AddItem(new Item { name = Item.ItemName.Rock, size = Item.ItemSize.Small, type = Item.ItemType.dull, material = Item.ItemMaterial.Metal });

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
