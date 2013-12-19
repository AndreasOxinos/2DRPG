using UnityEngine;
using System.Collections;

public class PlayerPrefsSetter
{
    public void SetPlayerScene(string sceneName)
    {
        PlayerPrefs.SetString("Scene", sceneName);
    }

    public void GivePlayerPoints(int points)
    {
        int currentPoints = PlayerPrefs.GetInt("Points");
        PlayerPrefs.SetInt("Points", currentPoints + points);
    }
}
