using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITickeable
{
    void Tick(float deltaTime);
}
