using UnityEngine;
using UnityEngine.InputSystem;

public class QDeGaren : AbilityBase, IActivable, ITickeable
{
    [SerializeField] private InputActionReference _abilityInput; 
    [SerializeField] private float _duration;
    
    public InputActionReference AbilityInput => _abilityInput;
    private bool _isActive;
    private float _currentTime;

    public bool IsActive => _isActive;

    public float CurrentTime => _currentTime;

    public float Duration
    {
        get => _duration;
        set => _duration = value;
    }

    public override void Setup(StatsScriptableObject stats)
    {
        Stat attackStat = stats.GetStatByID("Attack");
        if (string.IsNullOrEmpty(attackStat.statId))
        {
            Debug.LogError("Attack stat doesnt exist");
            return;
        }
        
        impactedStats.Add(attackStat);
    }

    public override void UseAbility()
    {
        Ability();
    }

    public override void Ability()
    {
        Stat outStat = new Stat();
        if (FindStat("Attack", ref outStat))
        {
            _isActive = true;

            outStat.value *= 5;
            return;
        }
        
        Debug.LogError("Attack stat doesnt exist");
    }
    
    public void Tick(float deltaTime)
    {
        if (!_isActive)
        {
            return;
        }

        _currentTime += deltaTime;
        
        if (_currentTime > _duration)
        {
            Stat outStat = new Stat();
            if (FindStat("Attack", ref outStat))
            {
                _isActive = false;
        
                outStat.value /= 5;
            }
        }
    }

    private bool FindStat(string id, ref Stat outStat)
    {
        foreach (var stat in impactedStats)
        {
            if (stat.statId == id)
            {
                outStat = stat;
                return true;
            }
        }

        return false;
    }
}
