using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IInitializePotentialDragHandler, IDragHandler
{
    //stores obj for reset
    GameObject orignialGrabbedObj;
    GameObject originInvParent;

    menuState currentState;

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector2 dragOriginPoint;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        originInvParent = GameObject.FindWithTag("Inventory");
    }

    #region Mouse Logic

    //Called when we begin dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        orignialGrabbedObj = eventData.pointerCurrentRaycast.gameObject;
        dragOriginPoint = rectTransform.anchoredPosition;

        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
        
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        eventData.useDragThreshold = false;
    }

    //Called when we drag
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //Called wgeb we end dragging
    public void OnEndDrag(PointerEventData eventData)
    {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            rectTransform.anchoredPosition = dragOriginPoint;
        
    }

    //Call when we click down
    public void OnPointerDown(PointerEventData eventData) {
    }

    #endregion

    public void ResetVerbObjPosition()
    {
        orignialGrabbedObj.transform.SetParent(originInvParent.transform);
    }
}
