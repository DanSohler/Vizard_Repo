using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(VerbObject _verb, int _amount)
    {
        bool hasVerb = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].verb == _verb)
            {
                Container[i].AddAmount(_amount);
                hasVerb = true;
                break;
            }
        }
        if (!hasVerb)
        {
            Container.Add(new InventorySlot(_verb, _amount));
        }
    }



}
[System.Serializable]
public class InventorySlot
{
    public VerbObject verb;
    public int amount;
    public InventorySlot(VerbObject _verb, int _amount)
    {
        verb = _verb;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }


}