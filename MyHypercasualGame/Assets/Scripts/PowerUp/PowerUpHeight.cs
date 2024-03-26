using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PowerUpHeight : PowerUpBase
{
    [Header("Power up height")]

    public float amountHeight;

    public float animationDuration;

    public Ease ease = Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.ChangeHeight(amountHeight, duration, animationDuration, ease);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ResetHeight();
    }
}
