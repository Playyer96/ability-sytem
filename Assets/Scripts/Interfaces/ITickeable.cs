public interface ITickeable
{
    bool IsActive { get; set; }
    float CurrentTime { get; set; }
    float Duration { get; set; }
    void Tick(float deltaTime);
}
