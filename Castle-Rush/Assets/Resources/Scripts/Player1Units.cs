using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(AudioSource))]
public class Player1Units : Photon.MonoBehaviour {

	public float health;
	public float currenthealth;
	private bool hasTarget = false;
	public GameObject[] Targets = new GameObject[25];
	public GameObject bulletPrefab;
	public float timer = 0;
	public float fireTimer = 2;
	public float rangeSquared = 5;
	public float speed = 1f;
	GameObject target = null;
	public AudioClip death;
	public GameObject healthbar;
	//public AudioSource audio;
	// Use this for initialization
	void Start () {
		currenthealth = health;
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
		this.GetComponent<AudioSource>().PlayOneShot(death);
		Destroy (g);
	}
	
	GameObject GetClosestEnemy (){

		Targets = GameObject.FindGameObjectsWithTag("Player2");

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
	IEnumerator OnCollisionEnter(Collision col)
	{
		print (col.gameObject.name);
		if (col.gameObject.tag == "Bullet2") {
			if (currenthealth > 0) {
				//decrease enemy health
				currenthealth -= 10f;
				healthbar.transform.localScale -= new Vector3((1f/(health/10f)),0,0);
				if (currenthealth <= 0) {
					this.GetComponent<AudioSource>().PlayOneShot(death);
					this.gameObject.transform.position = new Vector3 (-10,-10,10);
					print (death.length);
					yield return new WaitForSeconds(death.length);
					DestroyObject (this.gameObject);
				}
			}
			col.gameObject.GetComponent<Bullet> ().Destroy ();
		}
	}

	void OnTriggerEnter(Collider col){

		if(col.gameObject.tag == "Castle2")
		{	
			//this.GetComponent<AudioSource>().PlayOneShot(death);
			//this.gameObject.transform.position = new Vector3 (-10,10,10);
			//print (death.length);
			//yield return new WaitForSeconds(death.length);
			DestroyObject(this.gameObject);
		}
	}
}