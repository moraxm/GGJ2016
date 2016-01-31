using UnityEngine;
using System.Collections;

public class InventaryPowerUp : MonoBehaviour {

	public PowerUpUI ui;

	public void changeTo(string image){
		switch (image) {
		case "none":
			ui.isNone = true;
			break;
		case "bomba":
			ui.isBomba = true;
			break;
		case "cambioLosas":
			ui.isCambiosLosas = true;
			break;
		case "correr":
			ui.isCorrer = true;
			break;
		case "escudo":
			ui.isEscudo = true;
			break;
		case "laser":
			ui.isLaser = true;
			break;
		}
	}
}
