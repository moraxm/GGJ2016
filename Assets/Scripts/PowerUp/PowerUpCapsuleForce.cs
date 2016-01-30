using UnityEngine;
using System.Collections;

public class PowerUpCapsuleForce : PowerUp {
	public CollisionEvents eventsOfSphereForce;

	public override void StartCollectable (CollectableOwner owner)
	{
		base.StartCollectable (owner);
		eventsOfSphereForce.onCollisionEnter += CheckCollision;
	}

	public override void FinishCollectable ()
	{
		base.FinishCollectable ();
		//eventsOfSphereForce -= CheckCollision;
	}

	void CheckCollision(Collision col)
	{
		//col.co
	}
}
