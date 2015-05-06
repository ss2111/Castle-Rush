﻿using UnityEngine;
using System.Collections;

public class Player1Castle : Photon.MonoBehaviour {
	public float health = 300;

	public GameObject healthbar;
	public AudioClip damage;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyObject(GameObject g){
		if (photonView.isMine) {
			PhotonNetwork.LoadLevel ("GameOver");
		} 
		else {
			Application.LoadLevel ("Victory");
		}
		Destroy (g);
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player2") {
			if (health > 0) {
				//decrease enemy health
				health -= 10f;
				this.GetComponent<AudioSource> ().PlayOneShot (damage);
				healthbar.transform.localScale -= new Vector3 (0.1f, 0, 0);
				if (health <= 0) {
					DestroyObject (this.gameObject);
				}
			}
		}
		
	}
}
