using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Red Verb Object", menuName = "Verb System/Verbs/RedVerb")]
public class RedVerbObject : VerbObject
{
    [HideInInspector] public string verbName;
    // Used for math later with comparing verbs
    private RedVerbObject self;

    public void Awake()
    {
        self = this;
        verbColour = "Red";
        verbName = self.name;
        type = VerbType.RedVerbs;
        //Debug.Log("Hey, I'm" + verbName);
    }
}

