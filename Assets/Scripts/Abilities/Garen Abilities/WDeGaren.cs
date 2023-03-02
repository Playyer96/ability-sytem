using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class WDeGaren : AbilityBase, IActivable, ICostable
{
    [SerializeField] private InputActionReference _abilityInput;

    public InputActionReference AbilityInput => _abilityInput;
    
    public float Cost { get; }
    public CostType CostType { get; }
    public bool CheckCanUse()
    {
        Stat outStat = new Stat();
        if (FindStat("Mana", ref outStat))
        {
            if (outStat.value > Cost)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public override void Setup(Stats stats)
    {
        Stat manaStat = stats.GetStatByID("Mana");
        if (string.IsNullOrEmpty(manaStat.statId))
        {
            Debug.LogError("Mana stat doesnt exist");
            return;
        }
        
        impactedStats.Add(manaStat);
    }

    public override void Ability()
    {
        Debug.LogError("Trigger W de garen");

    }

}