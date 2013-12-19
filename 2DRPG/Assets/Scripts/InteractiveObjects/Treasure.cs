using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.None;
    public string Name;
    Animator anim;
    bool opened;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        MakeTreasureNameCorrect();

        if (!PlayerPrefs.HasKey(Name))
        {
            opened = false;
            PlayerPrefs.SetString(Name, "NO");
        }

        string openedString = PlayerPrefs.GetString(Name);
        if (openedString == "NO")
        {
            opened = false;
            anim.SetBool("OpenedBefore", false);
        } 
        else if(openedString == "YES")
        {
            opened = true;
            anim.SetBool("OpenedBefore", true);
        }

    }
    
    void Update()
    {
    
    }



    void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKeyDown(keyCode) && !opened)
        {
            anim.SetTrigger("Open");
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (Input.GetKeyDown(keyCode))
        {
            anim.SetTrigger("Open");
            anim.SetBool("OpenedBefore", true);
            PlayerPrefs.SetString(Name, "YES");
        }
    }

    void MakeTreasureNameCorrect()
    {
        string treasureName = Application.loadedLevelName;
        Name = treasureName + ":Treasure_Small-" + Name;
    }


}

