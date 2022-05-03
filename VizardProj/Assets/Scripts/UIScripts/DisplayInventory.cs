using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> verbsDisplayed = new Dictionary<InventorySlot, GameObject> ();

    void start()
    {
        CreatDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    public void CreatDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].verb.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition();
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            verbsDisplayed.Add(inventory.Container[i], obj);
        }

    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
           if (verbsDisplayed.ContainsKey(inventory.Container[i]))
            {
                verbsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
           else
            {
                var obj = Instantiate(inventory.Container[i].verb.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition();
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                verbsDisplayed.Add(inventory.Container[i], obj);
            }

        }

    }
    public Vector3 GetPosition()
    {
        return new Vector3(0, 0, 0);
    }
}
