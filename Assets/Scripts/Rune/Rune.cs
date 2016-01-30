using UnityEngine;
using System.Collections;

public class Rune : Collectable 
{
	public override void StartCollectable (CollectableOwner owner)
	{
		base.StartCollectable (owner);
		InventaryRune ir = owner.GetComponent<InventaryRune> ();
		if (ir) {
			ir.CollectRune ();
		}
		FinishCollectable ();
	}

	public override void FinishCollectable ()
	{
		base.FinishCollectable ();
		Destroy (this.gameObject);
	}
}
