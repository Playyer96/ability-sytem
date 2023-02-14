using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class AbilityController : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> _abilities;
    [SerializeField] private PlayerInput playerInput;

    public void ToggleAbilities(bool toggle)
    {
        foreach (var ability in _abilities)
        {
            ability.enabled = toggle;
        }
    }

    public void ToggleAbility(string abilityName, bool toggle)
    {
        foreach (var ability in _abilities)
        {
            if (ability.name == abilityName)
            {
                ability.enabled = toggle;
            }
        }
    }

    public void UseAbility(InputAction.CallbackContext context, AbilityBase ability)
    {
        if (context.started) 
        {
            if (ability) 
            {
                ability.UseAbility();
            }
        }
    }

    public void Setup(StatsScriptableObject stats)
    {
        foreach (var ability in _abilities)
        {
            foreach (var actionEvent in playerInput.actionEvents)
            {
                if (ability is IActivable activable)
                {
                    if (activable.AbilityInput.action.id.ToString() == actionEvent.actionId)
                    {
                        ability.Setup(stats);
                        actionEvent.AddListener(
                            delegate(InputAction.CallbackContext context)
                            {
                                UseAbility(context,ability);
                            });
                    }
                }
                else
                {
                    // Here we need to trigger the passive, BUT how do we do that without any context?
                }
            }
        }
    }

    private void OnValidate()
    {
        EditorUtility.SetDirty(this);
        for (int i = 0; i < _abilities.Count; i++)
        {
            for (int j = 0; j < _abilities.Count; j++)
            {
                if(i==j)
                {
                    continue;
                }
    
                if (!_abilities[j])
                {
                    Debug.LogError("You have some ability unassigned at index: " + j);
                    return;
                }
                
                if (_abilities[j] is IActivable activable && !activable.AbilityInput)
                {
                    Debug.LogError("You have some ability with null InputAction at index: " + j);
                    return;
                }
    
                if (_abilities[i] is IActivable activableI && _abilities[j] is IActivable activableJ)
                {
                    if (activableI.AbilityInput.action.id == activableJ.AbilityInput.action.id)
                    {
                        Debug.LogError("You can't assign same input to different abilities. Check InputAction in each ability");
                        return;
                    }
                }
            }
        }
    }
}

