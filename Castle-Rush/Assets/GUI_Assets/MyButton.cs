using UnityEngine;
using System.Collections;

public class MyButton : MonoBehaviour {
	
	public Texture2D texture = null;
	public Texture2D texture2 = null;
	public Texture2D texture3 = null;
	public Texture2D texture4 = null;

	public void OnGUI(){

		//if (GUI.Button (new Rect(Screen.width/3.2f -63, Screen.height / 2.2f -63, texture.width, texture.height), texture)) {
		//	PhotonNetwork.LoadLevel("FullGame");
		//}
		if (GUI.Button (new Rect(Screen.width/1.9f -73, Screen.height / 1.6f -60, texture3.width, texture3.height), texture3)) {
			
		}
		if (GUI.Button (new Rect (Screen.width /3.2f -63, Screen.height / 1.6f -60, texture2.width, texture2.height), texture2)) {
			
		}
		if (GUI.Button (new Rect (Screen.width /1.9f -73, Screen.height / 2.2f -63, texture4.width, texture4.height), texture4)) {
			
		}
	}
}
