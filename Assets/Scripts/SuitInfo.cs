using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SuitInfo : MonoBehaviour
{
    public bool IsApplied;
    public bool IsLocked;
    public int Cost;

    private string _isAppliedKey = "IsActive";
    private string _isLockedKey = "IsLocked";

    private void Awake()
    {
        _isAppliedKey = "IsActive" + name;
        _isLockedKey = "IsLocked" + name;

        if (IsApplied && !IsLocked)
        {
            PlayerPrefs.SetString(_isAppliedKey, "Active");
            PlayerPrefs.SetString(_isLockedKey, "Unlocked");
        }
        
        if (PlayerPrefs.HasKey(_isAppliedKey))
        {
            if (PlayerPrefs.GetString(_isAppliedKey) == "Active")
            {
                IsApplied = true;
            }
            else if(PlayerPrefs.GetString(_isAppliedKey) == "Inactive")
            {
                IsApplied = false;
            }
        }
        if (PlayerPrefs.HasKey(_isLockedKey))
        {
            if (PlayerPrefs.GetString(_isLockedKey) == "Locked")
            {
                IsLocked = true;
            }
            else if (PlayerPrefs.GetString(_isLockedKey) == "Unlocked")
            {
                IsLocked = false;
            }
        }
    }

    public void SetIsLocked(bool state)
    {
        if (state)
        {
            PlayerPrefs.SetString(_isLockedKey, "Locked");
        }
        else
        {
            PlayerPrefs.SetString(_isLockedKey, "Unlocked");
        }
    }

    public void SetIsApplied(bool state)
    {
        if (state)
        {
            PlayerPrefs.SetString(_isAppliedKey, "Active");
        }
        else
        {
            PlayerPrefs.SetString(_isAppliedKey, "Inactive");
        }
    }
}
