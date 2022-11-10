using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : Singleton<AbilityManager>
{
    private readonly List<AbilityBase> _abilities = new List<AbilityBase>();
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
        foreach (var ability in _abilitiesMap)
        {
            ability.Value.enabled = toggle;
        }
    }

    public void ToggleAbility(string abilityName,bool toggle)
    {
        foreach (var ability in _abilitiesMap)
        {
            if (ability.Key == abilityName)
            {
                ability.Value.enabled = toggle;
            }
        }
    }

    public AbilityBase GetAbility(string abilityName)
    {
        foreach (var ability in _abilitiesMap)
        {
            if (ability.Key == abilityName)
            {
                return ability.Value;
            }
        }

        return null;
    }
}

