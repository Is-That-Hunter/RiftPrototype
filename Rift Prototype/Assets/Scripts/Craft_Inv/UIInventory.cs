 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

//This script handles the loading and behaviors of the Inventory UI
//This script is kept attatched to the Inventory Table

public class UIInventory : MonoBehaviour
{
    //The UI consists of the current Inventory, The base empty object of each item slot, and the Item_Slot itself
    private Inventory inventory;
    private Transform inventory_Slots;
    private Transform item_Slot_Base;
    public EventSystem m_EventSystem;
    public GameObject CurrentItem;

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
    private void OnDisable()
    {
        foreach(Transform child in inventory_Slots)
        {
            if (child != item_Slot_Base) 
            {
                child.GetChild(0).GetChild(0).GetComponent<Button>().enabled = false;
            }
        }
    }

    //Refreshes the UI to display the current inventory in the form of Inventory Slot, and Images within those Slots
    public void RefreshInventoryItems()
    {
        List<InventoryItem> currentInventory = inventory.GetItemList();
        List<InventoryItem> oldInventory = new List<InventoryItem>();
        bool selector = false;
        if(CurrentItem == null)
        {
            selector = true;
        }
        
        foreach(Transform child in inventory_Slots)
        {
            if (child == item_Slot_Base) continue;
            InventoryItem oldInvItem = child.transform.GetChild(0).GetChild(0).gameObject.GetComponent<ImageItem>().GetItem();
            InventoryItem invExist = currentInventory.FirstOrDefault(i=>i == oldInvItem);
            if(invExist == null)
            {
                if(child.transform.GetChild(0).GetChild(0).gameObject == CurrentItem)
                {
                    CurrentItem = null;
                    selector = true;
                }
                Destroy(child.gameObject);
            }
            else
            {
                oldInventory.Add(oldInvItem);
                child.GetChild(0).GetChild(0).GetComponent<Button>().enabled = true;
                if(selector == true)
                {
                    CurrentItem = child.transform.GetChild(0).GetChild(0).gameObject;
                    m_EventSystem.SetSelectedGameObject(CurrentItem);
                    selector = false;
                }
            }
        }

        foreach(InventoryItem currInvItem in currentInventory)
        {
            InventoryItem invExist = oldInventory.FirstOrDefault(i=>i == currInvItem);
            if(invExist == null)
            {
                RectTransform itemSlotRectTransform = Instantiate(item_Slot_Base, inventory_Slots).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                Image image = itemSlotRectTransform.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
                image.GetComponent<ImageItem>().SetItem(currInvItem);
                image.sprite = currInvItem.item.GetSprite();
                if(selector == true)
                {
                    CurrentItem = itemSlotRectTransform.gameObject.transform.GetChild(0).GetChild(0).gameObject;
                    m_EventSystem.SetSelectedGameObject(CurrentItem);
                    selector = false;
                }
            }
        }
    }
    
    void Update()
    {
        if(m_EventSystem.currentSelectedGameObject != null && m_EventSystem.currentSelectedGameObject.tag == "Slot")
        {
            if(CurrentItem != m_EventSystem.currentSelectedGameObject)
            {
                CurrentItem = m_EventSystem.currentSelectedGameObject;
            }
        }
        else {
            m_EventSystem.SetSelectedGameObject(CurrentItem);
        }
    }
    
}
