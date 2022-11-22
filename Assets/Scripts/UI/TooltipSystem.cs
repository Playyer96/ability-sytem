using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem _tooltipSystem;
    
    private void Awake()
    {
        _tooltipSystem = this;
    }

    public static void Show(bool value)
    {
        _tooltipSystem.gameObject.SetActive(value );
    }
}
