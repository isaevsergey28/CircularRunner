using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Sprite _stopSprite;
    [SerializeField] private Sprite _startSprite;
    
    private Button _button;
    private Image _buttonImage;
    private bool _isStopped = false;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _buttonImage = _button.gameObject.GetComponent<Image>();
        _buttonImage.sprite = _stopSprite;
        _button.onClick.AddListener(SetPause);
    }

    private void SetPause()
    {
        if (_isStopped)
        {
            _isStopped = false;
            _buttonImage.sprite = _stopSprite;
            PauseOrDefeatSystem.instance.SetUnpause();
        }
        else
        {
            _isStopped = true;
            _buttonImage.sprite = _startSprite;
            PauseOrDefeatSystem.instance.SetPause();
        }
    }
}
