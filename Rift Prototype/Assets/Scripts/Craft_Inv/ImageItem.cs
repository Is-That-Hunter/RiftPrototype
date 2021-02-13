using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to the Image Object within each Item Slot

//Acts as a variable tracker to keep track and change of
//The actual Item data that matches the image displayed

public class ImageItem : MonoBehaviour
{
    private Item attachedItem;

    private GameObject currentItemSlot;

    private bool craft_Available = true;

    public GameObject assigned_Craft = null;

    private void Awake()
    {
        currentItemSlot = transform.parent.gameObject;
    }

    public void SetItem(Item item)
    {
        attachedItem = item;
    }

    public Item GetItem()
    {
        return attachedItem;
    }

    public void SetItemSlot(GameObject slot)
    {
        currentItemSlot = slot;
    }

    public GameObject GetItemSlot()
    {
        return currentItemSlot;
    }

    public bool GetCraftBool()
    {
        return craft_Available;
    }

    public void SetCraftBool(bool var)
    {
        craft_Available = var;
    }
}
