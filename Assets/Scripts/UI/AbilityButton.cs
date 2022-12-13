using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : TooltipTrigger
{
    [SerializeField] private Image _image;

    private AbilityBase _ability;

    private void Start()
    {
    }
}
