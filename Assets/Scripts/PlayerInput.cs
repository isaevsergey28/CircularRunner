using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Button _leftScreenSide;
    [SerializeField] private Button _rightScreenSide;

    public static Action<InputScreenSide> OnTouchScreen;

    private void Start()
    {
        _leftScreenSide.onClick.AddListener(SendLeftScreenInput);
        _rightScreenSide.onClick.AddListener(SendRightScreenInput);
    }

    private void SendLeftScreenInput()
    {
        OnTouchScreen?.Invoke(InputScreenSide.Left);
    }

    private void SendRightScreenInput()
    {
        OnTouchScreen?.Invoke(InputScreenSide.Right);
    }
}

public enum InputScreenSide
{
    Left, 
    Right,
}