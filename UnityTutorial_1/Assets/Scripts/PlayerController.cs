using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Control
	public float speed;
	private string horiz = "Horizontal";
	private string vert = "Vertical";

	// Physics
	private Rigidbody rb;

	// Pick Ups
	private int count;
	public int maxPickUps;
	public Text countText;
	public Text winText;
	public List<string> pickUpTags;

	// Non-Control Transformations
	public float scaleFactor;

	void Start ()
	{
		// Rigid body
		rb = GetComponent<Rigidbody> ();

		// Pick Ups
		count = 0;
		SetCountText(0);
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
		float moveHorizontal = Input.GetAxis (horiz);
		float moveVertical = Input.GetAxis (vert);

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (pickUpTags.Contains (other.gameObject.tag))
		{
			// Make Pick Up disappear
			other.gameObject.SetActive (false);

			CollectPickUp ();
		}
	}
	
	void SetCountText(int count)
	{
		countText.text = "Count: " + count.ToString();
	}

	void ToggleWinText()
	{
		winText.enabled = !winText.enabled;
	}
		
	void CollectPickUp()
	{
		// Rigid body
		Grow();

		// Score counting
		count++;
		SetCountText (count);
		if (count >= maxPickUps) 
		{
			ToggleWinText ();
		}
	}

	void Grow()
	{
		rb.transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
	}
}
