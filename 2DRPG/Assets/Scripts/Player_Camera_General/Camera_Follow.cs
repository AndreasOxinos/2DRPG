using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour
{
    private Transform playerToFollow;

    void LateUpdate()
    {
        if (playerToFollow == null)
        {
            playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
        }
        //var targetX = Mathf.Lerp(transform.position.x, playerToFollow.position.x, 1 * Time.deltaTime);
        //var targetY = Mathf.Lerp(transform.position.y, playerToFollow.position.y, 1 * Time.deltaTime);
        //transform.position = new Vector3(targetX, targetY, transform.position.z);
        transform.position = new Vector3(playerToFollow.transform.position.x, playerToFollow.transform.position.y, transform.position.z);

    }
}
