using UnityEngine;
using System.Collections;

public class StairsDown : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        Application.LoadLevel("Start");
    }
}
