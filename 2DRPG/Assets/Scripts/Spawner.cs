using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    
    void Start()
    {
        GameObject player = (GameObject)Instantiate(Resources.Load("Player"));


       // var player = GameObject.FindGameObjectWithTag("Player");
        var spawner = GameObject.FindGameObjectWithTag("Spawner").transform;
        Vector3 position = new Vector3(spawner.position.x, spawner.position.y, player.transform.position.z);
        player.transform.position = position;
    }
    
    void Update()
    {
      //  player.transform.position = GameObject.FindGameObjectWithTag("Spawner").transform.position;    
    }
}
