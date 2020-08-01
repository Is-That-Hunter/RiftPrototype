using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] CraftBehavior craftBehavior;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(gameObject);
        Debug.Log(eventData.pointerDrag);
        Debug.Log("Dropped on Item Slot");
        if (eventData.pointerDrag != null)
        {
            Item currentImageItem = eventData.pointerDrag.GetComponent<ImageItem>().GetItem();
            GameObject parent = transform.parent.gameObject;
            GameObject pointerParent = eventData.pointerDrag.transform.parent.gameObject;
            Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
            eventData.pointerDrag.GetComponent<DragDrop>().SetItemSlotChecker(true);
            //Note a switch statement below might be better

            switch (parent.name)
            {
                case "sizeSlot":
                    Debug.Log("This landed in the size slot");
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = parent.GetComponent<RectTransform>().anchoredPosition - pointerParent.GetComponent<RectTransform>().anchoredPosition;
                    eventData.pointerDrag.GetComponent<ImageItem>().SetItemSlot(parent);
                    craftBehavior.SetSize(currentImageItem);
                    craftBehavior.Update();
                    Debug.Log(currentImageItem.size);
                    break;
                case "typeSlot":
                    Debug.Log("This landed in the type slot");
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = parent.GetComponent<RectTransform>().anchoredPosition - pointerParent.GetComponent<RectTransform>().anchoredPosition;
                    eventData.pointerDrag.GetComponent<ImageItem>().SetItemSlot(parent);
                    craftBehavior.SetType(currentImageItem);
                    craftBehavior.Update();
                    Debug.Log(currentImageItem.type);
                    break;
                case "materialSlot":
                    Debug.Log("This landed in the material slot");
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = parent.GetComponent<RectTransform>().anchoredPosition - pointerParent.GetComponent<RectTransform>().anchoredPosition;
                    eventData.pointerDrag.GetComponent<ImageItem>().SetItemSlot(parent);
                    craftBehavior.SetMaterial(currentImageItem);
                    craftBehavior.Update();
                    Debug.Log(currentImageItem.material);
                    break;
                default:
                    Debug.Log("This landed in the inventory slot");
                    if (parent == pointerParent)
                    {
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                        eventData.pointerDrag.GetComponent<ImageItem>().SetItemSlot(pointerParent);
                    }
                    else
                    {
                        //I'm leaving this manually inputted for now just to return it to its original anchor positioning if trying to go into another item slot
                        //Later I'll be modifying this section so that the whole ItemSlotTemplate Objects switch positions 
                        //It's the easiest and causes the least amount of potential problems
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(-7, -2);
                        eventData.pointerDrag.GetComponent<ImageItem>().SetItemSlot(pointerParent);
                    }
                    break;
            }
        }
    }
}
