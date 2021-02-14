using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the database of all items available in the game

public class ItemDatabase
{
    //The inventory system is kept as a dictionary of the custom Item object: See Item.cs
    private Dictionary<Item.ItemName, Item> itemDict;

    //This is a public function to create the ItemDatabase instance
    //Called in the creation of the Global Game Object, which holds the constant variables
    public ItemDatabase()
    {
        itemDict = new Dictionary<Item.ItemName, Item>
        {
            {Item.ItemName.Battery, new Item { name = Item.ItemName.Battery, size = Item.ItemSize.Small, type = Item.ItemType.Electric, material = Item.ItemMaterial.Metal } },

            {Item.ItemName.Rock, new Item { name = Item.ItemName.Rock, size = Item.ItemSize.Small, type = Item.ItemType.Dull, material = Item.ItemMaterial.Metal } },

            {Item.ItemName.SmallMetal, new Item { name = Item.ItemName.SmallMetal, size = Item.ItemSize.Small, type = Item.ItemType.Sharp, material = Item.ItemMaterial.Metal } },

            {Item.ItemName.Flashlight, new Item { name = Item.ItemName.Flashlight, size = Item.ItemSize.Small, type = Item.ItemType.Electric, material = Item.ItemMaterial.Metal } },
        };
    }

    //The ItemDatabase instance, holds the function which allows for the finding of specific Item objects using only the item name
    public Item FindItem(Item.ItemName name)
    {
        //Debug.Log(name);
        //Debug.Log(itemDict);
        return itemDict[name];
    }
}
