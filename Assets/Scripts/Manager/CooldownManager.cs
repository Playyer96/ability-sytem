using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : Singleton<CooldownManager>
{
    public class CooldownData
    {
        public int Id { get; }
        public float RemainingTime { get; private set; }

        public CooldownData(ICooldownable cooldown)
        {
            Id = cooldown.Id;
            RemainingTime = cooldown.CooldownDuration;
        }

        public bool DecrementCooldown(float deltaTime)
        {
            RemainingTime = Mathf.Max(RemainingTime - deltaTime, 0);

            return RemainingTime == 0;
        }
    }
    
    private readonly List<CooldownData> _cooldowns = new List<CooldownData>();
    
    public void PutOnCooldown(ICooldownable cooldown)
    {
        _cooldowns.Add(new CooldownData(cooldown));
    }
    
    public bool IsOnCooldown(int id)
    {
        foreach (var cooldown in _cooldowns)
        {
            if (cooldown.Id == id)
            {
                return true;
            }
        }

        return false;
    }
    
    public float GetRemainingDuration(int id)
    {
        foreach (var cooldown in _cooldowns)
        {
            if (cooldown.Id != id)
            {
                continue;
            }

            return cooldown.RemainingTime;
        }

        return 0f;
    }
    
    private void Update()
    {
        ProcessCooldowns();
    }

    private void ProcessCooldowns()
    {
        float deltaTime = Time.deltaTime;

        for (int i = _cooldowns.Count - 1; i >= 0; i--)
        {
            if(_cooldowns[i].DecrementCooldown(deltaTime))
            {
                _cooldowns.RemoveAt(i);
            }
        }
    }
}
