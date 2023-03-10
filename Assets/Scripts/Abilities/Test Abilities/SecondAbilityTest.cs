using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondAbilityTest : AbilityBase, IActivable, ICostable
{
    [HideInInspector][SerializeField] private int _abilityAction;

    [SerializeField] private float cost;
    [SerializeField] private CostType costType;
    public float Cost => cost;
    public CostType CostType => costType;
    public int AbilityActionIndex => _abilityAction;
    public bool CanUseByCost { get; private set; }

    public bool CheckHaveCurrency()
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

    public override void Setup(Stats stats, Guid id)
    {
        base.Setup(stats,id);
        Stat costStat = stats.GetStatByID(costType.ToString());
        if (string.IsNullOrEmpty(costStat.statId))
        {
            Debug.LogError($"{costType.ToString()} stat doesnt exist");
            return;
        }
        
        impactedStats.Add(costStat);
    }

    public override void Ability(InputAction.CallbackContext context)
    {
        if (context.started)
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
}