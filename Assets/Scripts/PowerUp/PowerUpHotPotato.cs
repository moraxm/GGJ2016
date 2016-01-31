using UnityEngine;
using System.Collections;

public class PowerUpHotPotato : PowerUp {

	public override void StartCollectable(CollectableOwner owner)
	{
		if (this.owner == null)
			m_acumTime = 0; // First time someone take me
		this.owner = owner;
		owner.playerController.GetComponentInChildren<PlayerCollision> ().onCollisionPLayer += onCollision;
	}

	public override void FinishCollectable()
	{
		//owner.GetComponent<InventaryRune> ().DropRune ();
		if (owner != null){
			InventaryRune ir = owner.playerController.gameObject.GetComponent<InventaryRune> ();
			ir.DropRune ();
			owner.playerController.GetComponentInChildren<PlayerCollision> ().onCollisionPLayer -= onCollision;
			particles.transform.parent = null;
			particles.SetActive (true);
			Destroy (particles, 10.0f);
		}

		base.FinishCollectable();

	}

	public void onCollision(Collision coll){
		if (coll.gameObject.layer != LayerMask.NameToLayer ("Player"))
			return;

		Debug.Log ("OnCollision");
		owner.playerController.GetComponentInChildren<PlayerCollision> ().onCollisionPLayer -= onCollision;
		ChangeOwnerEndOfFrame (coll.collider.transform.parent.GetComponentInChildren<CollectableOwner> ());
	}

	void ChangeOwnerEndOfFrame(CollectableOwner newOwner)
	{
		StartCoroutine (ChangeOwnerCoroutine (newOwner));
	}

	// Esto es una mierda para que no se llamen dos veces al onCollision
	IEnumerator ChangeOwnerCoroutine(CollectableOwner newOwner)
	{
		yield return new WaitForEndOfFrame ();
		owner.SetNullCollectable ();
		CollectableOwner co = newOwner;
		co.SetCollectable (this);
	}

}
