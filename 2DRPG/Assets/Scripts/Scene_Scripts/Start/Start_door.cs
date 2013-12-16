using UnityEngine;
using System.Collections;

public class Start_door : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        Application.LoadLevel("0");
    }
}
