using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player2Units : Photon.MonoBehaviour {
	
	public float health = 30;
	private bool hasTarget = false;
	public GameObject[] Targets = new GameObject[25];
	public GameObject bulletPrefab;
	public float timer = 0;
	public float fireTimer = 2;
	public float rangeSquared = 5;
	public float speed = 1f;
	GameObject target = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		target = GetClosestEnemy ();
		if (!hasTarget) {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
			//transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, Time.deltaTime * 2000);
		} 
	}
	
	[RPC]
	public void DestroyObject(GameObject g){
		Destroy (g);
	}
	
	GameObject GetClosestEnemy (){
		
		Targets = GameObject.FindGameObjectsWithTag("Player1");
		
		GameObject bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach(GameObject potentialTarget in Targets)
		{
			Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if(dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget;
			}
		}
		
		
		if (closestDistanceSqr <= rangeSquared) {
			hasTarget = true;
			
			if (Time.time - timer > fireTimer) {
				
				GameObject g = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
				g.GetComponent<Bullet> ().target = bestTarget.transform;
				timer = Time.time;
				
			}
			
			
			
		} else {
			hasTarget = false;
		}
		return bestTarget;
	}
	void OnCollisionEnter(Collision col)
	{
		print (col.gameObject.name);
		if (col.gameObject.tag == "Bullet1") {
			if (health > 0) {
				//decrease enemy health
				health -= 10f;
				if (health <= 0) {
					
					DestroyObject (this.gameObject);
				}
			}
			col.gameObject.GetComponent<Bullet> ().Destroy ();
		}
	}
	
	void OnTriggerEnter(Collider col){
		
		if(col.gameObject.tag == "Castle")
		{	
			DestroyObject(this.gameObject);
		}
	}
}