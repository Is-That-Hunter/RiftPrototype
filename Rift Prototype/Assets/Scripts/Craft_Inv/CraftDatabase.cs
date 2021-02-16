using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Database of all crafting recipes

public class CraftDatabase
{
    //Kept as a Dictionary, where the keys are the Size, Type, Material needed to craft the item
    //The Item object (Item.cs) being the data
    private Dictionary<(string, string, string), string> data;

    //Creates the CraftDatabase instance
    public CraftDatabase(Item[] items)
    {
        data = new Dictionary<(string, string, string), string>();
        foreach(Item item in items)
        {
            data.Add((item.itemSize, item.itemType, item.itemMaterial), item.itemName);
        }
    }

    //Returns the Crafting Dictionary
    public Dictionary<(string, string, string), string> GetRecipe()
    {
        return data;
    }
}