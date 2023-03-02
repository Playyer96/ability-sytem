using System;

public interface ICostable
{
    float Cost { get; }
    CostType CostType { get; }

    public bool CheckCanUse();

}

[Serializable]
public enum CostType
{
    Mana = 0,
}
