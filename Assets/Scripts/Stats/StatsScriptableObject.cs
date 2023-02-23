using System;
using UnityEngine;

[Serializable]
public class Stat
{
    public string statId;
    public string nameToShow;
    public float value;

    public Stat(string statId = "", string nameToShow = "", float value = 0)
    {
        this.statId = statId;
        this.nameToShow = nameToShow;
        this.value = value;
    }
}

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/character Stats")]
public class StatsScriptableObject : ScriptableObject
{
    public Stat[] characterStats;
}
