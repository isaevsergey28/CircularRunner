using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allStonesPrefabs;
    [SerializeField] private List<StoneMarker> _allStonesMarkers;

    private void Start()
    {
        _allStonesMarkers = GetComponentsInChildren<StoneMarker>().ToList();
        SpawnStones();
    }

    private void SpawnStones()
    {
        foreach (var stoneMarker in _allStonesMarkers)
        {
            if (Random.Range(0, 4) == 1)
            {
                GameObject stonesPrefab = _allStonesPrefabs[Random.Range(0, _allStonesPrefabs.Length)];
                GameObject stone = Instantiate(stonesPrefab, stoneMarker.transform.position, Quaternion.identity, transform);
                stone.transform.Rotate(new Vector3(0, 0, 60 * stoneMarker.GetSide() + transform.root.transform.eulerAngles.z));
            }
        }
    }
}
