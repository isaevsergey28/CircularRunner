using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimationStateSystem _animationStateSystem;

    public static Action onPlayerDeath;

    private bool _isInvulnerable;
    private Coroutine _bonusCoroutine;

    public void SetDeath()
    {
        if (_isInvulnerable)
            return;
        _animationStateSystem.ChangeState(State.Dead);
        onPlayerDeath?.Invoke();
       StartCoroutine(ShowLosePanel());
    }
    
    public void MakeInvulnerable(float time)
    { 
        if (_bonusCoroutine != null)
        {
            StopCoroutine(_bonusCoroutine);
            _bonusCoroutine = null;
        }
        _isInvulnerable = true;
        _bonusCoroutine = StartCoroutine(BonusDuration(time));
    }
    
    private IEnumerator BonusDuration(float time)
    {
        yield return new WaitForSeconds(time);
        _isInvulnerable = false;
    }

    private IEnumerator ShowLosePanel()
    {
        yield return new WaitForSeconds(1f);
        UIManager.instance.ShowImmediately<LoseCanvas>();
       
    }
}
