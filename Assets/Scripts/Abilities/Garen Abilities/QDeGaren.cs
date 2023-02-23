using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class QDeGaren : AbilityBase, IActivable, ITickeable
{
    public event Action<ITickeable> OnActiveTick;
    public event Action<ITickeable> OnDisableTick;
    
    [SerializeField] private InputActionReference _abilityInput; 
    [SerializeField] private float _duration;
    
    public InputActionReference AbilityInput => _abilityInput;
    
    public float CurrentTime { get; private set; }
    public float Duration => _duration;

    public override void Setup(Stats stats)
    {
        Stat attackStat = stats.GetStatByID("Attack");
        if (string.IsNullOrEmpty(attackStat.statId))
        {
            Debug.LogError("Attack stat doesnt exist");
            return;
        }
        
        impactedStats.Add(attackStat);
    }

    public override void Ability()
    {
        Stat outStat = new Stat();
        if (FindStat("Attack", ref outStat))
        {
            IsActive = true;
            OnActiveTick?.Invoke(this);

            outStat.value *= 5;
            return;
        }
        
        Debug.LogError("Attack stat doesnt exist");
    }
    
    public void Tick(float deltaTime)
    {
        if (!IsActive)
        {
            return;
        }

        CurrentTime += deltaTime;
        
        if (CurrentTime > _duration)
        {
            Stat outStat = new Stat();
            if (FindStat("Attack", ref outStat))
            {
                IsActive = false;
                OnDisableTick?.Invoke(this);

                outStat.value /= 5;
            }
        }
    }
}
