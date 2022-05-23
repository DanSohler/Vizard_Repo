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

    //ref to playercam states
    PlayerCam camScript;

    private void Awake()
    {
        camScript = FindObjectOfType<PlayerCam>();
    }

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

    public void SetVerbSlotValues()
    {
        if (camScript.camCurrentState == menuState.menuEnabled)
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
            return;
        }

        if (camScript.camCurrentState == menuState.menuDisabled)
        {
            // resets the values of each itemslot
            for (int i = 0; i < verbSlotNames.Length; ++i)
            {
                verbSlotNames[i] = null;
            }
            for (int i = 0; i < verbSlotColours.Length; ++i)
            {
                verbSlotColours[i] = null;
            }
            for (int i = 0; i < verbSlotWeights.Length; ++i)
            {
                verbSlotWeights[i] = 0;
            }
        }
    }
}
