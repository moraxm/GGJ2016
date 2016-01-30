using UnityEngine;
using System.Collections;

public class PowerUpDefensePossess : PowerUp {

	public override void StartPowerUp(PowerUpOwner owner)
	{
		base.StartPowerUp(owner);
		owner.playerController.gameObject.AddComponent<BoxCollider>();
	}

	public override void FinishPowerUp()
	{
		base.FinishPowerUp();

	}
}
