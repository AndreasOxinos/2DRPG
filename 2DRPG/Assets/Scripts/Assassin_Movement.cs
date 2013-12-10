using UnityEngine;
using System.Collections;

public class Assassin_Movement : MonoBehaviour
{
	public float SpeedX = 1.0f;
	public float SpeedY = 1.0f;
	public Animator anim;
	public string axisNameX = "Horizontal";
	public string axisNameY = "Vertical";
	private int previousTrigger;

	void Start ()
	{
		anim = gameObject.GetComponent<Animator> ();
	}
	
	void Update ()
	{
		if (IsOnTheGround ()) {
			CheckMoveX ();
			CheckMoveY ();
		}
	}

	void CheckMoveX ()
	{
		anim.SetFloat ("SpeedX", Input.GetAxis (axisNameX));
		if (Input.GetAxis (axisNameX) < 0) {
			Vector3 newScale = transform.localScale;
			//newScale.x = -1.0f;
			transform.localScale = newScale;
		} else if (Input.GetAxis (axisNameX) > 0) {
			Vector3 newScale = transform.localScale;
			//newScale.x = 1.0f;
			transform.localScale = newScale;
		}
		transform.position += transform.right * Input.GetAxis (axisNameX) * SpeedX * Time.deltaTime;
	}

	void CheckMoveY ()
	{
		anim.SetFloat ("SpeedY", Input.GetAxis (axisNameY));
		if (Input.GetAxis (axisNameY) < 0) {
			Vector3 newScale = transform.localScale;
			//newScale.x = -1.0f;
			transform.localScale = newScale;
		} else if (Input.GetAxis (axisNameY) > 0) {
			Vector3 newScale = transform.localScale;
			//newScale.x = 1.0f;
			transform.localScale = newScale;
		}
		transform.position += transform.up * Input.GetAxis (axisNameY) * SpeedY * Time.deltaTime;
	}

	//Need to check if we collide on the background.
	bool IsOnTheGround()
	{
		return true;
	}


}
