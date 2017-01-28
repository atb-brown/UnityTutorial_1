using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Control
	public float speed;

	// Physics
	private Rigidbody rb;

	// Count of number of pick ups
	private int count;
	public Text countText;
	public Text winText;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText();
		winText.enabled = false;
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

	void OnTriggerEnter(Collider other) {
		// Destroy(other.gameObject);
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.enabled = true;
		}
	}
}
