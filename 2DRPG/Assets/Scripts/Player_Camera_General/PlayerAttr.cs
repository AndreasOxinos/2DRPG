using UnityEngine;
using System.Collections;

public class PlayerAttr : MonoBehaviour
{
    public int Health;
    public int Level;

    void Start()
    {
        Level = PlayerPrefs.GetInt("Level");  
        Health = PlayerPrefs.GetInt("Health");
    }

}
