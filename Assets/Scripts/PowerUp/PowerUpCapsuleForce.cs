using UnityEngine;
using System.Collections;

public class PowerUpCapsuleForce : PowerUp {
	public CollisionEvents eventsOfSphereForce;

	public override void StartCollectable (CollectableOwner owner)
	{
		base.StartCollectable (owner);
		transform.localPosition = Vector3.zero;
		eventsOfSphereForce.gameObject.SetActive (true);
		eventsOfSphereForce.onCollisionEnter += CheckCollision;
		owner.playerController.GetComponent<InventaryPowerUp> ().changeTo ("escudo");
	}

	public override void FinishCollectable ()
	{
		if (owner)
			owner.playerController.GetComponent<InventaryPowerUp> ().changeTo ("none");
		base.FinishCollectable ();
		//eventsOfSphereForce -= CheckCollision;
	}

	void CheckCollision(Collision col)
	{
		// Only collision with player because physics layer collision mask
		InventaryRune  ir = col.collider.GetComponent<InventaryRune>();
		ir.DropRune ();
		//FinishCollectable();
	}
}
