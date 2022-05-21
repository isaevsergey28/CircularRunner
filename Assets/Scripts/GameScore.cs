using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameScoreText;
    [SerializeField] private TextMeshProUGUI _loseInfoText;

    private float _currentGameScore;
    private int _bonusScoreIncrement = 2;
    private float _scoreSpeed;
    private string _gameScoreKey = "GameScoreKey";
    
    private void Start()
    {
        PauseOrDefeatSystem.instance.Subscribe(this);
        Player.onPlayerDeath += SetLoseInfo;
    }

    private void OnDestroy()
    {
        Player.onPlayerDeath -= SetLoseInfo;
    }
    
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(_gameScoreKey, (int)_currentGameScore);
    }
    
    private void FixedUpdate()
    {
            _scoreSpeed = GameSettings.instance.IsGetGameScoreBonus
                ? GameSettings.instance.GetGameSpeed() * _bonusScoreIncrement
                : GameSettings.instance.GetGameSpeed();
        _currentGameScore += (Time.fixedDeltaTime * _scoreSpeed);
        _gameScoreText.text = ((int)_currentGameScore).ToString();
    }

    private void SetLoseInfo()
    {
        _loseInfoText.text += " " + ((int)_currentGameScore);
    }
}
