using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICooldownable
{
    int Id { get; }
    float CooldownDuration { get; }
}
