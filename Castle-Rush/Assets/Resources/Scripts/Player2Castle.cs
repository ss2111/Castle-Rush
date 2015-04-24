using UnityEngine;
using System.Collections;

public class Player2Castle : Photon.MonoBehaviour {
	public float health = 300;
	public AudioClip victory;
	public GameObject healthbar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyObject(GameObject g){
		if (photonView.isMine) {
			PhotonNetwork.LoadLevel ("Victory");
		} 
		else {
			Application.LoadLevel ("GameOver");
		}
		Destroy (g);
	}
	void OnTriggerEnter(Collider col){
		
		if (health > 0) {
			//decrease enemy health
			health -= 10f;
			healthbar.transform.localScale -= new Vector3(0.1f,0,0);
			if (health <= 0) {
				DestroyObject (this.gameObject);
			}
		}
		
	}
}
