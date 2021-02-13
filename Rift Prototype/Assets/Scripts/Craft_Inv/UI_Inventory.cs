 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//This script handles the loading and behaviors of the Inventory UI
//This script is kept attatched to the Inventory Table

public class UI_Inventory : MonoBehaviour
{
    //The UI consists of the current Inventory, The base empty object of each item slot, and the Item_Slot itself
    private Inventory inventory;
    private Transform inventory_Slots;
    private Transform item_Slot_Base;
    public EventSystem m_EventSystem;

    private void Awake()
    {
        Debug.Log("Woohoo");
        inventory_Slots = transform.Find("Inventory_Slots");
        item_Slot_Base = inventory_Slots.Find("Item_Slot_Base");
        Debug.Log(inventory_Slots);
        Debug.Log(item_Slot_Base);
    }

    //Sets the Inventory for the UI Instance -> Inventory Database instance stored in Global_Script.cs
    //We do this to keep the inventory object instance the same whenever called
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
        //EventSystem.current.SetSelectedGameObject(inventory_Slots.GetChild(1).GetChild(0).GetChild(0).gameObject);
    }

    //Called in the event the Inventory is changed (Event part of Inventory Object (Inventory.cs))
    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    //Refreshes the UI to display the current inventory in the form of Inventory Slot, and Images within those Slots
    private void RefreshInventoryItems()
    {
        bool selector = true;
        //First to ensure no duplicates within the inventory display we destroy all current objects in the UI
        foreach(Transform child in inventory_Slots)
        {
            if (child == item_Slot_Base) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;

        //This will adaptively need to be changed to fit the size of the inventory slots just a heads up
        //I wonder if theres a way to make it less hardcoded, will have to check that out, maybe have it compared to the width/height of the background image in
        //itemSlotTemplate hmmmmm
        float itemSlotCellSize = 120f; 
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(item_Slot_Base, inventory_Slots).GetComponent<RectTransform>();
            if (selector)
            {
                m_EventSystem.SetSelectedGameObject(itemSlotRectTransform.GetChild(0).GetChild(0).gameObject);
                selector = false;
            }
            itemSlotRectTransform.gameObject.SetActive(true);

            // VVVV This is Yucky hardcoded BS will need to change later, but its pretty easy its just refering to the coordinates (x, y) of the itemSlotTemplate
            // VVVV Will change in the future but leaving it for now for simplicity 
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize - 456, y * itemSlotCellSize - 26);

            Image image = itemSlotRectTransform.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
            image.GetComponent<ImageItem>().SetItem(item);
            image.sprite = item.GetSprite();

            x++;

            //Similar to the above this'll have to change dependent on the number of items that can fit per row
            //Honestly there's probably a quick equation we can use to determine the total number that can fit per row
            //Will have to change in the future for simplicity in UI modification
            if(x > 3)
            {
                x = 0;
                y++;
            }
        }
    }
}
