using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Bonus
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            TurnOnBonusSlider(_bonusEffectTime);
            GameSettings.instance.IncreaseGameSpeedBonus(_bonusEffectTime);
            Destroy(gameObject);
        }
    }
}
