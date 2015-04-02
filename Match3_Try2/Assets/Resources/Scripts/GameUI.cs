using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GameUI : MonoBehaviour {
	
	public static int score;
	Text text;
	
	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();
		
		// Reset the score.
		score = 0;
	}
	// Update is called once per frame
	void Update () {
		text.text = "" + score;
	}
}
