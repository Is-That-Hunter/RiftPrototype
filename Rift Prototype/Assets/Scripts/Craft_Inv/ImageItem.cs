using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Attached to the Image Object within each Item Slot

//Acts as a variable tracker to keep track and change of
//The actual Item data that matches the image displayed

public class ImageItem : MonoBehaviour, IPointerEnterHandler
{
    private InventoryItem attachedItem;

    private GameObject currentItemSlot;

    public CraftToolTip toolTip;

    public bool isToolTip = false;

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
    public void OnPointerEnter(PointerEventData eventData) {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "Slot" && isToolTip) {
            toolTip.gameObject.SetActive(true);
            toolTip.changeText(attachedItem.item.itemName);
        }
    }
}
