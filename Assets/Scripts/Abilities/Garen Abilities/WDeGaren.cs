using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class WDeGaren : AbilityBase, IActivable, ICostable
{
    [SerializeField] private InputActionReference _abilityInput;

    public InputActionReference AbilityInput => _abilityInput;

    [SerializeField] private float cost;

    [SerializeField] private CostType costType;

    public float Cost => cost;
    public CostType CostType => costType;
    public bool CanUseByCost { get; private set; }

    public bool CheckhaveCurrency()
    {
        CanUseByCost = false;
     
        Stat outStat = new Stat();
        if (FindStat(costType.ToString(), ref outStat))
        {
            if (outStat.value >= Cost)
            {
                CanUseByCost = true;
                return CanUseByCost;
            }
        }

        return CanUseByCost;
    }

    public override void Setup(Stats stats)
    {
        Stat costStat = stats.GetStatByID(costType.ToString());
        if (string.IsNullOrEmpty(costStat.statId))
        {
            Debug.LogError($"{costType.ToString()} stat doesnt exist");
            return;
        }
        
        impactedStats.Add(costStat);
    }

    public override void Ability()
    {
        if (!CanUseByCost)
        {
            return;
        }
        
        Debug.LogError("Trigger W de garen");

        for (int i = 0; i < impactedStats.Count; i++)
        {
            if (impactedStats[i].statId == costType.ToString())
            {
                impactedStats[i].value -= cost;
            }
        }
    }
}