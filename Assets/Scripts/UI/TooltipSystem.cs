using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem _tooltipSystem;

    [SerializeField] private Tooltip tooltip;
    
    private void Awake()
    {
        _tooltipSystem = this;
    }

    public static void Show(bool value, string content, string header = "")
    {
        _tooltipSystem.tooltip.SetText(content, header);
        _tooltipSystem.tooltip.gameObject.SetActive(value);
    }

    public static void Show(bool value)
    {
        _tooltipSystem.tooltip.gameObject.SetActive(false);
    }
}
