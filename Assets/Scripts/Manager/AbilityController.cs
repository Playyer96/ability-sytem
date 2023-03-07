using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class AbilityController : MonoBehaviour, InputMaster.IAbilitySystemActions
{
    [SerializeField] private List<AbilityBase> _abilities;
    public List<AbilityBase> Abilities => _abilities;

    private List<ITickeable> _tickeables = new();
    private InputMaster _inputMaster;
    private ReadOnlyArray<InputAction> AbilityActions => _inputMaster.AbilitySystem.Get().actions;

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

    public void Setup(Stats stats, InputMaster inputMaster)
    {
        _inputMaster = inputMaster;
        _inputMaster.AbilitySystem.SetCallbacks(this);
        
        foreach (var ability in _abilities)
        {
            Guid abilityId = Guid.Empty;
            
            if (ability is IActivable activable)
            {
                abilityId = AbilityActions[activable.AbilityActionIndex].id;
            }

            if (ability is ITickeable tickeable)
            {
                tickeable.OnActiveTick += AddToTickables;
                tickeable.OnDisableTick += RemoveFromTickables;
            }

            if (abilityId == Guid.Empty)
            {
                abilityId = new Guid();
            }
            
            ability.Setup(stats, abilityId);
        }
    }

    private void Update()
    {
        for(int i = _tickeables.Count - 1; i >= 0; i--)
        {
            _tickeables[i].Tick(Time.deltaTime);
        }
    }

    private void AddToTickables(ITickeable tickeable)
    {
        _tickeables.Add(tickeable);
    }

    private void RemoveFromTickables(ITickeable tickeable)
    {
        _tickeables.Remove(tickeable);
    }
    
    private AbilityBase FindAbilityById(Guid actionId)
    {
        foreach (var ability in _abilities)
        {
            if (ability.AbilityId == actionId)
            {
                return ability;
            }
        }

        return null;
    }

    private static bool IsAbilityInCooldown(AbilityBase ability)
    {
        return ability is ICooldownable && CooldownManager.Instance.IsOnCooldown(ability.AbilityId);
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

                if (_abilities[i] is IActivable activableI && _abilities[j] is IActivable activableJ)
                {
                    if (activableI.AbilityActionIndex == activableJ.AbilityActionIndex)
                    {
                        Debug.LogError("You can't assign same input to different abilities. Check InputActionIndex in each ability");
                        return;
                    }
                }
            }
        }
    }

    public void CheckCosts()
    {
        foreach (var ability in _abilities)
        {
            if (ability is ICostable costable)
            {
             costable.CheckHaveCurrency();
            }
        }
    }
    
    // INTERFACE IMPLEMENTATIONS

    public void OnFirstAbility(InputAction.CallbackContext context)
    {
        var ability = FindAbilityById(_inputMaster.AbilitySystem.FirstAbility.id);
        if (ability != null)
        {
            if (!IsAbilityInCooldown(ability))
            {
                ability.Ability(context);
            }
        }
    }

    public void OnSecondAbility(InputAction.CallbackContext context)
    {
        var ability = FindAbilityById(_inputMaster.AbilitySystem.SecondAbility.id);
        if (ability != null)
        {
            if (!IsAbilityInCooldown(ability))
            {
                ability.Ability(context);
            }
        }
    }

    public void OnThirdAbility(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnFourthAbility(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}

