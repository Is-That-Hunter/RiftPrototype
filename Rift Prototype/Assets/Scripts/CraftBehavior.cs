using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBehavior : MonoBehaviour
{

    private Item requestedSize = null;

    private Item requestedType = null;

    private Item requestedMaterial = null;

    private Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName> recipe;

    private Inventory inventory;

    private ItemDatabase allItems;

    //Note to self/others the below is called frequently it can probably be replaced by a fixed event that occurs whenever something is dropped into the crafting slots

    public void Update()
    {
        if(requestedSize != null && requestedType != null && requestedMaterial != null)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void SetItemDatabase(ItemDatabase data)
    {
        this.allItems = data;
    }

    public void Craft()
    {
        Debug.Log(requestedSize.size + " " + requestedType.type + " " + requestedMaterial.material);
        if (recipe.TryGetValue((requestedSize.size, requestedType.type, requestedMaterial.material), out Item.ItemName value))
        {
            // Key was in dictionary; "value" contains corresponding value
            Debug.Log("craft Success: You made " + value);
            inventory.CraftRemoval(requestedSize, requestedType, requestedMaterial);
            inventory.AddItem(allItems.FindItem(value));
        }
        else
        {
            // Key wasn't in dictionary; "value" is now 0
            Debug.Log("Craft Fail");
        }
    }

    public void SetSize(Item item)
    {
        requestedSize = item;
    }

    public void SetType(Item item)
    {
        requestedType = item;
    }

    public void SetMaterial(Item item)
    {
        requestedMaterial = item;
    }

    public void SetRecipe(Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName> data)
    {
        recipe = data;
    }
}
