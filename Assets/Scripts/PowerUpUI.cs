using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour {


	Image im;
	public Sprite bomba;
	public Sprite cambioLosas;
	public Sprite correr;
	public Sprite escudo;
	public Sprite laser;

	public bool isBomba;
	public bool isCambiosLosas;
	public bool isCorrer;
	public bool isEscudo;
	public bool isLaser;
	public bool isNone;



	// Use this for initialization
	void Start () {
		im = GetComponent<Image> ();
		changeAlha (0);
	}
	
	// Update is called once per frame
	void Update () {


		if (isBomba) {
			changeAlha (255);
			im.sprite = bomba;
			isBomba = false;
		}

		if (isCambiosLosas) {
			changeAlha (255);
			im.sprite = cambioLosas;
			isCambiosLosas = false;
		}
		if (isCorrer) {
			changeAlha (255);
			im.sprite = correr;
			isCorrer = false;
		}
		if (isEscudo) {
			changeAlha (255);
			im.sprite = escudo;
			isEscudo = false;
		}
		if (isLaser) {
			changeAlha (255);
			im.sprite = laser;
			isLaser = false;
		}

		if (isNone) {
			changeAlha (0);
			isNone = false;
		}


	
	}

	public void changeAlha (float amount){
		Color tmp = im.color;
		tmp.a = amount;
		im.color = tmp;
	}
}
