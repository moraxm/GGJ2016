using UnityEngine;
using System.Collections;

public class PowerUpSpeed : PowerUp
{
    [Range(0,5)]
    public float speedIncrement = 2;

    public override void StartPowerUp(PowerUpOwner owner)
    {
        base.StartPowerUp(owner);
        owner.playerController.speed *= speedIncrement;
    }

    public override void FinishPowerUp()
    {
        base.FinishPowerUp();
        owner.playerController.speed /= speedIncrement;
    }
}
