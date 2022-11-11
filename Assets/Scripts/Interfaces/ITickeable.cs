using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITickeable
{
    public void Tick(float deltaTime);
}
