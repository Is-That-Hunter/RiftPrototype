using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Database of all crafting recipes

public class CraftDatabase : MonoBehaviour
{
    //Kept as a Dictionary, where the keys are the Size, Type, Material needed to craft the item
    //The Item object (Item.cs) being the data

    private Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName> data;

    //Creates the CraftDatabase instance
    public CraftDatabase()
    {

        data = new Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName>
        {
            { (Item.ItemSize.Small, Item.ItemType.Electric, Item.ItemMaterial.Metal), Item.ItemName.Flashlight},
        };

    }

    //Returns the Crafting Dictionary
    public Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName> GetRecipe()
    {
        return data;
    }
}