using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _currentAnimName;
    
    private void Start()
    {
        if (!_animator)
        {
            _animator = GetComponentInChildren<Animator>();
            _animator.ResetTrigger("HipHop");
        }
    }

    public void TurnOnAnim(State state)
    {
        DisableAnim(_currentAnimName);
        switch (state)
        {
            case State.Dead:
                _animator.SetTrigger("FallDown");
                _currentAnimName = "FallDown";
                break;
            case State.Run:
                _animator.SetTrigger("Run");
                _currentAnimName = "Run";
                break;
        }
    }

    public void DisableAnim(string animName)
    {
        _animator.ResetTrigger(animName);
    }

    public void ChangeAnimValue(string animName, float value)
    {
        _animator.SetFloat(animName, value);
    }

    public Animator GetAnimator()
    {
        return _animator;
    }
}
