using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textfile;
	public string [] textLines;

	public int currentLine;
	public int endAtLine;


	// Use this for initialization
	void Start () 
	{

		PlayerPrefs.GetInt ("isTalking", 0);

		if (textfile != null) 
		{
			textLines = (textfile.text.Split('\n'));
		}

		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}
	}


	// Update is called once per frame
	void Update () {

		theText.text = textLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			currentLine += 1;
		}

		if (currentLine > endAtLine) 
		{
			textBox.SetActive (false);
		}
	}
}
