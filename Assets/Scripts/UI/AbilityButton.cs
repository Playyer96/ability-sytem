using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Image _image;

    private AbilityBase _ability;

    private void Start()
    {
        _name = _ability.AbilityName;
        _description = _ability.Description;
        _image.sprite = _ability.Icon;
    }
}
