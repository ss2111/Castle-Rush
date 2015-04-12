using UnityEngine;
using System.Collections;

[RequireComponent( typeof( PhotonView ) )]
public class CastleSpawn : Photon.MonoBehaviour {
	public GameObject player1Obj1;
	public GameObject player1Obj2;
	public GameObject player1Obj3;
	public GameObject player1Obj4;
	public GameObject player1Obj5;
	public Vector3 player1ObjectSpawnPosition;
	 
	public GameObject player2Obj1;
	public GameObject player2Obj2;
	public GameObject player2Obj3;
	public GameObject player2Obj4;
	public GameObject player2Obj5;
	public Vector3 player2ObjectSpawnPosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				PhotonNetwork.Instantiate (player1Obj1.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
			} 
			else {
				PhotonNetwork.Instantiate (player2Obj1.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
			}
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				PhotonNetwork.Instantiate (player1Obj2.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
			} 
			else {
				PhotonNetwork.Instantiate (player2Obj2.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
			}
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				PhotonNetwork.Instantiate (player1Obj3.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
			} 
			else {
				PhotonNetwork.Instantiate (player2Obj3.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
			}
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				PhotonNetwork.Instantiate (player1Obj4.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
			} 
			else {
				PhotonNetwork.Instantiate (player2Obj4.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
			}
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				PhotonNetwork.Instantiate (player1Obj5.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
			} 
			else {
				PhotonNetwork.Instantiate (player2Obj5.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
			}
		}
	}
}
