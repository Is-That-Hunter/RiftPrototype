using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemDescUpdate : MonoBehaviour
{
    public GameObject Item_Display;

    public TextMeshProUGUI Item_Descr;

    public TextMeshProUGUI Item_Attr;

    public TextMeshProUGUI Item_Name;

    public EventSystem m_EventSystem;

    public UIInventory uiInventory;

    // Update is called once per frame
    void Update()
    {
        if(uiInventory.CurrentItem != null)
        {
            Item currentItem = uiInventory.CurrentItem.GetComponent<ImageItem>().GetItem().item;
            Item_Display.GetComponent<Image>().sprite = currentItem.GetSprite();
            Item_Descr.text = currentItem.GetDesc();
            Item_Attr.text = currentItem.GetAttr();
            Item_Name.text = currentItem.itemName;
        }
        else if(uiInventory.CurrentItem == null)
        {
            Item_Display.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items/EmptyItem");
            Item_Descr.text = "";
            Item_Attr.text = "";
            Item_Name.text = "";
        }
    }
}
