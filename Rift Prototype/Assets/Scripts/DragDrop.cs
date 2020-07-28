using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] Canvas canvas;

    private Transform itemSlotContainerT;
    private CanvasGroup canvasGroup;
    private RectTransform rectT;
    private int beginningLayer;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectT = GetComponent<RectTransform>();
        itemSlotContainerT = transform.parent;
        beginningLayer = rectT.GetSiblingIndex();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemSlotContainerT.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("I Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Currently Dragging");
        rectT.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        itemSlotContainerT.SetSiblingIndex(beginningLayer);
        Debug.Log("Ending Drag");
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointer down");
    }
}
