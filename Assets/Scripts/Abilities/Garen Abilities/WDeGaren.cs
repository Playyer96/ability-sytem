using UnityEngine;
using UnityEngine.InputSystem;

public class WDeGaren : AbilityBase, IActivable
{
    [SerializeField] private string _actionName;

    public string ActionName => _actionName;

    public override void Setup(Stats stats)
    {
        
    }

    public override void Ability()
    {
        Debug.LogError("Trigger W de garen");

    }
}