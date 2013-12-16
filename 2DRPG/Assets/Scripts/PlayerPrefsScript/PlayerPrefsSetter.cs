using UnityEngine;
using System.Collections;

public class PlayerPrefsSetter
{
    public void SetPlayerScene(string sceneName)
    {
        PlayerPrefs.SetString("Scene", sceneName);
    }
}
