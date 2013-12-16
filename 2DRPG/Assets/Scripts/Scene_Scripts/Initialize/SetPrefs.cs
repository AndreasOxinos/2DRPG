using UnityEngine;
using System.Collections;

public class SetPrefs : MonoBehaviour
{
    private GUISkin skin;
    private string txt_name = "";
    void Start()
    {

        skin = Resources.Load("myGuiSkin") as GUISkin;
        CheckName();
        CheckLevel();
        CheckHealth();
        CheckScene();

    }



    void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Health", 100);
        PlayerPrefs.SetString("Scene", "Start");
        PlayerPrefs.SetString("PlayerName", txt_name);
        LoadAppropriateScene();
    }

    void OnGUI () {
        GUI.skin = skin;

        if (GUI.Button (new Rect (35, 35, 150, 40), "New Game")) {
            NewGame();
        }

        txt_name = GUI.TextField (new Rect (250, 35, 100, 30), txt_name);

        if (GUI.Button (new Rect (35, 75, 150, 40), "Continue")) {
            LoadAppropriateScene();
        }
    }

    void CheckName()
    {
        if(!PlayerPrefs.HasKey("PlayerName"))
        {
            PlayerPrefs.SetString("PlayerName", txt_name);
        }
    }

    void CheckLevel()
    {
        if(!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
    }

    void CheckHealth()
    {
        if(!PlayerPrefs.HasKey("Health"))
        {
            PlayerPrefs.SetInt("Health", 100);
        }
    }

    void CheckScene()
    {
        if(!PlayerPrefs.HasKey("Scene"))
        {
            PlayerPrefs.SetString("Scene", "Start");
        }
    }

    void LoadAppropriateScene()
    {
        Application.LoadLevel(PlayerPrefs.GetString("Scene"));
    }
}
