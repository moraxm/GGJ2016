using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {

	// time in seconds
	public float time = 180;
	public RunesUI uiAtacker;
	public RunesUI uiDefenser;

	float maxTime;
	Slider slider;

	// Use this for initialization
	void Start () {
		maxTime = time;
		slider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {

		time -= Time.deltaTime;
		slider.value = time / maxTime;

		if (time <= 0) {
			if (uiAtacker.runesFilled > uiDefenser.runesFilled) {
				UnityEngine.SceneManagement.SceneManager.LoadScene (2);
			}
			else if (uiAtacker.runesFilled < uiDefenser.runesFilled){
				UnityEngine.SceneManagement.SceneManager.LoadScene (3);
			}
			else{
				UnityEngine.SceneManagement.SceneManager.LoadScene (1);	
			}

		}
	}
}
