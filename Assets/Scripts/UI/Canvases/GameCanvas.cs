using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : ScreenView
{
    [SerializeField] private BonusSliderController _bonusSliderController;
    
    public override void Init()
    {
    }

    public override void OnShow()
    {
        
    }

    public override void OnHide()
    {

    }

    public void TurnOnBonusSlider(float time)
    {
        if (_bonusSliderController.gameObject.activeSelf)
        {
            _bonusSliderController.TurnOff();
        }
        _bonusSliderController.TurnOn(time);
    }
}
