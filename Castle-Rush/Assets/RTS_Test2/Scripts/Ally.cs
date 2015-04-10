using UnityEngine;
using System.Collections;

public class Ally : Photon.MonoBehaviour {
	public GameObject[] Targets = new GameObject[25];
	public GameObject bulletPrefab;
	private bool hasTarget = false;
	public float timer = 0;
	public float fireTimer = 2;
	public float rangeSquared = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetClosestEnemy ();
		if (!hasTarget) {
			transform.Translate (0, Time.deltaTime * 1, 0);
		} 
	}

	GameObject GetClosestEnemy ()
	{

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
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Castle")
		{	
			DestroyObject(this.gameObject);
		}
	}

}
