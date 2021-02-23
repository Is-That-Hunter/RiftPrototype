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

    public EventSystem m_EventSystem;

    private GameObject currentSelected = null;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_EventSystem.currentSelectedGameObject);
        if (currentSelected != m_EventSystem.currentSelectedGameObject && m_EventSystem.currentSelectedGameObject != null)
        {
            currentSelected = m_EventSystem.currentSelectedGameObject;

            Item currentItem = currentSelected.GetComponent<ImageItem>().GetItem();

            Item_Display.GetComponent<Image>().sprite = currentItem.GetSprite();

            Item_Descr.text = currentItem.GetDesc();

            Item_Attr.text = currentItem.GetAttr();

        }
    }
}
