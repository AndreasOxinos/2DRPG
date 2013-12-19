using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour
{
    public int points = 100;
    public int gold = 10;

    public string GemName;

    PlayerPrefsSetter setter = new PlayerPrefsSetter();

    void Start()
    {
        MakeGemNameCorrect();
        if(!PlayerPrefs.HasKey(GemName))
        {
            PlayerPrefs.SetString(GemName, "YES");
        }

        string showIt = PlayerPrefs.GetString(GemName);
        if(showIt == "NO")
        {
            Destroy(gameObject);
        }
    }

    void MakeGemNameCorrect()
    {
        string SceneName = Application.loadedLevelName;
        GemName = SceneName + ":GEM-" + GemName;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            setter.GivePlayerPoints(points);
            Destroy(gameObject);
            PlayerPrefs.SetString(GemName, "NO");
        }
    }
}
