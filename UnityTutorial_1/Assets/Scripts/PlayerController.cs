using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	// Called before rendering a frame
	void Update ()
	{

	}

	// Called before calculating any physics calculations
	// Moving a rigidbody is a physics update
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}
}
