using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Player frame
	private Rigidbody2D playerBody;

	// Movement Variables
	public float mvtMaxSpeed = 6.0f;
	public float mvtDir;


	void Start() {
		playerBody = GetComponent<Rigidbody2D>();
	}

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
