using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PassiveTest : AbilityBase, ITickeable
{
    public event Action<ITickeable> OnActiveTick;
    public event Action<ITickeable> OnDisableTick;
    
    [SerializeField] private float _timeToActive;

    private float healthValue;
    
    public float CurrentTime { get; private set; }

    public float TimeToActive { get; private set; }

    public override void Setup(Stats stats, Guid id)
    {
        base.Setup(stats,id);
        Stat stat = stats.GetStatByID("HealthRegen");
        if (string.IsNullOrEmpty(stat.statId))
        {
            Debug.LogError("HealthRegen stat doesnt exist");
            return;
        }
        
        impactedStats.Add(stat);
        
        Stat healthStat = stats.GetStatByID("Health");
        if (string.IsNullOrEmpty(healthStat.statId))
        {
            Debug.LogError("Health stat doesnt exist");
            return;
        }

        healthValue = healthStat.value;
        impactedStats.Add(healthStat);
        
        OnActiveTick?.Invoke(this);
    }

    public override void Ability(InputAction.CallbackContext context)
    {
        
    }
    
    public void Tick(float deltaTime)
    {
        Stat stat = new Stat();
        if (FindStat("Health", ref stat))
        {
            if (stat.value < healthValue)
            {
                CurrentTime = 0;
                healthValue = stat.value;
                return;
            }

            healthValue = stat.value;
            CurrentTime += deltaTime;
        }

        Stat outStat = new Stat();
        if (!FindStat("HealthRegen", ref outStat))
        {
            return;
        }
        
        if (CurrentTime > _timeToActive && !IsActive)
        {
            IsActive = true;

            outStat.value *= 2;
            return;
        }
        
        if(CurrentTime < _timeToActive && IsActive)
        {
            IsActive = false;

            outStat.value /= 2;
        }
    }
}
