using UnityEngine;
using System.Collections;

public class PowerUpChangeSpots : PowerUp {



	public override void FinishCollectable () {
		base.FinishCollectable ();

		if (owner != null) {
			ActiveSpotsManager.instance.changePowerUpSpotsActives ();
			ActiveSpotsManager.instance.changeRuneSpotsActives ();
		}

		Destroy (this.gameObject);
	}
}
