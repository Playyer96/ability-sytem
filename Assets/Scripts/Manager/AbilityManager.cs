using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : Singleton<AbilityManager>
{
    [SerializeField] private List<AbilityBase> _abilities = new List<AbilityBase>();
    private readonly Dictionary<string,AbilityBase> _abilitiesMap = new Dictionary<string, AbilityBase>();

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        foreach (var ability in _abilities)
        {
            AddAbility(ability);
        }
    }

    public void AddAbility(AbilityBase ability)
    {
        _abilitiesMap.Add(ability.AbilityName, ability);
    }

    public void RemoveAbility(AbilityBase ability)
    {
        _abilitiesMap.Remove(ability.AbilityName);
    }
    
    public void ToggleAbilities(bool toggle)
    {
        foreach (var (key, value) in _abilitiesMap)
        {
            value.enabled = toggle;
        }
    }

    public void ToggleAbility(string abilityName,bool toggle)
    {
        foreach (var (key, value) in _abilitiesMap)
        {
            if (key == abilityName)
            {
                value.enabled = toggle;
            }
        }
    }

    public AbilityBase GetAbility(string abilityName)
    {
        foreach (var (key, value) in _abilitiesMap)
        {
            if (key == abilityName)
            {
                return value;
            }
        }

        return null;
    }
}

