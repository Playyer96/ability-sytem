using System;

public interface ITickeable
{
    bool IsActive { get; }
    float CurrentTime { get; }
    float Duration { get; set; }
    void Tick(float deltaTime);
}
