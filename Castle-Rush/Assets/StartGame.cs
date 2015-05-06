using UnityEngine;
using System.Collections;

[RequireComponent( typeof( PhotonView ) )]
public class StartGame : Photon.MonoBehaviour {

	public GameObject waitingScreen;
	public int PlayerCount;
	public AudioSource GemMatch;
	public bool gameStart = false;
	// Use this for initialization
	void Start () {
		GemMatch.mute = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.player.ID != PhotonNetwork.masterClient.ID && !gameStart) {
			photonView.RPC ("MoveBlocker", PhotonTargets.All);
		}
		if (!gameStart) {
			GameUI.score = 0;
		}
	}

	[RPC]
	public void MoveBlocker(){
		gameStart = true;
		GemMatch.mute = false;
		GameUI.score = 0;
		waitingScreen.SetActive (false);

	}

	void onPlayerDisconnect(NetworkPlayer player){
		PhotonNetwork.LoadLevel ("Victory");
	}
	/*
	[RPC]
	public void Connected(){
		PlayerCount += 1;
		print( "OnPhotonPlayerConnected()" ); // not seen if you're the player connecting
	}
	*/
}
