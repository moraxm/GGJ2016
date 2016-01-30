using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunesUI : MonoBehaviour {

	public GameObject Rune;
	public int maxRunes = 5;
	public GameObject[] runes;

	// For runes
	public bool nextRune;
	public int runesFilled;
	public bool previousRune;

	// Sprites
	public Sprite spriteRuneWithoutFill;
	public Sprite spriteRuneFilled;


	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		runes = new GameObject[maxRunes];
		// create the Rune
		GameObject rune = (GameObject)Instantiate(Rune, transform.position, Quaternion.identity);
		// Assign to the parent
		rune.transform.SetParent(this.gameObject.transform,false);
		// Add to the array of runes
		runes [numRunes] = rune;
		// increase the num of runes
		numRunes++;
		// There isn't runes filled in initation
		runesFilled = 0;
=======
		
>>>>>>> 5935046d4697e3377249e5e529f978cfbd78727d
		nextRune = false;
		previousRune = false;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (nextRune) {
			if (runesFilled < maxRunes) {
				runes [runesFilled].GetComponent<Image> ().sprite = spriteRuneFilled;
				runesFilled++;
			}
			nextRune = false;
		}

		if (previousRune) {
			if (runesFilled > 0) {
				runesFilled--;
				runes [runesFilled].GetComponent<Image> ().sprite = spriteRuneWithoutFill;
			}
			previousRune = false;
		}
	}
}
