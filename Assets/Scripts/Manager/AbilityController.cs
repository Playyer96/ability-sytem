using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerInput))]
public class AbilityController : MonoBehaviour
{
    [SerializeField] private List<pasiveAbilityBase> _pasiveAbilities = new ();
    [SerializeField] private List<activeAbilityBase> _activeAbilities = new ();
    [SerializeField] private PlayerInput playerInput;

    public void ToggleAbilities(bool toggle)
    {
        foreach (var abilityMap in _activeAbilities)
        {
            abilityMap.enabled = toggle;
        }
    }

    public void ToggleAbility(string abilityName, bool toggle)
    {
        foreach (var abilityMap in _activeAbilities)
        {
            if (abilityMap.name == abilityName)
            {
                abilityMap.enabled = toggle;
            }
        }
    }

    public AbilityBase GetAbility(Guid abilityId)
    {
        foreach (var abilityMap in _activeAbilities)
        {
            if (abilityMap._abilityInput.action.id == abilityId)
            {
                return abilityMap;
            }
        }

        return null;
    }

    public void UseAbility(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            AbilityBase ability = GetAbility(context.action.id);
            
            if (ability) 
            {
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
        foreach (var ability in _activeAbilities)
        {
            foreach (var actionEvent in playerInput.actionEvents)
            {
                if (ability._abilityInput.action.id.ToString() == actionEvent.actionId)
                {
                    actionEvent.AddListener(UseAbility);
                }
            }
        }
    }

    private void OnValidate()
    {  
        for (int i = 0; i < _activeAbilities.Count; i++)
        {
            for (int j = 0; j < _activeAbilities.Count; j++)
            {
                if(i==j)
                {
                    continue;
                }

                if (!_activeAbilities[j] || !_activeAbilities[j]._abilityInput)
                {
                    Debug.LogError("You have some ability unassigned or a null InputAction at index: " + j);
                    return;
                }

                if (_activeAbilities[i]._abilityInput.action.id == _activeAbilities[j]._abilityInput.action.id)
                {
                    Debug.LogError("You can't assign same input to different abilities. Check InputAction in each ability");
                    return;
                }
            }
        }
    }
}

