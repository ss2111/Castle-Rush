﻿using UnityEngine;
using System.Collections;

public class EndGameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ExitToMenu(){
		Application.LoadLevel ("GUIMenu");
	}
}
