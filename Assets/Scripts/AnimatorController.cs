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
            _animator = GetComponent<Animator>();
        }
    }

    public void TurnOnAnim(State state)
    {
        DisableAnim(_currentAnimName);
        switch (state)
        {
            case State.Dead:
                _animator.SetTrigger("DeathTrigger");
                _currentAnimName = "DeathTrigger";
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
