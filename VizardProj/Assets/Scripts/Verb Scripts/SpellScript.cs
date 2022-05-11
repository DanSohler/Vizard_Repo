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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var corectSpell = SpellCombo();
            if (corectSpell)
            {
                Debug.Log("You did it!");
            }
        }
    }

    private bool SpellCombo()
    {
        var verbNamesCorrect = false;
        var verbColourCorrect = false;
        var verbWeightCorrect = false;

        //stores everal if's, will be messy
        //checks verb names
        if (wantedVerbName == spellVerbName)
        {
            Debug.Log("First Name is correct!");
            if (wantedVerbName1 == spellVerbName1)
            {
                if (wantedVerbName2 == spellVerbName2)
                {
                    if (wantedVerbName3 == spellVerbName3)
                    {
                        if (wantedVerbName4 == spellVerbName4)
                        {
                            verbNamesCorrect = true;
                            Debug.Log("All names correct!");
                        }
                    }
                }
            }
        }

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
                            Debug.Log("All colours correct!");
                        }
                    }
                }
            }
        }

        if (wantedVerbIntTotal == spellVerbIntTotal)
        {
            verbWeightCorrect = true;
            Debug.Log("All weights correct!");
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
