using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Blue Verb Object", menuName = "Verb System/Verbs/BlueVerb")]
public class BlueVerbObject : VerbObject
{
    public string verbColour = "Blue";
    [HideInInspector] public string verbName;
    // Used for math later with comparing verbs
    public int verbWeigt;
    private BlueVerbObject self;

    public void Awake()
    {
        type = VerbType.BlueVerbs;
        self = this;
        //verbName = self.name;
        //Debug.Log("Hey, I'm" + verbName);
    }
}
