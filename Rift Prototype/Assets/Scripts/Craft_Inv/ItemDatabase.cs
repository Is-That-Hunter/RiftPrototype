using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the database of all items available in the game

public class ItemDatabase
{
    //The inventory system is kept as a dictionary of the custom Item object: See Item.cs
    private Dictionary<string, Item> itemDict;
    

    //This is a public function to create the ItemDatabase instance
    //Called in the creation of the Global Game Object, which holds the constant variables
    public ItemDatabase(Item[] items)
    {
        itemDict = new Dictionary<string, Item>();
        foreach(Item item in items)
        {
            itemDict.Add(item.itemName, item);
        }
    }

    //The ItemDatabase instance, holds the function which allows for the finding of specific Item objects using only the item name
    public Item FindItem(string name)
    {
        return itemDict[name];
    }
}
