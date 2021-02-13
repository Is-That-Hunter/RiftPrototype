using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attatch to Item Tagged Objects and edit its name for each item

public class Item_Pickup_Var : MonoBehaviour
{
    public Item.ItemName attachedItemName;

    public Item attachedItem;

    private void Awake()
    {
        ItemDatabase data = new ItemDatabase();

        attachedItem = data.FindItem(attachedItemName);
    }
}
