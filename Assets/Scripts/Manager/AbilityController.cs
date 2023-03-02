using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class AbilityController : MonoBehaviour
{
    [SerializeField] private List<AbilityBase> _abilities;

    public List<AbilityBase> Abilities => _abilities;

    [SerializeField] private PlayerInput playerInput;

    private List<ITickeable> _tickeables = new();

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
        if (ability && ability is ICooldownable cooldownable) 
        {
            if (!CooldownManager.Instance.IsOnCooldown(cooldownable.CooldownId))
            {
                ability.Ability();
                return;
            }
            
            Debug.LogError("Ability is on cooldown");
        }
    }

    public void Setup(Stats stats)
    {
        foreach (var ability in _abilities)
        {
            if (ability is IActivable activable)
            {
                InputAction action = playerInput.actions.FindAction(activable.ActionName);

                if (action == null)
                {
                    Debug.LogError("Could not find the Ability with name: " + ability.AbilityName);
                    continue;
                }

                ability.AbilityId = action.id;
                
                action.started += delegate(InputAction.CallbackContext context)
                {
                    UseAbility(context,ability);
                };
            }

            if (ability is ITickeable tickeable)
            {
                tickeable.OnActiveTick += AddToTickables;
                tickeable.OnDisableTick += RemoveFromTickables;
            }

            if (ability.AbilityId == null)
            {
                ability.AbilityId = new Guid();
            }
            ability.Setup(stats);
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
                
                if (_abilities[j] is IActivable activable && string.IsNullOrEmpty(activable.ActionName))
                {
                    Debug.LogError("You have some ability with null InputAction at index: " + j);
                    return;
                }
    
                if (_abilities[i] is IActivable activableI && _abilities[j] is IActivable activableJ)
                {
                    if (activableI.ActionName == activableJ.ActionName)
                    {
                        Debug.LogError("You can't assign same input to different abilities. Check InputAction in each ability");
                        return;
                    }
                }
            }
        }
    }
}

