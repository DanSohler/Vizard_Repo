using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject[] slotList;
    [SerializeField] private GameObject invScreen;

    private void Start()
    {
        //ensures each slot is closed on sta
        for (int i = 0; i < slotList.Length; ++i)
        {
            slotList[i].SetActive(false);
        }
    }

    void grabSlotItemData()
    {

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
}
