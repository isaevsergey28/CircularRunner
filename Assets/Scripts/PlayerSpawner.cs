using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPos;
    [SerializeField] private List<SuitInfo> _allSkins;

    private void Start()
    {
        _allSkins = GetComponentsInChildren<SuitInfo>().ToList();
        foreach (var skin in _allSkins)
        {
            if (skin.GetComponent<SuitInfo>().IsApplied)
            {
                skin.gameObject.SetActive(true);
                skin.transform.position = _spawnPos;
                skin.GetComponent<AnimationStateSystem>().ChangeState(State.Run);
            }
            else
            {
                skin.gameObject.SetActive(false);
            }
        }
    }
}
