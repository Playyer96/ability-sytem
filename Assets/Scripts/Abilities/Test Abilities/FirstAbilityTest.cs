using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstAbilityTest : AbilityBase, IActivable, ITickeable, ICooldownable
{
    public event Action<ITickeable> OnActiveTick;
    public event Action<ITickeable> OnDisableTick;
    
    [SerializeField] private float _duration;
    [SerializeField] private float _cooldownDuration;
    
    [HideInInspector] public int _abilityAction; 

    public int AbilityActionIndex => _abilityAction;
    public float CurrentTime { get; private set; }
    public float Duration => _duration;
    public float CooldownDuration => _cooldownDuration;

    public override void Setup(Stats stats, Guid id)
    {
        base.Setup(stats,id);
        Stat attackStat = stats.GetStatByID("Attack");
        if (string.IsNullOrEmpty(attackStat.statId))
        {
            Debug.LogError("Attack stat doesnt exist");
            return;
        }
        
        impactedStats.Add(attackStat);
    }

    public override void Ability(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Stat outStat = new Stat();
            if (FindStat("Attack", ref outStat))
            {
                IsActive = true;
                OnActiveTick?.Invoke(this);
                CooldownManager.Instance.PutOnCooldown(abilityId, _cooldownDuration);

                outStat.value *= 5;
                return;
            }

            Debug.LogError("Attack stat doesnt exist");
        }
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
