using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2; //offset generation check

	public bool hasRightSprite = false; //check if right texture
	public bool hasLeftSprite = false; //check if left texture

	//public bool reverseScale = false; tilable? not used

	private float spriteWidth = 0f; //Width of sprite element
	private Camera cam;
	private Transform myTransform;

	void MakeNewSprite(int rightOrLeft)
	{
		Vector3 newPos = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z); //calculate new pos for sprite
		Transform newSprite = Instantiate (myTransform, newPos, myTransform.rotation) as Transform; //instantiate new sprite in variable

		//if(reversedScale == true)
		//{
		//	newSprite.localScale = new Vector3 (newSprite.localScale.x*-1, newSprite.localScale.y, newSprite.localScale.z);
		//}

		newSprite.parent = myTransform.parent;

		if (rightOrLeft > 0) 
		{
			newSprite.GetComponent<Tiling> ().hasLeftSprite = true;
		} else 
		{
			newSprite.GetComponent<Tiling> ().hasRightSprite = true;
		}
	}

	void Awake()
	{
		cam = Camera.main;
		myTransform = transform;
	}
	// Use this for initialization
	void Start () 
	{
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(hasRightSprite == false || hasLeftSprite == false)
		{
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height; //calculate cam's half width of cam seen
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth/2) - camHorizontalExtend; //calculate x pos at cam edge right
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth/2) + camHorizontalExtend; //calculate x pos at cam edge left

			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasRightSprite == false) 
			{
				MakeNewSprite (1);
				hasRightSprite = true;
			} 
			else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasLeftSprite == false) 
			{
				MakeNewSprite (1);
				hasLeftSprite = true;
			}
		}
	}


}
