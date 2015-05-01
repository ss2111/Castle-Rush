using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public Texture2D texture = null;
	public Texture2D texture2 = null;
	public Texture2D texture3 = null;
	public Texture2D texture4 = null;
	public Texture2D texture5 = null;
	public Texture2D texture6 = null;
	public Texture2D texture7 = null;
	public Texture2D texture8 = null;
	public Texture2D texture9 = null;

	private string CurMenu;
	public string Name;
	public string MatchName;
	public int Players = 2;

	public GUIStyle host_style;

	// Use this for initialization
	void Start () {
		CurMenu = "Main";
		Name = PlayerPrefs.GetString ("HostName");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ToMenu(string menu){
		CurMenu = menu;
	}

	void OnGUI(){
		if (CurMenu == "Main") {
			Main();
		}
		if(CurMenu == "Host"){
			Host();
		}
		if(CurMenu == "Lobby"){
			Lobby();
		}

	}

	private void Main(){
		//Host Game
		if (GUI.Button (new Rect(Screen.width/(Screen.height/90), Screen.height/(Screen.width/400), texture.width, texture.height), texture)) {
			ToMenu ("Host");
		}
		//Quit Game
		if (GUI.Button (new Rect(Screen.width/(Screen.height/241)-103, Screen.height/(Screen.width/600)+63, texture3.width, texture3.height), texture3)) {
			Application.Quit();
		}
		//How to play
		if (GUI.Button (new Rect (Screen.width/(Screen.height/90), Screen.height/(Screen.width/600)+63, texture2.width, texture2.height), texture2)) {
			
		}
		//Enter Lobby Button
		if (GUI.Button (new Rect (Screen.width/(Screen.height/241)-103, Screen.height/(Screen.width/400), texture4.width, texture4.height), texture7)) {
			ToMenu ("Lobby");
		}

	}

	private void Host(){
		MatchName = GUI.TextField(new Rect(Screen.width/(Screen.height/100), Screen.height/(Screen.width/400), 644, texture.height), MatchName, 48, host_style);
		//Start Game Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height/90), Screen.height/(Screen.width/600)+63, texture.width, texture.height), texture6)) {
			PlayerPrefs.SetString("HostName", MatchName);
			NetworkManager.Instance.StartServer(MatchName, Players);
			//ToMenu ("Lobby");
			PhotonNetwork.LoadLevel("FullGame");
		}
		//Back Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height/241)-103, Screen.height/(Screen.width/600)+63, texture.width, texture.height), texture5)) {
			ToMenu ("Main");
		}
	}

	private void Lobby(){
		//Refresh Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height/90), Screen.height/(Screen.width/400), texture.width, texture.height), texture8)) {
			MasterServer.RequestHostList("CastleRush");
		}

		//Back Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height/241)-103, Screen.height/(Screen.width/400), texture.width, texture.height), texture5)) {
			ToMenu ("Main");
		}
		GUI.Label(new Rect (Screen.width/(Screen.height/100), Screen.height/(Screen.width/600)+6, texture9.width, texture9.height), texture9);
		GUILayout.BeginArea (new Rect (Screen.width/(Screen.height/90)+6, Screen.height/(Screen.width/600)+120, texture9.width, 200), "","box");
		foreach (HostData hd in MasterServer.PollHostList()) {
			GUILayout.BeginHorizontal();
			GUILayout.Label(hd.gameName);
			//Join Game Button
			if (GUILayout.Button("Join Game")) {
				Network.Connect(hd);
				PhotonNetwork.LoadLevel("FullGame");
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.EndArea ();

	}

}
