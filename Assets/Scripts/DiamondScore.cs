using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _diamondsScoreText;

    private int _currentDiamondsAmount;
    private string _diamondScoreKey = "DiamondScore";
    private int _diamondsAmountPerRun = 0;
    private void Start()
    {
        Debug.Log(1);
        Ads.onAdsShowComplete += GetRewardedDiamonds;
        if (PlayerPrefs.HasKey(_diamondScoreKey))
        {
            _currentDiamondsAmount = PlayerPrefs.GetInt(_diamondScoreKey);
        }
        else
        {
            _currentDiamondsAmount = 0;
        }

        _diamondsScoreText.text = _currentDiamondsAmount.ToString();
    }

    private void OnDisable()
    {
        Debug.Log(2);
        Ads.onAdsShowComplete -= GetRewardedDiamonds;
        PlayerPrefs.SetInt(_diamondScoreKey, _currentDiamondsAmount);
    }

    public void IncreaseScore()
    {
        _currentDiamondsAmount++;
        _diamondsAmountPerRun++;
        _diamondsScoreText.text = _currentDiamondsAmount.ToString();
    }
    
    
    private void GetRewardedDiamonds()
    {
        _currentDiamondsAmount += _diamondsAmountPerRun;
        _diamondsScoreText.text = _currentDiamondsAmount.ToString();
    }
}
