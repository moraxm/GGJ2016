using UnityEngine;
using System.Collections;

public class PowerUpChangeSpots : PowerUp {

	public override void StartCollectable(CollectableOwner owner)
	{
		base.StartCollectable(owner);
		owner.playerController.GetComponent<InventaryPowerUp> ().changeTo ("cambioLosas");
	}

	public override void FinishCollectable () {
		base.FinishCollectable ();

		if (owner != null) {
			owner.playerController.GetComponent<InventaryPowerUp> ().changeTo ("none");
			ActiveSpotsManager.instance.changePowerUpSpotsActives ();
			ActiveSpotsManager.instance.changeRuneSpotsActives ();
			particles.transform.parent = null;
			particles.SetActive (true);
			Destroy (particles, 10f);
		}

		Destroy (this.gameObject);
	}
}
