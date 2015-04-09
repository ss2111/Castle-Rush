using UnityEngine;
using System.Collections;

public class CastleSpawn : MonoBehaviour {
	public GameObject obj;
	public Vector3 ObjectSpawnPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X)) {
			Instantiate(obj, ObjectSpawnPosition, Quaternion.identity);
		}
	}
}
