using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerbDisable : MonoBehaviour
{
    public SlotManager slotManScript;

    private void Awake()
    {
        slotManScript = FindObjectOfType<SlotManager>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            var maxChildCount = slotManScript.invScreen.transform.childCount;

            var randomChild = Random.Range(0, maxChildCount);

            DisableVerbInInventory(slotManScript.invScreen.transform.GetChild(randomChild).gameObject);
            Debug.Log("Disabled " + slotManScript.invScreen.transform.GetChild(randomChild).name);
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            ReenableVerbInInventory();
            Debug.Log("Enabled all verbs");
        }
    }

    public void DisableVerbInInventory(GameObject inventoryVerb)
    {
        inventoryVerb.GetComponent<Image>().color = Color.grey;
        inventoryVerb.GetComponent<Image>().raycastTarget = false;
    }

    public void ReenableVerbInInventory()
    {
        int children = slotManScript.invScreen.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            slotManScript.invScreen.transform.GetChild(i).GetComponent<Image>().color = slotManScript.invScreen.transform.GetChild(i).GetComponent<VerbStats>().initialColour;
            slotManScript.invScreen.transform.GetChild(i).GetComponent<Image>().raycastTarget = false;
        }
    }
}
