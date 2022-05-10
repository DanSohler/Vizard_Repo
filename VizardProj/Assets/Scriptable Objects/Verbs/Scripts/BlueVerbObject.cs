using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Blue Verb Object", menuName = "Verb System/Verbs/BlueVerb")]
public class BlueVerbObject : VerbObject
{
    [HideInInspector] public string verbName;
    // Used for math later with comparing verbs
    private BlueVerbObject self;

    public void Awake()
    {
        self = this;
        verbColour = "Blue";
        verbName = self.name;
        type = VerbType.BlueVerbs;
        //Debug.Log("Hey, I'm" + verbName);
    }
}
