using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Player frame
	public Rigidbody playerBody;
	void Start() {
		playerBody = GetComponent<Rigidbody>();
	}

	// Movement Variables
	public float mvtMaxSpeed = 10.0f;
	public float mvtDir;


	// Use this for initialization
	void FixedUpdate () {
		// Move the player
		if (PlayerPrefs.GetInt("isTalking") == 0) {
			playerBody.velocity = new Vector2 (mvtDir * mvtMaxSpeed, playerBody.velocity.y);
		}

	}

	// Update is called once per frame
	void Update () {
		// Get Horizontal Direction
		mvtDir = Input.GetAxis("Horizontal");
	
	}
}
