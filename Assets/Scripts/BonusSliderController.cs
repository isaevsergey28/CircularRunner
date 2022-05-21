using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BonusSliderController : MonoBehaviour
{
    private Slider _slider;
    private Sequence sequence;
    private float _bonusDurationTime;
    private float _leftBonusDurationTime;
    private float _leftBonusValue;
    
    private void Start()
    {
        PauseOrDefeatSystem.instance.Subscribe(this);
        _slider = GetComponent<Slider>();
        _slider.gameObject.SetActive(false);   
    }

    private void OnEnable()
    {
        if (_leftBonusDurationTime > 0)
        {
            sequence = DOTween.Sequence();
            _slider.gameObject.SetActive(true);
            _slider.value = _leftBonusValue;
            sequence.Append(_slider.DOValue(0, _leftBonusDurationTime)).SetEase(Ease.Linear);
            sequence.AppendCallback(() => _slider.gameObject.SetActive(false));
        }
    }

    private void OnDisable()
    {
        sequence.Kill();
        _leftBonusValue = _slider.value;
        _leftBonusDurationTime = _leftBonusValue * _bonusDurationTime;
    }

    public void TurnOn(float time)
    {
        _leftBonusDurationTime = 0;
        _leftBonusValue = 1;
        _bonusDurationTime = time;
        sequence = DOTween.Sequence();
        _slider.gameObject.SetActive(true);
        _slider.value = _slider.maxValue;
        sequence.Append(_slider.DOValue(0, time)).SetEase(Ease.Linear);
        sequence.AppendCallback(() => _slider.gameObject.SetActive(false));
    }

    public void TurnOff()
    {
        sequence.Kill();
        _slider.gameObject.SetActive(false);
    }
}
