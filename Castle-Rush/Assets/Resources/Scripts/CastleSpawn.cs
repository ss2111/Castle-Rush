﻿using UnityEngine;
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

	public int unit1Cost = 100;
	public int unit2Cost = 200;
	public int unit3Cost = 300;
	public int unit4Cost = 400;
	public int unit5Cost = 500;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				GameUI.score = 5000;
			}
			else{
				GameUI.score = 5000;
			}
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				if(GameUI.score >= unit1Cost){
					player1ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player1Obj1.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit1Cost;
				}
			} 
			else {
				if(GameUI.score >= unit1Cost){
					player2ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player2Obj1.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit1Cost;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				if(GameUI.score >= unit2Cost){
					player1ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player1Obj2.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit2Cost;
				}
			} 
			else {
				if(GameUI.score >= unit2Cost){
					player2ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player2Obj2.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit2Cost;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				if(GameUI.score >= unit3Cost){
					player1ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player1Obj3.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit3Cost;
				}
			} 
			else {
				if(GameUI.score >= unit3Cost){
					player2ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player2Obj3.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit3Cost;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				if(GameUI.score >= unit4Cost){
					player1ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player1Obj4.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit4Cost;
				}
			} 
			else {
				if(GameUI.score >= unit4Cost){
					player2ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player2Obj4.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit4Cost;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			if (PhotonNetwork.player.ID == PhotonNetwork.masterClient.ID) {
				if(GameUI.score >= unit5Cost){
					player1ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player1Obj5.name, player1ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit5Cost;
				}
			} 
			else {
				if(GameUI.score >= unit5Cost){
					player2ObjectSpawnPosition.x = Random.Range(-8f,-14f);
					PhotonNetwork.Instantiate (player2Obj5.name, player2ObjectSpawnPosition, Quaternion.identity, 0, null);
					GameUI.score -= unit5Cost;
				}
			}
		}
	}
}