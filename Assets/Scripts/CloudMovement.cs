using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

	private float speed = 1f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.position = new Vector3(gameObject.transform.position.x - (speed * Time.deltaTime), gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
