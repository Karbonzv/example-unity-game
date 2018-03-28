using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

//	public string toPrintClass = "Hello world as class variable";
	public float speed = 2;
	public float health = 100;
	public float invulnerableDuration = 1;
	public float blinkDuration = 0.5f;
	private float invulnerableEndTime = 0;
	public float blinkEndTime = 0;
	public float jumpSpeed = 5;
	//private float hasDoubleJummped = false;
	public int allowedAirJumps = 0;
	private int numAirJumps = 0;
	// Use this for initialization
	void Start () {
		//damage (5);


		//string toPrint = "Hello World as a variable!";
		//Debug.Log (toPrintClass);
		//string returned1 = TestFunction ("TestFunction message variable", 1);
		//string returned2 = TestFunction ("TestFunction message variable", 2);
		//Debug.Log ("returned1 = " + returned1);
		//Debug.Log ("returned2 = " + returned2);
	}

	// Update is called once per frame
	void Update () {
		Rigidbody2D ourRigidBody = GetComponent<Rigidbody2D> ();
	
		// get the horizontal input (left/right arrows) between -1 and 1
		float horizontal = Input.GetAxis ("Horizontal");

		//get curent velocity from physics system
		Vector2 velocity = ourRigidBody.velocity;

		// set velocity based on input and speed value
		velocity.x = horizontal * speed;

		// get a reference to our animator
		Animator ourAnimator = GetComponent<Animator>();

		// determin what animator speed variable should be set to
		float animatorSpeed = Mathf.Abs(velocity.x);

		//set this value on the animator

		ourAnimator.SetFloat ("speed", animatorSpeed);

		// determine if touching ground
		//get collide atachd to ground
		Collider2D ourCollider = GetComponent<Collider2D>();

		// get the layermask for the ground layer - we need this for the function cell
		LayerMask groundLayer = LayerMask.GetMask("Ground");

		// ask the collider if we are touching this layer
		bool isTouchingGround = ourCollider.IsTouchingLayers(groundLayer);

		// set touching ground peramator on the animator
		ourAnimator.SetBool("TouchingGround", isTouchingGround);

		// if we are touching gounf we need to reset doubl jump
		if (isTouchingGround == true) {
			//hasDoubleJummped
			numAirJumps = 0;
		}

		bool allowedToJump = isTouchingGround;

			if (isTouchingGround == false && numAirJumps < allowedAirJumps)
			allowedToJump = true;




		//jump logic
		bool jumpPressed = Input.GetButtonDown("Jump");

		if (jumpPressed == true && allowedToJump == true) {
			//apply jump tp velocity
			velocity.y = jumpSpeed;
		}

		// put this velocity back into the physics system
		ourRigidBody.velocity = velocity;



		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		// flip the sprite on the x axis if velocity x is less than 0
		renderer.flipX = velocity.x < 0;


		if (Time.time >= invulnerableEndTime) { 

			renderer.enabled = true;

		} else {

			if (Time.time >= blinkEndTime) {

				renderer.enabled = !renderer.enabled;

				blinkEndTime = Time.time + blinkDuration;

			}
		}

//		// mouse tests
//		// check if left mouse has been pressed this frame
//		if (Input.GetMouseButtonDown (0) == true) {
//			Debug.Log ("Mouse left button pressed down");
//		}
//		if (Input.GetMouseButton (0) == true) {
//			Debug.Log ("Mouse left button held");
//		}
//		if (Input.GetMouseButtonUp (0) == true) {
//			Debug.Log ("Mouse left button has been released");
//		}
//		if (Input.GetMouseButtonDown (1) == true) {
//			Debug.Log ("Mouse right button pressed down");
//		}
//		Debug.Log ("Mouse position = " + Input.mousePosition);
//

	}


	//string TestFunction (string message, int count) {
	//	Debug.Log (message + " " + count);

		//return "Returned string";

	public void damage (float damageToDeal)
	{
		if (Time.time >= invulnerableEndTime) {

			// reducing health by damage passed in
			health = health - damageToDeal;

			//TODO: handle death

			// set us as invulnerable for a set duration
			invulnerableEndTime = Time.time + invulnerableDuration;

			// log the result of function
			Debug.Log ("Damage was dealt");
			Debug.Log ("DamageToDo = " + damageToDeal);
			Debug.Log ("health = " + health);
		}
	} // end damage()

}
