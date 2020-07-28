using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(gameObject);
        Debug.Log(eventData.pointerDrag);
        Debug.Log("Dropped on Item Slot");
        if (eventData.pointerDrag != null)
        {
            GameObject parent = transform.parent.gameObject;
            GameObject pointerParent = eventData.pointerDrag.transform.parent.gameObject;
            Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
            //Note a switch statement below might be better
            if(parent == pointerParent)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            } else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = parent.GetComponent<RectTransform>().anchoredPosition - pointerParent.GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}
