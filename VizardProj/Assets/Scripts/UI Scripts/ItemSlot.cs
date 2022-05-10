using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    ItemSlot Instance;
    [SerializeField] GameObject self;

    public bool isHousingVerb = false;

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (self.transform.childCount > 0 )
        {
            isHousingVerb = true;
        }
        else
        {
            isHousingVerb = false;
        }
    }

    //Call when we drop the item
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
        {
            if (!isHousingVerb)
            {
                var t = eventData.pointerDrag.transform;
                t.SetParent(Instance.gameObject.transform);
            }
            

            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition / canvas.scaleFactor;
        }

    }
}
