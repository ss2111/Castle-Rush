using UnityEngine;
using System.Collections;

[RequireComponent( typeof( PhotonView ) )]
public class CastleSpawn : Photon.MonoBehaviour {
	public GameObject obj;
	public Vector3 ObjectSpawnPosition;
	public GameObject obj2;
	public Vector3 ObjectSpawnPosition2; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				PhotonNetwork.Instantiate (obj.name, ObjectSpawnPosition, Quaternion.identity, 0, null);
			} 
			else {
				PhotonNetwork.Instantiate (obj2.name, ObjectSpawnPosition2, Quaternion.identity, 0, null);
			}
		}
		
	}
}
