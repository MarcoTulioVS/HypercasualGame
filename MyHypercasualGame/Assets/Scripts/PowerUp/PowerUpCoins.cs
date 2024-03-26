using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [Header("Coins collector")]
    public float sizeAmount= 7;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        //PlayerController.instance.ChangeCoinCollectorSize(sizeAmount);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        //PlayerController.instance.ChangeCoinCollectorSize(sizeAmount);
    }
}
