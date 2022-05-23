using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerbStats : MonoBehaviour
{
    public string verbName;
    public string verbColour;
    public int verbWeight;
    public bool isDisabled = false;

    [HideInInspector]public Color initialColour;

    private void Awake()
    {
        initialColour = gameObject.GetComponent<Image>().color;
    }

    public void SetVerbStats(string name, string colour, int weight)
    {
        verbName = name;
        verbColour = colour;
        verbWeight = weight;
    }
}
