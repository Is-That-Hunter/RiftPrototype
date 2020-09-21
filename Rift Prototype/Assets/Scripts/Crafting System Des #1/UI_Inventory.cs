 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
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
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            // VVVV This is Yucky hardcoded BS will need to change later, but its pretty easy its just refering to the coordinates (x, y) of the itemSlotTemplate
            // VVVV Will change in the future but leaving it for now for simplicity 
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize - 374, y * itemSlotCellSize + 136);

            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
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
