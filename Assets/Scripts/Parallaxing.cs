using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds; //Store environment sprites

    private float[] parallaxScale; //proportions

    public float ratio = 1f; //ratio of travel between sprites > 0

    private Transform camera; //new camera ref 
    private Vector3 previousCamPos; // store last camera position

    void Awake() // Before start function. Assigning references
    {
        camera = Camera.main.transform; // camera reference
    }
    // Use this for initialization
    
	void Start () 
    {
        previousCamPos = camera.position; 

        parallaxScale = new float[backgrounds.Length]; // proportions array

        for(int i = 0; i < backgrounds.Length; i++) // loop through proportions array
        {
            parallaxScale[i] = backgrounds[i].position.z * -1;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        for( int i = 0; i < backgrounds.Length; i++) // loop through backgrounds array
        {
            float parallax = (previousCamPos.x - camera.position.x) * parallaxScale[i]; //assign proportions to x position  

            float backgroundTargetPosX = backgrounds[i].position.x + parallax; //set final x position

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z); //set final vector (xyz) position of sprite 

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, ratio * Time.deltaTime); //sets to time not frames for variable frame rates

        }

        previousCamPos = camera.position; // assign current cam to previous, for next frame.
	}
}
