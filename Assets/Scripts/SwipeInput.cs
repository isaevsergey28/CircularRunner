using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    public static Action<SwipeType> onSwipe;

    private bool _isDragging, _isMobilePlatform;
    private Vector2 _tapPoint, _swipeDelta;
    private float _minSwipeDelta = 130;


    private void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDLONE
        _isMobilePlatform = false;
#else
        _isMobilePlatform = true;
#endif
    }

    private void Start()
    {
        PauseOrDefeatSystem.instance.Subscribe(this);
    }

    private void Update()
    {
        if (_isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    _isDragging = true;
                    _tapPoint = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Canceled ||
                        Input.touches[0].phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
                _tapPoint = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }
        }
        CalculateSwipe();
    }

    private void CalculateSwipe()
    {
        _swipeDelta = Vector2.zero;
        if (_isDragging)
        {
            if (!_isMobilePlatform && Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _tapPoint;
            }
            else if (Input.touchCount > 0)
            {
                _swipeDelta = Input.touches[0].position - _tapPoint;
            }
        }
        if (_swipeDelta.magnitude > _minSwipeDelta)
        {
            if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
            {
                onSwipe?.Invoke(_swipeDelta.x < 0 ? SwipeType.LEFT : SwipeType.RIGHT);
            }
            ResetSwipe();
        }

    }

    private void ResetSwipe()
    {
        _isDragging = false;
        _tapPoint = _swipeDelta = Vector2.zero;
    }
}
public enum SwipeType
{
    LEFT,
    RIGHT,
}
