using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public string toPrintClass = "Hello world as class variable";

	// Use this for initialization
	void Start () {
		string toPrint = "Hello World as a variable!";
		Debug.Log (toPrintClass);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
