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
