using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPos;
    [SerializeField] private List<GameObject> _allSkins;

    private void Start()
    {
        foreach (var skin in _allSkins)
        {
            skin.gameObject.SetActive(skin.GetComponent<SuitInfo>().IsApplied);
            skin.transform.position = _spawnPos;
        }
    }
}
