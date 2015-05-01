using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour {
	public Texture2D texture = null;

	public void OnGUI(){
		GUI.Label ( new Rect(Screen.width/(Screen.height/50), Screen.height/Screen.width, texture.width, texture.height), texture);

	}

}
