using UnityEngine;
using UnityEngine.InputSystem;

public class WDeGaren : AbilityBase, IActivable
{
    [SerializeField] private InputAction _abilityAction;

    public InputAction AbilityAction => _abilityAction;

    public override void Setup(Stats stats)
    {
        
    }

    public override void Ability()
    {
        Debug.LogError("Trigger W de garen");

    }
}