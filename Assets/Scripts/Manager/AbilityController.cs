using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityController : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> _abilities = new List<AbilityBase>();
    [SerializeField] private PlayerInput playerInput;
    private readonly Dictionary<Guid, AbilityBase> _abilitiesMap = 
        new Dictionary<Guid, AbilityBase>();


    public void AddAbility(AbilityBase ability)
    {
        _abilitiesMap.Add(ability.InputAction.action.id, ability);
    }

    public void RemoveAbility(AbilityBase ability)
    {
        _abilitiesMap.Remove(ability.InputAction.action.id);
    }
    
    public void ToggleAbilities(bool toggle)
    {
        foreach (var (key, value) in _abilitiesMap)
        {
            value.enabled = toggle;
        }
    }

    public void ToggleAbility(string abilityName, bool toggle)
    {
        foreach (var value in _abilitiesMap.Values)
        {
            if (value.name == abilityName)
            {
                value.enabled = toggle;
            }
        }
    }

    public AbilityBase GetAbility(Guid abilityId)
    {
        foreach (var (key,value) in _abilitiesMap)
        {
            if (key == abilityId)
            {
                return value;
            }
        }

        return null;
    }

    public void UseAbility(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            AbilityBase ability = GetAbility(context.action.id);
            
            if (ability) {
                ability.UseAbility();
            }
        }

    }
    
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
}

