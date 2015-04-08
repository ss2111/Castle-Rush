using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	// Speed
	public float speed = 10;
	public float timeOut = 2;
	public float timer;

	// Target (set by Tower)
	public Transform target; 
	void Start(){
		timer = Time.time;
	}
	void Update(){
		if (Time.time - timer > timeOut) {
			Destroy (gameObject);
		}
	
		// Still has a Target?
		if (target) {
			// Fly towards the target        
			Vector3 dir = target.position - transform.position;
			this.GetComponent<Rigidbody> ().velocity = dir.normalized * speed;
		} else {
			// Otherwise destroy self
			Destroy (gameObject);
		}
	}
	public void Destroy(){
		Destroy(this.gameObject);
	}
}