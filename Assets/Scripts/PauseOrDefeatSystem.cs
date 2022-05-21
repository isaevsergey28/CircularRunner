using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PauseOrDefeatSystem : MonoBehaviour
{
    public static PauseOrDefeatSystem instance;
    
    [SerializeField] private List<MonoBehaviour> _allRegisteredScripts = new List<MonoBehaviour>();
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Player.onPlayerDeath += DestroyScripts;
    }

    private void OnDisable()
    {
        Player.onPlayerDeath -= DestroyScripts;
    }

    public void Subscribe(MonoBehaviour script)
    {
        _allRegisteredScripts.Add(script);
    }
    
    public void Unsubscribe(MonoBehaviour script)
    {
        _allRegisteredScripts.Remove(script);
    }

    public void SetPause()
    {
        foreach (var script in _allRegisteredScripts.ToList())
        {
            script.enabled = false;
        }
    }

    public void SetUnpause()
    {
        foreach (var script in _allRegisteredScripts.ToList())
        { 
            script.enabled = true;
        }
    }

    private void DestroyScripts()
    {
        foreach (var script in _allRegisteredScripts.ToList())
        {
            Destroy(script);
        }
    }
}
