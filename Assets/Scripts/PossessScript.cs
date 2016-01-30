using UnityEngine;
using System.Collections;

public class PossessScript : MonoBehaviour {

	private GameObject playerDefenseReference;

	public int timePossessionElapsed = 1;

	public float amountLifeToDecrease = 10;
	public float amountSpeedToDecrease = 10;

	private bool possessionProcessStarted = false;

	private float timePossesion = 0;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (possessionProcessStarted) {

			timePossesion -= Time.deltaTime;

			if (timePossesion < 0) {
				timePossesion = timePossessionElapsed;
				//Debug.Log (playerDefenseReference.tag + " is in possession proccess");
				if (playerDefenseReference == null) {
					Debug.LogError ("Not PlayerDefense reference!!");
				}
				playerDefenseReference.GetComponent<Life> ().decreaseLife(amountLifeToDecrease);
			}
		} else {
			//possession terminated, default values
			timePossesion = timePossessionElapsed;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "PlayerDefense") {
			Debug.Log (other.tag + " is starting of possession proccess");
			possessionProcessStarted = true;
			playerDefenseReference = other.gameObject;
		}
	}


	void OnTriggerExit(Collider other) {
		if (other.tag == "PlayerDefense") {
			Debug.Log (other.tag + " is exist of possession proccess");
			possessionProcessStarted = false;
		}
	}
}
