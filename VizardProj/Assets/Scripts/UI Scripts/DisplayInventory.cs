using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> verbsDisplayed = new Dictionary<InventorySlot, GameObject> ();

    void start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].verb.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition();

            verbsDisplayed.Add(inventory.Container[i], obj);
        }

    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
           if (verbsDisplayed.ContainsKey(inventory.Container[i]))
            {
            }
           else
            {
                var obj = Instantiate(inventory.Container[i].verb.prefab, Vector3.zero, Quaternion.identity, transform);
                //fills the collected obj with details from the prefab it spawned from
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].verb.name.ToString();
                obj.GetComponent<VerbStats>().SetVerbStats(inventory.Container[i].verb.name, inventory.Container[i].verb.verbColour, inventory.Container[i].verb.verbWeigt);
                obj.GetComponent<RectTransform>().localPosition = GetPosition();
                verbsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public void GreyOutVerbs()
    {

    }



    public Vector3 GetPosition()
    {
        return new Vector3(0, 0, 0);
    }
}


