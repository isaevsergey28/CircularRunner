using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvas : ScreenView
{
    [SerializeField] private TextMeshProUGUI _maxGameScoreText;
    [SerializeField] private TextMeshProUGUI _currentDiamondsText;
    [SerializeField] private Button _customizeButton;
    
    private string _diamondScoreKey = "DiamondScore";
    private string _gameScoreKey = "GameScoreKey";
    
    public override void Init()
    {
        if (PlayerPrefs.HasKey(_diamondScoreKey))
        {
            _currentDiamondsText.text += " " + PlayerPrefs.GetInt(_diamondScoreKey);
        }
        else
        {
            _currentDiamondsText.text += " " + "0";
        }
        
        if (PlayerPrefs.HasKey(_gameScoreKey))
        {
            _maxGameScoreText.text += " " + PlayerPrefs.GetInt(_gameScoreKey);
        }
        else
        {
            _maxGameScoreText.text += " " + "0";
        }
        _customizeButton.onClick.AddListener(ShowCustomizeCanvas);
    }

    public override void OnShow()
    {
        
    }

    public override void OnHide()
    {

    }

    private void ShowCustomizeCanvas()
    {
        UIManager.instance.Show<CustomizeCanvas>();
    }
}
