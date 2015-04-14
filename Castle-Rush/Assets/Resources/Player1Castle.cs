using UnityEngine;
using System.Collections;

public class Player1Castle : Photon.MonoBehaviour {
	public float health = 300;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	[RPC]
	public void DestroyObject(GameObject g){
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
