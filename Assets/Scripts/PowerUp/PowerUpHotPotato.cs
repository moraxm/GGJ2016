using UnityEngine;
using System.Collections;

public class PowerUpHotPotato : PowerUp {

	public override void StartCollectable(CollectableOwner owner)
	{
		base.StartCollectable(owner);
		owner.playerController.GetComponent<PlayerCollision> ().onCollisionPLayer += onCollision;
	}

	public override void FinishCollectable()
	{
		//owner.GetComponent<InventaryRune> ().DropRune ();
		if (owner != null){
			InventaryRune ir = owner.playerController.gameObject.GetComponent<InventaryRune> ();
			ir.DropRune ();
		}
		//owner.playerController.GetComponent<PlayerCollision> ().onCollisionPLayer -= onCollision;
		base.FinishCollectable();

	}

	public void onCollision(Collision coll){
		
		this.owner = coll.collider.GetComponent<CollectableOwner> ();
		this.gameObject.transform.parent = coll.gameObject.transform;

	}

}
