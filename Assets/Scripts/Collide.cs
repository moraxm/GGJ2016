using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

	public float explosionStrength = 0.3f;

	private Vector3 forceVec;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "PlayerAttack" ||
			col.gameObject.tag == "PlayerDefense")
		forceVec = -col.gameObject.GetComponent<Rigidbody>().velocity.normalized * explosionStrength;
		col.gameObject.GetComponent<Rigidbody> ().AddForce (forceVec,ForceMode.Acceleration);
	}
}
