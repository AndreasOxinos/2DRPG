using UnityEngine;
using System.Collections;

public class PlayerPrefsGetter
{
    public int GetLevel()
    {
        return PlayerPrefs.GetInt("Level");
    }

    public int GetHealth()
    {
        return PlayerPrefs.GetInt("Health");
    }

    public string GetName()
    {
        return PlayerPrefs.GetString("PlayerName");
    }

    public int GetPoints()
    {
        return PlayerPrefs.GetInt("Points");
    }
}
