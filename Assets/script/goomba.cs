using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goomba : MonoBehaviour {
	
	// public variables visible to editor
	public float damage = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// called when trigger collides with another collider 
	void OnTriggerStay2D(Collider2D other)
	{
		// attempting to get script from object collided with
		player playerscript = other.GetComponent<player> ();

		// if player script exits with object collded with
		if (playerscript != null) {
			// call damage function on player script and pas damage amount
			playerscript.damage (damage);

			Debug.Log ("Goomba dealt damage to player = " + damage);
		} // end if (playerscript != null)
	}// end ontrigger2D()
}
