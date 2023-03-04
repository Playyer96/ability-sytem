using UnityEngine;
using UnityEngine.InputSystem;

public class WDeGaren : AbilityBase, IActivable
{
    [HideInInspector][SerializeField] private uint _abilityAction;

    public uint AbilityActionIndex => _abilityAction;

    public override void Setup(Stats stats)
    {
        
    }

    public override void Ability()
    {
        Debug.LogError("Trigger W de garen");

    }
}