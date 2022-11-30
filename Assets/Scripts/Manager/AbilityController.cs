using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class AbilityController : MonoBehaviour
{
    [Serializable]
    public struct AbilityMap
    {
        public AbilityBase _ability;
        public InputActionReference _abilityInput;
    }
    
    [SerializeField] private List<AbilityMap> _abilities = new List<AbilityMap>();
    [SerializeField] private PlayerInput playerInput;

    public void ToggleAbilities(bool toggle)
    {
        foreach (var abilityMap in _abilities)
        {
            abilityMap._ability.enabled = toggle;
        }
    }

    public void ToggleAbility(string abilityName, bool toggle)
    {
        foreach (var abilityMap in _abilities)
        {
            if (abilityMap._ability.name == abilityName)
            {
                abilityMap._ability.enabled = toggle;
            }
        }
    }

    public AbilityBase GetAbility(Guid abilityId)
    {
        foreach (var abilityMap in _abilities)
        {
            if (abilityMap._abilityInput.action.id == abilityId)
            {
                return abilityMap._ability;
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
        for (int i = 0; i < _abilities.Count; i++)
        {
            for (int j = 0; j < _abilities.Count; j++)
            {
                if(i==j)
                {
                    continue;
                }

                if (!_abilities[j]._ability || !_abilities[j]._abilityInput)
                {
                    Debug.LogError("You have some ability unassigned or a null InputAction at index: " + j);
                    return;
                }

                if (_abilities[i]._abilityInput.action.id == _abilities[j]._abilityInput.action.id)
                {
                    Debug.LogError("You can't assign same input to different abilities. Check InputAction in each ability");
                    return;
                }
            }
        }
    }
}

