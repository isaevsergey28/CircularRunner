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

    private void Start()
    {
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

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(_diamondScoreKey, _currentDiamondsAmount);
    }

    public void IncreaseScore()
    {
        _currentDiamondsAmount++;
        _diamondsScoreText.text = _currentDiamondsAmount.ToString();
    }
}
