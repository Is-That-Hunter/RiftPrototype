using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to the Image Object within each Item Slot

//Acts as a variable tracker to keep track and change of
//The actual Item data that matches the image displayed

public class ImageItem : MonoBehaviour
{
    private InventoryItem attachedItem;

    private GameObject currentItemSlot;

    private void Awake()
    {
        currentItemSlot = transform.parent.gameObject;
    }

    public void SetItem(InventoryItem item)
    {
        attachedItem = item;
    }

    public InventoryItem GetItem()
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
}
