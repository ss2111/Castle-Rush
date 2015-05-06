using UnityEngine;
using System.Collections;

public class Menu : Photon.MonoBehaviour {
	public Texture2D texture = null;
	public Texture2D Logo1 = null;
	public Texture2D texture_helpButton = null;
	public Texture2D texture_QuitGame = null;
	public Texture2D texture_BackButton = null;
	public Texture2D texture_StartGame = null;
	public Texture2D texture_LobbyButton = null;
	public Texture2D texture_RefreshButton = null;
	public Texture2D texture_ServerList = null;
	public Texture2D texture_HelpMenu = null;
	public Texture2D texture_smallBackButton = null;

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
		if (CurMenu == "HowTo") {
			HowTo ();
		}

	}

	private void Main(){
		//Game Logo
		GUI.Label ( new Rect(Screen.width/(Screen.height/50), Screen.height/Screen.width, Logo1.width, Logo1.height), Logo1);

		//Host Game
		if (GUI.Button (new Rect(Screen.width/(Screen.height/90), Screen.height/(Screen.width/400), texture.width, texture.height), texture)) {
			ToMenu ("Host");
		}
		//Quit Game
		if (GUI.Button (new Rect(Screen.width/(Screen.height/241)-103, Screen.height/(Screen.width/600)+63, texture_QuitGame.width, texture_QuitGame.height), texture_QuitGame)) {
			Application.Quit();
		}
		//How to play
		if (GUI.Button (new Rect (Screen.width/(Screen.height/90), Screen.height/(Screen.width/600)+63, texture_helpButton.width, texture_helpButton.height), texture_helpButton)) {
			ToMenu ("HowTo");
		}
		//Enter Lobby Button
		if (GUI.Button (new Rect (Screen.width/(Screen.height/241)-103, Screen.height/(Screen.width/400), texture_LobbyButton.width, texture_LobbyButton.height), texture_LobbyButton)) {
			ToMenu ("Lobby");
		}

	}

	private void Host(){
		//Game Logo
		GUI.Label ( new Rect(Screen.width/(Screen.height/50), Screen.height/Screen.width, Logo1.width, Logo1.height), Logo1);

		MatchName = GUI.TextField(new Rect(Screen.width/(Screen.height/100), Screen.height/(Screen.width/400), 644, texture.height), MatchName, 48, host_style);
		//Start Game Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height/90), Screen.height/(Screen.width/600)+63, texture.width, texture.height), texture_StartGame)) {
			PlayerPrefs.SetString("HostName", MatchName);
			NetworkManager.Instance.StartServer(MatchName, Players);
			//ToMenu ("Lobby");
			PhotonNetwork.LoadLevel("FullGame");
		}
		//Back Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height/241)-103, Screen.height/(Screen.width/600)+63, texture.width, texture.height), texture_BackButton)) {
			ToMenu ("Main");
		}
	}

	private void Lobby(){
		//Game Logo
		GUI.Label ( new Rect(Screen.width/(Screen.height/50), Screen.height/Screen.width, Logo1.width, Logo1.height), Logo1);

		//Refresh Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height/90), Screen.height/(Screen.width/400), texture.width, texture.height), texture_RefreshButton)) {
			MasterServer.RequestHostList("CastleRush");
		}

		//Back Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height/241)-103, Screen.height/(Screen.width/400), texture.width, texture.height), texture_BackButton)) {
			ToMenu ("Main");
		}
		GUI.Label(new Rect (Screen.width/(Screen.height/100), Screen.height/(Screen.width/600)+6, texture_ServerList.width, texture_ServerList.height), texture_ServerList);
		GUILayout.BeginArea (new Rect (Screen.width/(Screen.height/90)+6, Screen.height/(Screen.width/600)+120, texture_ServerList.width, 200), "","box");
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
	private void HowTo(){
		//Help Menu
		GUI.Label ( new Rect(Screen.width/(Screen.height), Screen.height/Screen.width, texture_HelpMenu.width, texture_HelpMenu.height), texture_HelpMenu);

		//Back Button
		if (GUI.Button (new Rect(Screen.width/(Screen.height), Screen.height/(Screen.width), texture_smallBackButton.width, texture_smallBackButton.height), texture_smallBackButton)) {
			ToMenu ("Main");
		}

	}

}
