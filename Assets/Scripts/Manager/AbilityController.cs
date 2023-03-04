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

    public void UseAbility(AbilityBase ability)
    {
        if (ability) 
        {
            if (ability is ICooldownable)
            {
                if (CooldownManager.Instance.IsOnCooldown(ability.AbilityId))
                {
                    Debug.LogError("Ability is not ready");
                    return;
                }
                
            }
            ability.Ability();
        }
    }

    public void Setup(Stats stats)
    {
        foreach (var ability in _abilities)
        {
            if (ability is IActivable activable)
            {
                if (activable.AbilityActionIndex >= AbilityActions.Count)
                {
                    Debug.LogError("Ability Action Index is greater than the amount of defined abilities");
                    continue;
                }

                var action = AbilityActions[(int)activable.AbilityActionIndex];
                
                ability.AbilityId = action.id;
                
                action.started += delegate { UseAbility(ability); };
            }

            if (ability is ITickeable tickeable)
            {
                tickeable.OnActiveTick += AddToTickables;
                tickeable.OnDisableTick += RemoveFromTickables;
            }

            if (ability.AbilityId == Guid.Empty)
            {
                ability.AbilityId = new Guid();
            }
            
            ability.Setup(stats);
        }
    }

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _inputMaster.AbilitySystem.Enable();
        
        //_inputMaster.AbilitySystem.SetCallbacks(this);
    }

    private void AddToTickables(ITickeable tickeable)
    {
        _tickeables.Add(tickeable);
    }

    private void RemoveFromTickables(ITickeable tickeable)
    {
        _tickeables.Remove(tickeable);
    }

    private void Update()
    {
        for(int i = _tickeables.Count - 1; i >= 0; i--)
        {
            _tickeables[i].Tick(Time.deltaTime);
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

    public void OnFirstAbility(InputAction.CallbackContext context)
    {
        var ability = FindAbilityByActionIndex(0);
        if (ability != null)
        {
            if (!IsAbilityInCooldown(ability))
            {
                ability.Ability();
            }
        }
    }

    public void OnSecondAbility(InputAction.CallbackContext context)
    {
        var ability = FindAbilityByActionIndex(1);
        if (ability != null)
        {
            if (!IsAbilityInCooldown(ability))
            {
                ability.Ability();
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

    private AbilityBase FindAbilityByActionIndex(int actionIndex)
    {
        foreach (var ability in _abilities)
        {
            if (ability is IActivable activable)
            {
                if (activable.AbilityActionIndex == actionIndex)
                {
                    return ability;
                }
            }
        }

        return null;
    }

    private static bool IsAbilityInCooldown(AbilityBase ability)
    {
        return ability is ICooldownable && CooldownManager.Instance.IsOnCooldown(ability.AbilityId);
    }
}

