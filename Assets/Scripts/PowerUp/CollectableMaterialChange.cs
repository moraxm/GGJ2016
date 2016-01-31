using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Renderer))]
public class CollectableMaterialChange : MonoBehaviour {

	public Color baseEmissionColor;
	public Color powerUpEmissionColor;
	public Color runeColor = Color.blue;

	Renderer m_renderer;
	Material m_material;
	public float m_speed;
	Coroutine m_feedbackcoroutine;
	Coroutine m_runeFeedbackCoroutine;
	float m_acumTime;
	// Use this for initialization
	void Start () {
		m_renderer = GetComponent<Renderer> ();
		m_material = m_renderer.material;
		baseEmissionColor = m_material.GetColor ("_EmissionColor");

	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		m_acumTime += Time.deltaTime;
		if (m_acumTime > m_speed) {
			m_acumTime = 0;
		}

		float emission = Mathf.Lerp (0, 1, (m_speed - m_acumTime) / m_speed);
		Debug.Log ("emission " + emission);
		Color finalColor = Color.Lerp (baseEmissionColor, powerUpEmissionColor,emission);
		Debug.Log (finalColor);
		m_material.SetColor ("_EmissionColor", finalColor);*/
	}

	public void SetRuneFeedback()
	{
		if (m_runeFeedbackCoroutine != null)
			StopCoroutine (m_runeFeedbackCoroutine);
		m_runeFeedbackCoroutine = StartCoroutine (RuneFeedbackCoroutine ());

	}

	IEnumerator RuneFeedbackCoroutine()
	{
		m_material.SetColor ("_EmissionColor", runeColor);
		yield return new WaitForSeconds (1);
		m_material.SetColor ("_EmissionColor", baseEmissionColor);
	}

	public void SetPowerUpFeedback(float time)
	{
		if (m_feedbackcoroutine != null)
		{
			StopCoroutine (m_feedbackcoroutine);
			m_material.SetColor ("_EmissionColor", baseEmissionColor);
		}
		m_feedbackcoroutine = StartCoroutine (PowerUpFeedback (time));
	}

	IEnumerator PowerUpFeedback(float timeAlive)
	{
		m_material.SetColor ("_EmissionColor", powerUpEmissionColor);
		float acumTime = 0;
		bool pingPong = true;
		while (acumTime < timeAlive) 
		{
			float speed = ((timeAlive - acumTime) / timeAlive);
			Color col = pingPong ? powerUpEmissionColor : baseEmissionColor;
			m_material.SetColor ("_EmissionColor", col); 
			pingPong = !pingPong;
			yield return new WaitForSeconds (speed);
			acumTime += speed + Time.deltaTime;
			/*
			float emissionSpeed = Mathf.Lerp (minBlinkSpeed, maxBlinkSpeed, speed * speed);
			Debug.Log ("speed: " + speed+ " emissionSpeed: "+ emissionSpeed);
			Color finalColor = Color.Lerp (powerUpEmissionColor, baseEmissionColor,Time.deltaTime * emissionSpeed);
			m_material.SetColor ("_EmissionColor", finalColor);*/


		}

		m_material.SetColor ("_EmissionColor", baseEmissionColor);

	}
}
