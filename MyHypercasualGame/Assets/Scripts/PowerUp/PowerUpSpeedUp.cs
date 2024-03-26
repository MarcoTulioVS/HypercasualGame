using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{

    [Header("Power up speed up")]

    public float amountToSpeed;

    protected override void StartPowerUp()
    {
       
        base.StartPowerUp();
        PlayerController.instance.PowerUpSpeedUp(amountToSpeed);
        PlayerController.instance.SetPowerUpText("Speed Up");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetSpeed();
        PlayerController.instance.SetPowerUpText("");
    }
}
