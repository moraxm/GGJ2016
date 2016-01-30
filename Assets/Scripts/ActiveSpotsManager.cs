using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveSpotsManager : MonoBehaviour {

	public static ActiveSpotsManager instance = null;

	private GameObject[] powerUpSpots;
	private GameObject[] runeSpots;

	private List<GameObject> powerUpSpotsActive = new List<GameObject>();
	private List<GameObject> runeSpotsActive = new List<GameObject>();

	public int numPowerUpSpotsActive = 0;
	public int numRuneSpotsActive = 0;

	System.Random rnd;

	// Use this for initialization
	void Awake () {

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		InitSpots ();
	}

	void InitSpots() {
		if (numPowerUpSpotsActive <= 0) {
			Debug.LogError ("Power Ups Spots " + numPowerUpSpotsActive);
		}

		if (numRuneSpotsActive <= 0) {
			Debug.LogError ("Runes Spots " + numRuneSpotsActive);
		}

		powerUpSpots = GameObject.FindGameObjectsWithTag("PowerUpSpot");
		runeSpots = GameObject.FindGameObjectsWithTag("RuneSpot");

		if (numPowerUpSpotsActive > powerUpSpots.Length) {
			Debug.LogError ("Active Power Ups Spots is bigger than powerUpSpots.Length");
		}

		if (numRuneSpotsActive > runeSpots.Length) {
			Debug.LogError ("Active Rune Spots is bigger than runeSpots.Length");
		}

		//deactivate all spots
		deactivateAllObjects(powerUpSpots);
		deactivateAllObjects(runeSpots);

		rnd = new System.Random();

		//Debug.Log ("Power Ups Spots Length: " + powerUpSpots.Length);
		//Debug.Log ("Rune Spots Length: " + runeSpots.Length);

		changePowerUpSpotsActives ();
		changeRuneSpotsActives ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void deactivateAllObjects(GameObject[] arrayObjects) {
		for (int i = 0; i < arrayObjects.Length; i++) {
			arrayObjects [i].SetActive (false);
		}
	}

	public void changePowerUpSpotsActives() {

		deactivateSpots (powerUpSpotsActive);

		for (int i = 0; i < numPowerUpSpotsActive; i++) {
			int indexPowerUp = rnd.Next(0, powerUpSpots.Length);

			Debug.Log ("Power Ups Spots random: " + indexPowerUp);

			powerUpSpots [indexPowerUp].SetActive (true);

			powerUpSpotsActive.Add (powerUpSpots [indexPowerUp]);
		}
	}

	public void changeRuneSpotsActives() {

		deactivateSpots (runeSpotsActive);

		for (int i = 0; i < numRuneSpotsActive; i++) {
			int indexRune = rnd.Next(0, runeSpots.Length);

			Debug.Log ("Rune Spots Length: " + indexRune);

			runeSpots [indexRune].SetActive (true);

			runeSpotsActive.Add (runeSpots [indexRune]);
		}
	}

	void deactivateSpots(List<GameObject> list) {
		if (list.Count > 0) {
			foreach (GameObject item in list) {
				item.SetActive (false);
			}

			list.Clear ();
		}
	}


}
