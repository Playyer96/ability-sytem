using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : Singleton<CooldownManager>
{
    private readonly List<CooldownData> _cooldowns = new List<CooldownData>();

    private void Update() => ProcessCooldowns();

    public void PutOnCooldown(ICooldownable cooldown)
    {
        _cooldowns.Add(new CooldownData(cooldown));
    }

    public bool IsOnCooldown(int id)
    {
        foreach (var cooldown in _cooldowns)
        {
            if(cooldown.Id == id) { return true; }
        }

        return false;
    }

    public float GetRemainingDuration(int id)
    {
        foreach (var cooldowm in _cooldowns)
        {
            if(cooldowm.Id != id) { continue; }

            return cooldowm.RemainingTime;
        }

        return 0f;
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
