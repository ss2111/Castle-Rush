using UnityEngine;
using System.Collections;

public class Player2Castle : Photon.MonoBehaviour {
	public float health = 300;
	public AudioClip victory;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	[RPC]
	public void DestroyObject(GameObject g){

		Application.LoadLevel("GameOver");
		Destroy (g);
	}
	void OnTriggerEnter(Collider col){
		
		if (health > 0) {
			//decrease enemy health
			health -= 10f;
			if (health <= 0) {
				DestroyObject (this.gameObject);
			}
		}
		
	}
}
