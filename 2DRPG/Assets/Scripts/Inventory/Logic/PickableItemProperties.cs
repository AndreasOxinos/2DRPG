using UnityEngine;
using System.Collections;

[System.Serializable]
public class PickableItemProperties

{
    //Properties of a single object in the inventory
    public string id;
    public string name;
    public string description;
    public WeaponType type;
    public Texture2D icon;
    public GameObject player;
    public int count;


}
