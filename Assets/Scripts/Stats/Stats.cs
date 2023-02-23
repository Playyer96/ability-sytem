using System;
using System.Collections.Generic;

[Serializable]
public class Stats
{
    private List<Stat> characterStats = new List<Stat>();

    public Stats(StatsScriptableObject stats)
    {
        for (int i = 0; i < stats.characterStats.Length; i++)
        {
            Stat currentStat = stats.characterStats[i];
            characterStats.Add(new Stat(currentStat.statId, currentStat.nameToShow, currentStat.value));
        }
    }

    public Stat GetStatByID(string id)
    {
        Stat returnStat = new Stat();
        for (int i = 0; i < characterStats.Count; i++)
        {
            if (characterStats[i].statId == id)
            {
                return characterStats[i];
            }
        }
        return returnStat;
    }

}