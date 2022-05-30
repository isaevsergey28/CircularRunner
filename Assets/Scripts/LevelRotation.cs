using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelRotation : MonoBehaviour
{
    private void Start()
    {
        PauseOrDefeatSystem.instance.Subscribe(this);
        SwipeInput.onSwipe += CheckRotationSwipe;
    }

    private void OnDestroy()
    {
        SwipeInput.onSwipe -= CheckRotationSwipe;
    }
    
    private void CheckRotationSwipe(SwipeType swipeType)
    {
        Quaternion newRotation;
        switch (swipeType)
        {
            case SwipeType.LEFT:
                newRotation = Quaternion.Euler(transform.eulerAngles +
                   new Vector3(0, 0, 60f));
                newRotation.eulerAngles = new Vector3(0, 0, RoundRotation(newRotation.eulerAngles.z));
                transform.DORotate(newRotation.eulerAngles,
                   0.5f, RotateMode.Fast);
                break;
            case SwipeType.RIGHT:
                newRotation = Quaternion.Euler(transform.eulerAngles +
                   new Vector3(0, 0, -60f));
                newRotation.eulerAngles = new Vector3(0, 0, RoundRotation(newRotation.eulerAngles.z));
                transform.DORotate(newRotation.eulerAngles,
                    0.5f, RotateMode.Fast);
                break;
        }
    }

    private float RoundRotation(float rotation)
    {
        float f = rotation % 60;
        if (f > 30)
        {
            rotation += 60 - f;
        }
        else
        {
            rotation -= f;
        }
        return rotation;
    }
}
