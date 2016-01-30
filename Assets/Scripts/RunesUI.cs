using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunesUI : MonoBehaviour {

	public GameObject Rune;
	public int maxRunes = 7;
	public int separation = 30;

	// For level
	public bool nextLevel;
	public int numRunes = 0;
	GameObject[] runes;

	// For runes
	public bool nextRune;
	public int runesFilled;

	// Sprites
	public Sprite spriteRuneWithoutFill;
	public Sprite spriteRuneFilled;


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
		// There isn't runes filled in initation
		runesFilled = 0;
		nextRune = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (nextLevel) {
			Vector3 position;
			// Move all the runes to the left separation/2 units
			for (int i = 0; i < numRunes; ++i) {
				//Modify sprite
				runes [i].GetComponent<Image> ().sprite = spriteRuneWithoutFill;
				// Modify position
				position = runes [i].transform.position;
				position.x -= separation / 2;
				runes [i].transform.position = position;
			}
			position = runes [numRunes - 1].transform.position;
			position.x += separation;

			GameObject rune = (GameObject)Instantiate(Rune, position, Quaternion.identity);
			rune.transform.parent = this.gameObject.transform;
			nextLevel = false;
			runes [numRunes] = rune;
			numRunes++;

			// set again the runes sprite settings
			runesFilled = 0;
		}

		if (nextRune) {
			runes [runesFilled].GetComponent<Image> ().sprite = spriteRuneFilled;
			nextRune = false;
			runesFilled++;
		}
	}
}
