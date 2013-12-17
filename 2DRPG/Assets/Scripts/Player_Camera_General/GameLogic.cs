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



}
