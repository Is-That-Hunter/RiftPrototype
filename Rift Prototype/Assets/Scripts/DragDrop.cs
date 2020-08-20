using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] Canvas canvas;
    [SerializeField] CraftBehavior craftBehavior;

    private bool landedOnItemSlot;
    private GameObject itemSlot;


    private Transform itemSlotContainerT;
    private CanvasGroup canvasGroup;
    private RectTransform rectT;
    private int beginningLayer;
    
    private void Awake()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        rectT = GetComponent<RectTransform>();
        // transform gets the location of the object in the heirarchy
        itemSlotContainerT = transform.parent;
        itemSlot = itemSlotContainerT.transform.GetChild(0).gameObject;
        // getchild is grabbing at the 0th index
        beginningLayer = rectT.GetSiblingIndex();
        // GetSiblingIndex is getting the current location of this object on hierarchy 
        landedOnItemSlot = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemSlotContainerT.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        switch (eventData.pointerDrag.GetComponent<ImageItem>().GetItemSlot().name)
        {
            case "sizeSlot":
                craftBehavior.SetSize(null);
                craftBehavior.Update();
                break;
            case "typeSlot":
                craftBehavior.SetType(null);
                craftBehavior.Update();
                break;
            case "materialSlot":
                craftBehavior.ResetMaterial();
                craftBehavior.Update();
                break;
        }

        eventData.pointerDrag.GetComponent<ImageItem>().SetItemSlot(itemSlot);

        Debug.Log("I Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Currently Dragging");
        rectT.anchoredPosition += eventData.delta;
        // delta follows the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        itemSlotContainerT.SetSiblingIndex(beginningLayer);
        Debug.Log("Ending Drag");
        canvasGroup.blocksRaycasts = true;

        if(!landedOnItemSlot)
        {
            Debug.Log("getting called");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = itemSlot.GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        landedOnItemSlot = false;
        Debug.Log("pointer down");
    }

    public void SetItemSlotChecker(bool boo)
    {
        landedOnItemSlot = boo;
    }
}
