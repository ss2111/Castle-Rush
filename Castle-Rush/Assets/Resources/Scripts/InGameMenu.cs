using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InGameMenu : MonoBehaviour {

	public Image Menu;
	public Image Quit;
	public Image Return;
	public Text QuitText;
	public Text ReturnText;
	public bool displayedMenu = false;

	// Use this for initialization
	void Start () {

		Menu.enabled = false;
		Quit.enabled = false;
		Return.enabled = false;
		QuitText.enabled = false;
		ReturnText.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(displayedMenu == false){
				Menu.enabled = true;
				Quit.enabled = true;
				Return.enabled = true;
				QuitText.enabled = true;
				ReturnText.enabled = true;
				displayedMenu = true;
			}
			else{
				Menu.enabled = false;
				Quit.enabled = false;
				Return.enabled = false;
				QuitText.enabled = false;
				ReturnText.enabled = false;
				displayedMenu = false;
			}
		}
	}
	public void ExitToMenu(){
		Application.LoadLevel ("Defeat");
	}
	public void ReturnToGame(){
		Menu.enabled = false;
		Quit.enabled = false;
		Return.enabled = false;
		QuitText.enabled = false;
		ReturnText.enabled = false;
		displayedMenu = false;
	}
}
