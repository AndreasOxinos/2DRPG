using UnityEngine;
using System.Collections;

public class PlayerStats_GUI : MonoBehaviour {

    public UILabel lbl_health;
    public UILabel lbl_level;
    public UILabel lbl_name;
    public UILabel lbl_points;
    public UILabel lbl_pointsGlobal;

    private PlayerPrefsGetter getter = new PlayerPrefsGetter();
    private EntityResponse<PlayerDTO> playerStats = new EntityResponse<PlayerDTO>();

	void Start () 
    {
        PlayerDAL dal = new PlayerDAL();
        playerStats =  dal.LoadPlayerData();

        if(playerStats.IsCallSuccessful)
        {
            lbl_health.text = "HP: " + playerStats.Data.HP.ToString();
            lbl_level.text = "Level:" + playerStats.Data.Level.ToString();
            lbl_name.text = getter.GetName();
            lbl_points.text = "Points:" + getter.GetPoints().ToString(); 
            lbl_pointsGlobal.text = "Points:" + getter.GetPoints().ToString();
        }


    }
	
	void Update () 
    {
        if(playerStats.IsCallSuccessful)
        {
            lbl_health.text = "HP: " + playerStats.Data.HP.ToString();
            lbl_level.text = "Level:" + playerStats.Data.Level.ToString();
            lbl_name.text = getter.GetName();
            lbl_points.text = "Points:" + getter.GetPoints().ToString(); 
            lbl_pointsGlobal.text = "Points:" + getter.GetPoints().ToString();
        }
	}


}
