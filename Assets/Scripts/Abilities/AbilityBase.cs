using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField] private string _abilityName;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    
    protected bool _isEnable;
    protected List<Stat> impactedStats = new();
    protected Guid abilityId;

    public string AbilityName => _abilityName; 
    public string Description  => _description;  
    public Sprite Icon  => _icon;  
    public bool IsEnable  => _isEnable;  
    public bool IsActive { get; protected set; }
    public Guid AbilityId { get => abilityId; set => abilityId = value; }

    public abstract void Setup(Stats stats);

    /// <summary>
    /// Here you need to write your ability code
    /// </summary>
    public abstract void Ability();

    protected virtual bool FindStat(string id, ref Stat outStat)
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
