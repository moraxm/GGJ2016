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
		owner.playerController.GetComponent<InventaryPowerUp> ().changeTo ("correr");
    }

    public override void FinishCollectable()
    {
		if (owner != null) {
			owner.playerController.speed /= speedIncrement;
			owner.playerController.GetComponent<InventaryPowerUp> ().changeTo ("none");
		}
			
        base.FinishCollectable();
    }
}
