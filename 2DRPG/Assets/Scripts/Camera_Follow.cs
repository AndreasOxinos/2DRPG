using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour
{
	public Transform playerToFollow;

	void Start ()
	{
		playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update ()
	{

		var targetX  = Mathf.Lerp (transform.position.x, playerToFollow.position.x, 1 * Time.deltaTime);
		var targetY = Mathf.Lerp (transform.position.y, playerToFollow.position.y, 1 * Time.deltaTime);
		transform.position = new Vector3(targetX, targetY, transform.position.z);

	}
}
