using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondActiveTest : AbilityBase, IActivable
{
    [HideInInspector][SerializeField] private int _abilityAction;

    public int AbilityActionIndex => _abilityAction;

    public override void Setup(Stats stats, Guid id)
    {
        base.Setup(stats,id);
    }

    public override void Ability(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.LogError("Trigger W de garen started");
        }

        if (context.performed)
        {
            Debug.LogError("Trigger W de garen performed");
        }
        if (context.canceled)
        {
            Debug.LogError("Trigger W de garen canceled");
        }
    }
}