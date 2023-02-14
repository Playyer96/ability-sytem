using UnityEngine;
using UnityEngine.InputSystem;

public class QDeGaren : AbilityBase, IActivable, ITickeable //IDynamic stat
{
    [SerializeField] private InputActionReference _abilityInput;
    public InputActionReference AbilityInput => _abilityInput;
    public bool IsActive { get; set; }
    public float CurrentTime { get; set; }
    public float Duration { get; set; }

    public override void Setup(StatsScriptableObject stats)
    {
        this.stats = stats;
    }

    public override void UseAbility()
    {
        Ability();
    }

    public override void Ability()
    {
        Stat attackStat = stats.GetStatByID("Attack");
        if (string.IsNullOrEmpty(attackStat.statId))
        {
            Debug.LogError("Attack stat doesnt exist");
            return;
        }

        IsActive = true;
        
        attackStat.value *= 5;
    }
    
    public void Tick(float deltaTime)
    {
        if (!IsActive)
        {
            return;
        }
    }
}
