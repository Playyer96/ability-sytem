using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityController : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> _abilities = new List<AbilityBase>();
    [SerializeField] private PlayerInput playerInput;
    private readonly Dictionary<InputActionReference, AbilityBase> _abilitiesMap = new Dictionary<InputActionReference, AbilityBase>();


    public void AddAbility(AbilityBase ability)
    {
        _abilitiesMap.Add(ability.InputAction, ability);
    }

    public void RemoveAbility(AbilityBase ability)
    {
        _abilitiesMap.Remove(ability.InputAction);
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

    public AbilityBase GetAbility(InputActionReference abilityName)
    {
        foreach (var value in _abilitiesMap.Values)
        {
            if (value.InputAction == abilityName)
            {
                return value;
            }
        }

        return null;
    }

    public void UseAbility(InputActionReference abilityKey, InputAction.CallbackContext context)
    {
        if (context.started) 
        {

            AbilityBase ability = GetAbility(abilityKey);

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

