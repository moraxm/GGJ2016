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
		SetFeedback (owner.feedbackManager);
		FinishCollectable ();
	}

	public override void SetFeedback (CollectableMaterialChange feedbackManager)
	{
		base.SetFeedback (feedbackManager);
		feedbackManager.SetRuneFeedback ();
	}

	public override void FinishCollectable ()
	{
		base.FinishCollectable ();
		Destroy (this.gameObject);
	}
}
