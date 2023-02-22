using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : TooltipTrigger
{
    private Button _button;
    public Sprite _sprite;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.image.sprite = _sprite;
    }
}
