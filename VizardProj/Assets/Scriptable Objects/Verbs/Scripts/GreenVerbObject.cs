using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Green Verb Object", menuName = "Verb System/Verbs/GreenVerb")]
public class GreenVerbObject : VerbObject
{
    [HideInInspector] public string verbName;
    // Used for math later with comparing verbs
    private GreenVerbObject self;

    public void Awake()
    {
        self = this;
        verbColour = "Green";
        verbName = self.name;
        type = VerbType.GreenVerbs;
        //Debug.Log("Hey, I'm" + verbName);
    }
}

