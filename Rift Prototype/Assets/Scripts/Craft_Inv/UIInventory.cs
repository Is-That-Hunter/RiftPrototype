 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//This script handles the loading and behaviors of the Inventory UI
//This script is kept attatched to the Inventory Table

public class UIInventory : MonoBehaviour
{
    //The UI consists of the current Inventory, The base empty object of each item slot, and the Item_Slot itself
    private Inventory inventory;
    private Transform inventory_Slots;
    private Transform item_Slot_Base;
    public EventSystem m_EventSystem;

    private void Awake()
    {
        inventory_Slots = transform.Find("Inventory_Slots");
        item_Slot_Base = inventory_Slots.Find("Item_Slot_Base");
    }

    //Sets the Inventory for the UI Instance -> Inventory Database instance stored in GlobalScript.cs
    //We do this to keep the inventory object instance the same whenever called
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    //Called in the event the Inventory is changed (Event part of Inventory Object (Inventory.cs))
    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void OnEnable()
    {
        if(inventory != null)
        {
            RefreshInventoryItems();
        }
    }

    //Refreshes the UI to display the current inventory in the form of Inventory Slot, and Images within those Slots
    private void RefreshInventoryItems()
    {
        bool selector = true;
        foreach(Transform child in inventory_Slots)
        {
            if (child == item_Slot_Base) continue;
            Destroy(child.gameObject);
        }

        foreach (InventoryItem InvItem in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(item_Slot_Base, inventory_Slots).GetComponent<RectTransform>();
            if (selector)
            {
                m_EventSystem.SetSelectedGameObject(itemSlotRectTransform.GetChild(0).GetChild(0).gameObject);
                selector = false;
            }
            itemSlotRectTransform.gameObject.SetActive(true);

            Image image = itemSlotRectTransform.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
            image.GetComponent<ImageItem>().SetItem(InvItem);
            image.sprite = InvItem.item.GetSprite();
        }
    }
}
