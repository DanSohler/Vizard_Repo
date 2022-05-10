using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    ItemSlot Instance;
    public GameObject self;

    [HideInInspector] public bool isHousingVerb = false;

    //Vars for storing slot variables for future reference
    public string slotVerbName;
    public string slotVerbColour;
    public int slotVerbWeight;


    private void Awake()
    {
        Instance = this;
        self = this.gameObject;
    }

    public void Update()
    {
        //checks if parent gameobj has any children
        if (self.transform.childCount > 0 )
        {
            var grabbed = self.transform.GetChild(0);
            isHousingVerb = true;
            GrabChildVars(grabbed.GetComponent<VerbStats>().verbName, grabbed.GetComponent<VerbStats>().verbColour, grabbed.GetComponent<VerbStats>().verbWeight);
        }
        else
        {
            ResetChildVars();
            isHousingVerb = false;
        }
    }

    //Grabs child vars for reading later
    public void GrabChildVars(string name, string colour, int weight)
    {
        slotVerbName = name;
        slotVerbColour = colour;
        slotVerbWeight = weight;
    }

    //Resets vars so when the slot is empty, it won't give false values
    public void ResetChildVars()
    {
        slotVerbName = null;
        slotVerbColour = null;
        slotVerbWeight = 0;
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
        }
    }
}
