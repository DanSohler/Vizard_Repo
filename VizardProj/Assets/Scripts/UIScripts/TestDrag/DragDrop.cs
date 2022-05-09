using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private RectTransform originPoint;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        originPoint = GetComponent<RectTransform>();

        originPoint = GetComponent<RectTransform>();
    }

    #region Mouse Logic

    //Called when we begin dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("StartDrag");
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    //Called when we drag
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //Called wgeb we end dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = originPoint.anchoredPosition;
    }

    //Call when we click down
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    

    #endregion
}
