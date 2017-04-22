using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour {

	public bool actionAvailable = false;
	private Transform marker;

	// Use this for initialization
	void Start () {
		marker = this.transform.Find("ActionAvailableMarker");
		marker.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		// something to interact with
		if (actionAvailable) {
			
			if (Input.GetKeyDown (KeyCode.E)) {
				
			}

		}

	}
		
	void OnTriggerEnter2D (Collider2D other) {
		actionAvailable = true;
		marker.GetComponent<Renderer>().enabled = true;
		//PlayerPrefs.GetInt ("isTalking", 1);
	}

	void OnTriggerExit2D (Collider2D other) {
		actionAvailable = false;
		marker.GetComponent<Renderer>().enabled = false;
		//PlayerPrefs.GetInt ("isTalking", 1);
	}
}
