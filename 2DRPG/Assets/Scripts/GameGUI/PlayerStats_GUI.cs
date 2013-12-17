using UnityEngine;
using System.Collections;

public class PlayerStats_GUI : MonoBehaviour {

    public UILabel lbl_health;
    public UILabel lbl_level;
    public UILabel lbl_name;

    private PlayerPrefsGetter getter = new PlayerPrefsGetter();


	void Start () 
    {
        lbl_health.text = "HP: " + getter.GetHealth().ToString();
        lbl_level.text = "Level:" + getter.GetLevel().ToString();
        lbl_name.text = getter.GetName();
    }
	
	void Update () 
    {
	
	}
}
