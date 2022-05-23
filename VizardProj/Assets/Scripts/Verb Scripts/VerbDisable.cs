using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerbDisable : MonoBehaviour
{
    public SlotManager slotManScript;

    public int randomChild = 0;
    List<int> usedChildren = new List<int> ();

    private void Awake()
    {
        slotManScript = FindObjectOfType<SlotManager>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            DisableVerb();
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            ReEnableVerb();
        }
    }

    public void DisableVerb()
    {
        var maxChildCount = slotManScript.invScreen.transform.childCount;

        randomChild = Random.Range(0, maxChildCount);

        if (usedChildren.Count >= maxChildCount)
        {
            return;
        }

        while (usedChildren.Contains(randomChild))
        {
            randomChild = Random.Range(0, maxChildCount);
        }
        DisableVerbInInventory(slotManScript.invScreen.transform.GetChild(randomChild).gameObject);
        usedChildren.Add(randomChild);
    }

    public void ReEnableVerb()
    {
        ReenableVerbInInventory();
        usedChildren.Clear();
    }

    public void DisableVerbInInventory(GameObject inventoryVerb)
    {
        inventoryVerb.GetComponent<Image>().color = Color.grey;
        inventoryVerb.GetComponent<VerbStats>().isDisabled = true;
        inventoryVerb.GetComponent<Image>().raycastTarget = false;
    }

    public void ReenableVerbInInventory()
    {
        int children = slotManScript.invScreen.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            slotManScript.invScreen.transform.GetChild(i).GetComponent<Image>().color = slotManScript.invScreen.transform.GetChild(i).GetComponent<VerbStats>().initialColour;
            slotManScript.invScreen.transform.GetChild(i).GetComponent<VerbStats>().isDisabled = false;
            slotManScript.invScreen.transform.GetChild(i).GetComponent<Image>().raycastTarget = true;
        }
    }
}
