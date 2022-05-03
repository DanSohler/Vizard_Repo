using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Green Verb Object", menuName = "Verb System/Verbs/GreenVerb")]
public class GreenVerbObject : VerbObject
{
    public string verbColour = "Green";
    [HideInInspector] public string verbName;
    // Used for math later with comparing verbs
    public int verbWeigt;
    private GreenVerbObject self;

    public void Awake()
    {
        type = VerbType.GreenVerbs;
        self = this;
        //verbName = self.name;
        //Debug.Log("Hey, I'm" + verbName);
    }
}

