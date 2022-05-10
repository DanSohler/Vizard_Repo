using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public SlotManager slotManScript;

    [Header("Verb Names")]
    // String Verb Name Holders
    protected string spellVerbName = null;
    protected string spellVerbName1 = null;
    protected string spellVerbName2 = null;
    protected string spellVerbName3 = null;
    protected string spellVerbName4 = null;
    [Header("Verb Colours")]
    // String Verb Colour Holders
    protected string spellVerbColour = null;
    protected string spellVerbColour1 = null;
    protected string spellVerbColour2 = null;
    protected string spellVerbColour3 = null;
    protected string spellVerbColour4 = null;
    [Header("Verb Weight Total")]
    // Int Verb Weight Holders
    protected int spellVerbIntTotal = 0;

    //Script will act as another container, to then make several if statements to check spell combos

    private void Update()
    {
        //Makes sure each of these holdes is updated live, convetring the list into 5 seperate vars
        //Verb Names
        spellVerbName = slotManScript.verbSlotNames[0];
        spellVerbName1 = slotManScript.verbSlotNames[1];
        spellVerbName2 = slotManScript.verbSlotNames[2];
        spellVerbName3 = slotManScript.verbSlotNames[3];
        spellVerbName4 = slotManScript.verbSlotNames[4];

        //Verb Colours
        spellVerbColour = slotManScript.verbSlotColours[0];
        spellVerbColour1 = slotManScript.verbSlotColours[1];
        spellVerbColour2 = slotManScript.verbSlotColours[2];
        spellVerbColour3 = slotManScript.verbSlotColours[3];
        spellVerbColour4 = slotManScript.verbSlotColours[4];

        //Verb Weights added together
        spellVerbIntTotal = slotManScript.verbSlotWeights[0] + slotManScript.verbSlotWeights[1] + slotManScript.verbSlotWeights[2] + slotManScript.verbSlotWeights[3] + slotManScript.verbSlotWeights[4];
    }

}
