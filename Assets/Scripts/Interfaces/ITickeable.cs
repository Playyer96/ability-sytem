using System;

public interface ITickeable
{
    float CurrentTime { get; }
    void Tick(float deltaTime);
    public event Action<ITickeable> OnActiveTick;
    public event Action<ITickeable> OnDisableTick;
}
