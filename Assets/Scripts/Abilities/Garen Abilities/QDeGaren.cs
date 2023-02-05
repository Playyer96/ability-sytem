using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QDeGaren : AbilityBase, IActivable
{
    [SerializeField] private InputActionReference _abilityInput;

    public InputActionReference AbilityInput => _abilityInput;

    public override void UseAbility()
    {
        Debug.LogError("Trigger Q de garen");
    }

    public override void Ability()
    {
        
    }
}
