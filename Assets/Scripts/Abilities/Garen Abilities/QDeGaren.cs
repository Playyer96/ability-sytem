using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class QDeGaren : AbilityBase, IActivable, ITickeable, ICooldownable
{
    public event Action<ITickeable> OnActiveTick;
    public event Action<ITickeable> OnDisableTick;
    
    [SerializeField] private InputAction _abilityAction; 
    [SerializeField] private float _duration;
    [SerializeField] private float _cooldownDuration;

    public InputAction AbilityAction => _abilityAction;
    public float CurrentTime { get; private set; }
    public float Duration => _duration;
    public float CooldownDuration => _cooldownDuration;

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
            CooldownManager.Instance.PutOnCooldown(abilityId,_cooldownDuration);

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
                CurrentTime = 0;
                OnDisableTick?.Invoke(this);

                outStat.value /= 5;
            }
        }
    }
}
