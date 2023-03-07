using System;

public interface ICostable
{
    float Cost { get; }
    CostType CostType { get; }
    
    bool CanUseByCost { get; }

    public bool CheckhaveCurrency();

}
