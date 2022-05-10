using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject[] slotList;
    [SerializeField] private GameObject invScreen;

    // Series of lists containing values from each itemslot, might be messy
    public string[] verbSlotNames;
    public string[] verbSlotColours;
    public int[] verbSlotWeights;

    private void Start()
    {
        //ensures each slot is closed on start
        for (int i = 0; i < slotList.Length; ++i)
        {
            slotList[i].SetActive(false);
        }
    }

    public void Update()
    {
        SetVerbSlotValues();
    }

    public void resetSlots()
    {
         foreach (GameObject slotParent in slotList)
         {
             if (slotParent.transform.childCount > 0)
             {
             var child = slotParent.transform.GetChild(0);
             child.SetParent(invScreen.transform);
             slotParent.GetComponent<ItemSlot>().isHousingVerb = false;
             }
         }
    }

    public void SetVerbSlotValues()
    {
        // grab values of each itemslot, and send them to spell manager
        for (int i = 0; i < verbSlotNames.Length; ++i)
        {
            //sets vars from slotList vars
            verbSlotNames[i]   = slotList[i].gameObject.GetComponent<ItemSlot>().slotVerbName;
            verbSlotColours[i] = slotList[i].gameObject.GetComponent<ItemSlot>().slotVerbColour;
            verbSlotWeights[i] = slotList[i].gameObject.GetComponent<ItemSlot>().slotVerbWeight;
        }
    }
}
