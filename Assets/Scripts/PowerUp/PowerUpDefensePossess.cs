using UnityEngine;
using System.Collections;

public class PowerUpDefensePossess : PowerUp {

	public override void StartCollectable(CollectableOwner owner)
	{
		base.StartCollectable(owner);
		owner.playerController.gameObject.AddComponent<BoxCollider>();
	}

	public override void FinishCollectable()
	{
		base.FinishCollectable();

	}
}
