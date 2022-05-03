using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Red Verb Object", menuName = "Verb System/Verbs/RedVerb")]
public class RedVerbObject : VerbObject
{
    public string verbColour = "Red";
    [HideInInspector] public string verbName;
    // Used for math later with comparing verbs
    public int verbWeigt;
    private RedVerbObject self;

    public void Awake()
    {
        type = VerbType.RedVerbs;
        self = this;
        //verbName = self.name;
        //Debug.Log("Hey, I'm" + verbName);
    }
}

