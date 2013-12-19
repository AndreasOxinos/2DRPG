using UnityEngine;
using System.Collections;

public class PlayerStats_GUI : MonoBehaviour {

    public UILabel lbl_health;
    public UILabel lbl_level;
    public UILabel lbl_name;
    public UILabel lbl_points;
    public UILabel lbl_pointsGlobal;

    private PlayerPrefsGetter getter = new PlayerPrefsGetter();


	void Start () 
    {
        lbl_health.text = "HP: " + getter.GetHealth().ToString();
        lbl_level.text = "Level:" + getter.GetLevel().ToString();
        lbl_name.text = getter.GetName();
        lbl_points.text = "Points:" + getter.GetPoints().ToString(); 
        lbl_pointsGlobal.text = "Points:" + getter.GetPoints().ToString();
    }
	
	void Update () 
    {
        lbl_health.text = "HP: " + getter.GetHealth().ToString();
        lbl_level.text = "Level:" + getter.GetLevel().ToString();
        lbl_name.text = getter.GetName();
        lbl_points.text = "Points:" + getter.GetPoints().ToString(); 
        lbl_pointsGlobal.text = "Points:" + getter.GetPoints().ToString();
	}
}
