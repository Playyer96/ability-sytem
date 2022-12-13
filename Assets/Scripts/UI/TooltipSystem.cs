using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem tooltipSystem;

    [SerializeField] private Tooltip tooltip;
    
    private void Awake()
    {
        tooltipSystem = this;
    }

    public static void Show(bool value, string content, string header = "")
    {
        if(string.IsNullOrEmpty(header) || string.IsNullOrEmpty(content)) return;
        
        tooltipSystem.tooltip.SetText(content, header);
        tooltipSystem.tooltip.gameObject.SetActive(value);
    }

    public static void Show(bool value)
    {
        tooltipSystem.tooltip.gameObject.SetActive(false);
    }
}
