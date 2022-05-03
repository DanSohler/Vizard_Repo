using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ad Verb Object", menuName = "Verb System/Verbs/AdVerb")]
public class AdVerbObject : VerbObject
{
    public string verbColour = "AdVerb";
    [HideInInspector] public string verbName;
    // Used for math later with comparing verbs
    public int verbWeigt;
    private AdVerbObject self;

    public void Awake()
    {
        type = VerbType.AdVerbs;
        self = this;
        //verbName = self.name;
        //Debug.Log("Hey, I'm" + verbName);
    }
}
