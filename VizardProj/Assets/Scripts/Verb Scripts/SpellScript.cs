using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : SpellManager
{
    [Header("Verb Names")]
    // String Verb Name Holders
    public string wantedVerbName = null;
    public string wantedVerbName1 = null;
    public string wantedVerbName2 = null;
    public string wantedVerbName3 = null;
    public string wantedVerbName4 = null;
    [Header("Verb Colours")]
    // String Verb Colour Holders
    public string wantedVerbColour = null;
    public string wantedVerbColour1 = null;
    public string wantedVerbColour2 = null;
    public string wantedVerbColour3 = null;
    public string wantedVerbColour4 = null;
    [Header("Verb Weight Total")]
    // Int Verb Weight Holders
    public int wantedVerbIntTotal = 0;

    [Header("Obj References")]
    public PlayerCam playerCamScript;
    public SpellTarget currentTarget;
    public SpellEffect spellTargetObj;
    // used to display if correct combo is present
    public GameObject spellTickBox;
    public SlotManager SlotManScript;


    private void Start()
    {
        spellTickBox.SetActive(false);
        SlotManScript = FindObjectOfType<SlotManager>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCamScript.inSpellArea = true;
            var corectSpell = SpellCombo();
            if (corectSpell)
            {
                spellTickBox.SetActive(true);
                if (playerCamScript.castingSpell == true)
                {
                    Debug.Log("Spell is cast");
                    spellTargetObj.SpellResult(currentTarget);

                    playerCamScript.inSpellArea = false;
                    playerCamScript.castingSpell = false;

                    spellTickBox.SetActive(false);

                    SlotManScript.ResetSlotChildren();
                    playerCamScript.SlotManage();
                    return;
                }
            }
        }

        if (playerCamScript.camCurrentState == menuState.menuDisabled)
        {
            spellTickBox.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spellTickBox.SetActive(false);
            SlotManScript.SetVerbSlotValues();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerCamScript.inSpellArea = false;
            spellTickBox.SetActive(false);
            SlotManScript.SetVerbSlotValues();
        }
    }

    private bool SpellCombo()
    {
        var verbNamesCorrect = false;
        var verbColourCorrect = false;
        var verbWeightCorrect = false;

        //stores everal if's, will be messy
        //checks verb names
        if (wantedVerbName.Equals(spellVerbName))
           {
            if (wantedVerbName1.Equals(spellVerbName1))
               {
                if (wantedVerbName2.Equals(spellVerbName2))
                   {
                       if (wantedVerbName3.Equals(spellVerbName3))
                       {
                           if (wantedVerbName4.Equals(spellVerbName4))
                           {
                               verbNamesCorrect = true;
                           }
                       }
                   }
               }
        }
        //checks verb colours
        if (wantedVerbColour == spellVerbColour)
        {
            if (wantedVerbColour1 == spellVerbColour1)
            {
                if (wantedVerbColour2 == spellVerbColour2)
                {
                    if (wantedVerbColour3 == spellVerbColour3)
                    {
                        if (wantedVerbColour4 == spellVerbColour4)
                        {
                            verbColourCorrect = true;
                        }
                    }
                }
            }
        }
        //checks verb weight
        if (wantedVerbIntTotal == spellVerbIntTotal)
        {
            verbWeightCorrect = true;
            //Debug.Log("All weights correct!");
        }

        //checks if each of the 3 variables are correct
        if (verbNamesCorrect && verbColourCorrect && verbWeightCorrect)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public enum SpellTarget
{
    enemy,
    door,
    chest,
}