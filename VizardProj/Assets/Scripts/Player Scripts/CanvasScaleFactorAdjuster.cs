using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScaleFactorAdjuster : MonoBehaviour
{
    public Camera MainCamera;

    void Start()
    {
        AdjustScalingFactor();
    }

    void LateUpdate()
    {
        AdjustScalingFactor();
    }

    void AdjustScalingFactor()
    {
    }
}
