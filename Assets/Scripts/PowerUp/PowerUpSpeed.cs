using UnityEngine;
using System.Collections;

public class PowerUpSpeed : PowerUp
{
    [Range(0,10)]
    public float speedIncrement = 2;

	public override void StartCollectable(CollectableOwner owner)
    {
        base.StartCollectable(owner);
        owner.playerController.speed *= speedIncrement;
		Debug.Log ("Speed incremented: " + speedIncrement);
    }

    public override void FinishCollectable()
    {
		if (owner != null)
			owner.playerController.speed /= speedIncrement;
        base.FinishCollectable();
    }
}
