using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Stat
{
    public string statId;
    public string nameToShow;
    public float value;
}

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/character Stats")]
public class StatsScriptableObject : ScriptableObject
{
    public Stat[] characterStats;
    private Stat returnStat;

    public Stat GetStatByID(string id)
    {
        returnStat = new Stat();
        for (int i = 0; i < characterStats.Length; i++)
        {
            if (characterStats[i].statId == id)
            {
                return characterStats[i];
            }
        }

        return returnStat;
    }
}
