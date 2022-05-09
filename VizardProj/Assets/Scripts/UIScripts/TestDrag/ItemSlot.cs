using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    ItemSlot Instance;

    private bool isHousingVerb = false;

    private Canvas canvas;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        Instance = this;
    }

    //Call when we drop the item
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        if (eventData.pointerDrag != null)
        {
            if (!isHousingVerb)
            {
                var t = eventData.pointerDrag.transform;
                t.SetParent(Instance.gameObject.transform);
                isHousingVerb = true;
            }
            
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition / canvas.scaleFactor;
        }

    }
}
