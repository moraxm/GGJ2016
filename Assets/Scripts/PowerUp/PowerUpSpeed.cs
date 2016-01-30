using UnityEngine;
using System.Collections;

public class PowerUpSpeed : PowerUp
{
    [Range(0,5)]
    public float speedIncrement = 2;

	public override void StartCollectable(CollectableOwner owner)
    {
        base.StartCollectable(owner);
        owner.playerController.speed *= speedIncrement;
    }

    public override void FinishCollectable()
    {
        base.FinishCollectable();
        //owner.playerController.speed /= speedIncrement;
    }
}
