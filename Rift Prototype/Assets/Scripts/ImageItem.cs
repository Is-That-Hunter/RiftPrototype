using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageItem : MonoBehaviour
{
    private Item attachedItem;

    private GameObject currentItemSlot;

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
}
