using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField] private string abilityName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool isEnable;

    public string AbilityName { get => abilityName; set => abilityName = value; }
    public string Description { get => description; set => description = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public bool IsEnable { get => isEnable; set => isEnable = value; }

    public abstract void UseAbility();

    /// <summary>
    /// Here you need to write your ability code
    /// </summary>
    public abstract void Ability();

}
