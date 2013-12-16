using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform playerToFollow;

	private Vector3 initialOffset;

	// Use this for initialization
	void Start ()
	{
        //initialOffset = transform.position - playerToFollow.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
        if (playerToFollow == null)
        {
            playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
        }
        transform.position = playerToFollow.position;// + initialOffset;
	}
}
