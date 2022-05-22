using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject[] slotList;
    public GameObject invScreen;

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

    public void ResetSlotChildren()
    {
         foreach (GameObject slotParent in slotList)
         {
             if (slotParent.transform.childCount > 0)
             {
             var child = slotParent.transform.GetChild(0);
             child.GetComponent<DragDrop>().ResetVerbObjPosition();
             //child.SetParent(invScreen.transform);
             slotParent.GetComponent<ItemSlot>().isHousingVerb = false;
             }
         }
    }

    public void ResetSlotValues()
    {
        //sets vars from slotList vars

        // verbSlotNames[0] = null;
        // verbSlotNames[1] = null;
        // verbSlotNames[2] = null;
        // verbSlotNames[3] = null;
        // verbSlotNames[4] = null;

        Array.Clear(verbSlotNames, 0, verbSlotNames.Length);

        //verbSlotColours[0] = null;
        //verbSlotColours[1] = null;
        //verbSlotColours[2] = null;
        //verbSlotColours[3] = null;
        //verbSlotColours[4] = null;

        //Resets vars from slotList vars

        //verbSlotWeights[0] = 0;
        //verbSlotWeights[1] = 0;
        //verbSlotWeights[2] = 0;
        //verbSlotWeights[3] = 0;
        //verbSlotWeights[4] = 0;
    }

    public void SetVerbSlotValues()
    {
        // grab values of each itemslot, and send them to spell manager
        for (int i = 0; i < verbSlotNames.Length; ++i)
        {
            //sets vars from slotList vars
            verbSlotNames[i] = slotList[i].gameObject.GetComponent<ItemSlot>().slotVerbName;
            if (verbSlotNames[i] == null)
            {
                verbSlotNames[i] = "emp";
            }
            verbSlotColours[i] = slotList[i].gameObject.GetComponent<ItemSlot>().slotVerbColour;
            if (verbSlotColours[i] == null)
            {
                verbSlotColours[i] = "emp";
            }
            verbSlotWeights[i] = slotList[i].gameObject.GetComponent<ItemSlot>().slotVerbWeight;
        }
    }
}
