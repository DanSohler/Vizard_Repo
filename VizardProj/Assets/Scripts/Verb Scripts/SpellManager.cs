using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public SlotManager slotManScript;

    private void Awake()
    {
        slotManScript = GetComponent<SlotManager>();
    }

    //Script should contain the verb recepies needed for executing verb spells

}
