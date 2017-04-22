using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour {

	public bool actionAvailable = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E)) {
			
		}



	}
		
	void OnTriggerEnter2D (Collider2D other) {
		actionAvailable = true;
		//PlayerPrefs.GetInt ("isTalking", 1);
	}

	void OnTriggerExit2D (Collider2D other) {
		actionAvailable = false;
		//PlayerPrefs.GetInt ("isTalking", 1);
	}
}
