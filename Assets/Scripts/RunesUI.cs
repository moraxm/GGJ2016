using UnityEngine;
using System.Collections;

public class RunesUI : MonoBehaviour {

	public GameObject Rune;
	public int maxRunes = 7;

	public bool create;
	public int numRunes = 0;
	GameObject[] runes;

	// Use this for initialization
	void Start () {
		runes = new GameObject[maxRunes];
		// create the Rune
		GameObject rune = (GameObject)Instantiate(Rune, transform.position, Quaternion.identity);
		// Assign to the parent
		rune.transform.parent = this.gameObject.transform;
		// Add to the array of runes
		runes [numRunes] = rune;
		// increase the num of runes
		numRunes++;

	}
	
	// Update is called once per frame
	void Update () {
		if (create) {
			Vector3 position;
			for (int i = 0; i < numRunes; ++i) {
				position = runes [i].transform.position;
				position.x -= 15;
				runes [i].transform.position = position;
			}
			position = runes [numRunes - 1].transform.position;
			position.x += 30;

			GameObject rune = (GameObject)Instantiate(Rune, position, Quaternion.identity);
			rune.transform.parent = this.gameObject.transform;
			create = false;
			runes [numRunes] = rune;

			numRunes++;
		}
	}
}
