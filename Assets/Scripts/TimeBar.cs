using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {

	// time in seconds
	public float time = 180;

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
	}
}
