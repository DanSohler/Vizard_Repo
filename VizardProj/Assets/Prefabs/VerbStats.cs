using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbStats : MonoBehaviour
{
    public string verbName;
    public string verbColour;
    public int verbWeight;

    public void SetVerbStats(string name, string colour, int weight)
    {
        verbName = name;
        verbColour = colour;
        verbWeight = weight;
    }
}
