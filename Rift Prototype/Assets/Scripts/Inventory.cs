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

        AddItem(new Item { name = Item.ItemName.SmallMetal, size = Item.ItemSize.Small, type = Item.ItemType.Sharp, material = Item.ItemMaterial.Metal });

        AddItem(new Item { name = Item.ItemName.Battery, size = Item.ItemSize.Small, type = Item.ItemType.Electric, material = Item.ItemMaterial.Metal });

        AddItem(new Item { name = Item.ItemName.Rock, size = Item.ItemSize.Small, type = Item.ItemType.Dull, material = Item.ItemMaterial.Metal });

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void CraftRemoval(Item item1, Item item2, Item item3)
    {
        itemList.Remove(item1);

        itemList.Remove(item2);

        itemList.Remove(item3);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
