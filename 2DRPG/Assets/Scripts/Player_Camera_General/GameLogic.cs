using UnityEngine;
using System.Collections;
//using UnityEditor;

public class GameLogic : MonoBehaviour
{
    private PlayerPrefsGetter getter = new PlayerPrefsGetter();

    void Start()
    {
        string SceneName = Application.loadedLevelName;
        PlayerPrefsSetter setter = new PlayerPrefsSetter();
        setter.SetPlayerScene(SceneName);


    }

    void OnGUI()
    {
        GUI.Label(new Rect(25, 20, 100, 30), "Level: " + getter.GetLevel().ToString());
        GUI.Label(new Rect(25, 40, 100, 30), "HP: " + getter.GetHealth().ToString());
        GUI.Label(new Rect(25, Screen.height - 25, 100, 30), "Name:" + getter.GetName());
    }

}
