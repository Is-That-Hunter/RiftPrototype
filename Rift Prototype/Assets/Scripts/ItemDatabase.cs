using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase
{
    private Dictionary<Item.ItemName, Item> itemDict;

    public ItemDatabase()
    {
        itemDict = new Dictionary<Item.ItemName, Item>
        {
            {Item.ItemName.Battery, new Item { name = Item.ItemName.Battery, size = Item.ItemSize.Small, type = Item.ItemType.Electric, material = Item.ItemMaterial.Metal } },

            {Item.ItemName.Rock, new Item { name = Item.ItemName.Rock, size = Item.ItemSize.Small, type = Item.ItemType.Dull, material = Item.ItemMaterial.Metal } },

            {Item.ItemName.SmallMetal, new Item { name = Item.ItemName.SmallMetal, size = Item.ItemSize.Small, type = Item.ItemType.Sharp, material = Item.ItemMaterial.Metal } },

            {Item.ItemName.Flashlight, new Item { name = Item.ItemName.Flashlight, size = Item.ItemSize.Small, type = Item.ItemType.Electric, material = Item.ItemMaterial.Metal } },

            {Item.ItemName.Resetcraft, new Item { name = Item.ItemName.Resetcraft} }
        };
    }

    public Item FindItem(Item.ItemName name)
    {
        Debug.Log(name);
        Debug.Log(itemDict);
        return itemDict[name];
    }
}
