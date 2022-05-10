using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class VerbObject : ScriptableObject
{
    // Item added to UI display
    public GameObject prefab;
    public VerbType type;
    public string verbColour;
    [TextArea(7,10)]
    public string description;
    public int verbWeigt;
}

public enum VerbType
{
    RedVerbs,
    BlueVerbs,
    GreenVerbs,
    AdVerbs
}