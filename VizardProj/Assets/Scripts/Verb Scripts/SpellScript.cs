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

        }
    }

    private bool SpellCombo()
    {
        //stores everal if's, will be messy
        if (wantedVerbName == spellVerbName && wantedVerbName1 == spellVerbName1 && wantedVerbName2 == spellVerbName2 && wantedVerbColour3 == spellVerbName3 && wantedVerbName4 == spellVerbName4)
        {
            if (wantedVerbColour == spellVerbColour && wantedVerbColour1 == spellVerbColour1 && wantedVerbColour2 == spellVerbColour2 && wantedVerbColour3 == spellVerbColour3 && wantedVerbColour4 == spellVerbColour4)
            {
                if (wantedVerbIntTotal == spellVerbIntTotal)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
