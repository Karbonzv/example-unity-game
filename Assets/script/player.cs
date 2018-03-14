using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

//	public string toPrintClass = "Hello world as class variable";
	public float speed = 2;
	public float health = 100;
	public float invulnerableDuration = 1;

		private float invulnerableEndTime = 0;

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
		float speed = 2;
		ourRigidBody.velocity = Vector2.right * speed;
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
