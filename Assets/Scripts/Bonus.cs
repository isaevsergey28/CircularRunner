using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] protected float _bonusEffectTime;
    
    protected void TurnOnBonusSlider(float time)
    {
        UIManager.instance.GetScreen<GameCanvas>().TurnOnBonusSlider(_bonusEffectTime);
    }
}
