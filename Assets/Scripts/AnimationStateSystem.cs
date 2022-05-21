using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateSystem : MonoBehaviour
{
    [SerializeField] private AnimatorController _animController;

    public void ChangeState(State state)
    {
        _animController.TurnOnAnim(state);
    }

    public void SendAnimValue(string animName, float value)
    {
        _animController.ChangeAnimValue(animName, value);
    }

    public void StopAnimByName(string name)
    {
        _animController.DisableAnim(name);
    }

    public bool CheckForAnimActive(string name)
    {
        return _animController.GetAnimator().GetCurrentAnimatorStateInfo(0).IsName(name);
    }
}
public enum State
{
    Dead,
    
}