using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ad Verb Object", menuName = "Verb System/Verbs/AdVerb")]
public class AdVerbObject : VerbObject
{
    [HideInInspector] public string verbName;
    // Used for math later with comparing verbs
    private AdVerbObject self;

    public void Awake()
    {
        self = this;
        verbColour = "AdVerb";
        verbName = self.name;
        type = VerbType.AdVerbs;
        //Debug.Log("Hey, I'm" + verbName);
    }
}
