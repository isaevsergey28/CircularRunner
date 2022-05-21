using System;
using System.Collections;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private float _gameSpeed;
    [SerializeField] private float _maxGameSpeed;
    
    public static GameSettings instance;
    public bool IsGetGameScoreBonus { get; private set; }
    
    private Coroutine _bonusCoroutine;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PauseOrDefeatSystem.instance.Subscribe(this);
    }

    private void FixedUpdate()
    {
        IncreaseGameSpeed();
    }
    
    public float GetGameSpeed()
    {
        return _gameSpeed;
    }

    public void IncreaseGameSpeedBonus(float time)
    { 
        if (_bonusCoroutine != null)
        {
            StopCoroutine(_bonusCoroutine);
            _bonusCoroutine = null;
        }
        IsGetGameScoreBonus = true;
        _bonusCoroutine = StartCoroutine(BonusDuration(time));
    }
    
    private IEnumerator BonusDuration(float time)
    {
        yield return new WaitForSeconds(time);
        IsGetGameScoreBonus = false;
    }
    
    private void IncreaseGameSpeed()
    {
        _gameSpeed += Time.fixedDeltaTime / 50;
        _gameSpeed = Mathf.Clamp(_gameSpeed, 0f, _maxGameSpeed);
    }
}
