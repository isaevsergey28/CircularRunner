using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shield : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            TurnOnBonusSlider(_bonusEffectTime);
            player.MakeInvulnerable(_bonusEffectTime);
            Destroy(gameObject);
        }
    }
}
