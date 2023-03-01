using System;

public interface ICooldownable
{
    Guid CooldownId { get; }
    float CooldownDuration { get; }
}
