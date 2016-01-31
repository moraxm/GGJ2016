using UnityEngine;
using System.Collections;

public class PowerUpChangeSpots : PowerUp {

	public override void FinishCollectable () {
		base.FinishCollectable ();

		if (owner != null) {
			ActiveSpotsManager.instance.changePowerUpSpotsActives ();
			ActiveSpotsManager.instance.changeRuneSpotsActives ();
			particles.transform.parent = null;
			particles.SetActive (true);
			Destroy (particles, 10f);
		}

		Destroy (this.gameObject);
	}
}
