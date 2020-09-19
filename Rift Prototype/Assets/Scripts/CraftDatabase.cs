using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CraftDatabase : MonoBehaviour
{

    private Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName> data;

    public CraftDatabase()
    {

        data = new Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName>
        {
            { (Item.ItemSize.Small, Item.ItemType.Electric, Item.ItemMaterial.Metal), Item.ItemName.Flashlight},
        };

    }

    public Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName> GetRecipe()
    {
        return data;
    }
}
