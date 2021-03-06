using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ScreenView[] screens;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
        Init();
    }

    public void Init()
    {
        var length = screens.Length;
        for (var i = 0; i < length; i++)
        {
            var screen = screens[i];
            screen.gameObject.SetActive(true);
            screen.Init();
            screen.gameObject.SetActive(screen.showOnInit);
        }
    }
    
    public T Show<T>() where T : ScreenView
    {
        var desiredScreen = default(ScreenView);
        var length = screens.Length;
        for (var i = 0; i < length; i++)
        {
            var screen = screens[i];
            if (screen is T)
            {
                desiredScreen = screen;
                screen.gameObject.SetActive(true);
                screen.OnShow();
            }
            else
            {
                screen.gameObject.SetActive(false);
                screen.OnHide();
            }
        }

        return desiredScreen as T;
    }
    
    public T ShowImmediately<T>() where T : ScreenView
    {
        var desiredScreen = default(ScreenView);
        var length = screens.Length;
        for (var i = 0; i < length; i++)
        {
            var screen = screens[i];
            if (screen is T)
            {
                desiredScreen = screen;
                screen.gameObject.SetActive(true);
            }
        }

        return desiredScreen as T;
    }
    
    public T Hide<T>() where T : ScreenView
    {
        var desiredScreen = default(ScreenView);
        var length = screens.Length;
        for (var i = 0; i < length; i++)
        {
            var screen = screens[i];
            if (screen is T)
            {
                desiredScreen = screen;
                screen.gameObject.SetActive(false);
            }
        }

        return desiredScreen as T;
    }
    
    public T GetScreen<T>()
    {
        var length = screens.Length;
        for (var i = 0; i < length; i++)
        {
            var window = screens[i];
            if (window is T w)
            {
                return w;
            }
        }

        return default;
    }
}
