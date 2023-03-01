using UnityEngine;
using UnityEngine.InputSystem;

public class WDeGaren : AbilityBase, IActivable
{
    [SerializeField] private InputActionReference _abilityInput;

    public InputActionReference AbilityInput => _abilityInput;

    public override void Setup(Stats stats)
    {
        
    }

    public override void Ability()
    {
        Debug.LogError("Trigger W de garen");

    }
}