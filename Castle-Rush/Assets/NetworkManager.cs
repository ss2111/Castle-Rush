using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {
	public string HostName;
	public string MatchName;
	public static NetworkManager Instance;
	public List<Host> HostList = new List<Host>();
	// Use this for initialization
	void Start () {
		Instance = this;
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartServer(string ServerName, int MaxPlayers){
		Network.InitializeSecurity ();
		Network.InitializeServer (MaxPlayers, 25565,true);
		MasterServer.RegisterHost ("CastleRush", ServerName,"");
		Debug.Log("Stared Server");
	}

}

[System.Serializable]
public class Host{
	public string HostName;
}